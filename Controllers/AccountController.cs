using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppDJ.Data;
using ShoppDJ.Data.Repository;
using ShoppDJ.Models;
using ShoppDJ.Security.Providers;
using ShoppDJ.ViewModels;

namespace BookAudiomak.Controllers
{
    public class AccountController : Controller
    //IdentityUser
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMessageSender _messageSender;
        private readonly Shopingcontex _Shopingcontex;
        private readonly IPhoneTotpProvider _phoneTotpProvider;




        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IMessageSender messageSender, IPhoneTotpProvider phoneTotpProvider, Shopingcontex shopingcontex)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _messageSender = messageSender;
            _phoneTotpProvider = phoneTotpProvider;
            _Shopingcontex = shopingcontex;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //var ss = _userManager.Users.Single(a => a.PhoneNumber == model.PhoneNumber);


            if (ModelState.IsValid)
            {


                try
                {
                    var dd = _userManager.Users.Single(a => a.codeconfig == model.code);
                  

                    {


                        var user = await _Shopingcontex.Users.Where(u => u.codeconfig == model.code)
                          .SingleOrDefaultAsync();

                        user.PhoneNumberConfirmed = true;
                        user.DateTime = DateTime.Now;


                        await _Shopingcontex.SaveChangesAsync();



                    }
                    return RedirectToAction("Index", "Home");

                }
                catch
                {



                    //ModelState.AddModelError("", $"کد وارد شده اشتباه است برای ارسال دوباره کد، لطفا 10 ثانیه صبر کنید .");

                    if (TempData.ContainsKey("PTC"))
                    {
                        var totpTempDataModel = JsonSerializer.Deserialize<PhoneTotpTempDataModel>(TempData["PTC"].ToString()!);
                        if (totpTempDataModel.ExpirationTime >= DateTime.Now)
                        {
                            var differenceInSeconds = (int)(totpTempDataModel.ExpirationTime - DateTime.Now).TotalSeconds;
                            ModelState.AddModelError("", $"برای ارسال دوباره کد، لطفا {differenceInSeconds} ثانیه صبر کنید.");
                            TempData.Keep("PTC");
                            return View();
                        }
                    }
                    return View();

                }



            }
            return View(model);


        }


        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync())
        .ToList()
            };


            ViewData["returnUrl"] = returnUrl;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            ViewData["returnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    ViewData["ErrorMessage"] = "اکانت شما به دلیل پنج بار ورود ناموفق به مدت پنج دقیقه قفل شده است";
                    return View(model);
                }


                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "رمزعبور یا نام کاربری اشتباه است");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return Json(true);
            return Json("ایمیل وارد شده از قبل موجود است");
        }

        public async Task<IActionResult> IsUserNameInUse(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return Json(true);
            return Json("نام کاربری وارد شده از قبل موجود است");
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Account",
                new { ReturnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        public async Task<IActionResult> ExternalLoginCallBack(string returnUrl = null, string remoteError = null)
        {
            returnUrl =
                (returnUrl != null && Url.IsLocalUrl(returnUrl)) ? returnUrl : Url.Content("~/");

            var loginViewModel = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError("", $"Error : {remoteError}");
                return View("Login", loginViewModel);
            }

            var externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (externalLoginInfo == null)
            {
                ModelState.AddModelError("ErrorLoadingExternalLoginInfo", $"مشکلی پیش آمد");
                return View("Login", loginViewModel);
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey, false, true);

            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }

            var email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);

            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    var userName = email.Split('@')[0];
                    user = new ApplicationUser()
                    {
                        UserName = (userName.Length <= 10 ? userName : userName.Substring(0, 10)),
                        Email = email,
                        EmailConfirmed = true
                    };

                    await _userManager.CreateAsync(user);
                }

                await _userManager.AddLoginAsync(user, externalLoginInfo);
                await _signInManager.SignInAsync(user, false);

                return Redirect(returnUrl);
            }

            ViewBag.ErrorTitle = "لطفا با بخش پشتیبانی تماس بگیرید";
            ViewBag.ErrorMessage = $"دریافت کرد {externalLoginInfo.LoginProvider} نمیتوان اطلاعاتی از";
            return View();
        }







        [HttpGet]
        public IActionResult SendTotpCode()
        {
            if (_signInManager.IsSignedIn(User)) return RedirectToAction("Index", "Home");
            if (TempData.ContainsKey("PTC"))
            {
                var totpTempDataModel = JsonSerializer.Deserialize<PhoneTotpTempDataModel>(TempData["PTC"].ToString()!);
                if (totpTempDataModel.ExpirationTime >= DateTime.Now)
                {
                    var differenceInSeconds = (int)(totpTempDataModel.ExpirationTime - DateTime.Now).TotalSeconds;
                    ModelState.AddModelError("", $"برای ارسال دوباره کد، لطفا {differenceInSeconds} ثانیه صبر کنید.");
                    TempData.Keep("PTC");
                    return View();
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendTotpCode(SendTotpCodeViewModel model)
        {
            if (_signInManager.IsSignedIn(User)) return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                if (TempData.ContainsKey("PTC"))
                {
                    var totpTempDataModel = JsonSerializer.Deserialize<PhoneTotpTempDataModel>(TempData["PTC"].ToString()!);
                    if (totpTempDataModel.ExpirationTime >= DateTime.Now)
                    {
                        var differenceInSeconds = (int)(totpTempDataModel.ExpirationTime - DateTime.Now).TotalSeconds;
                        ModelState.AddModelError("", $"برای ارسال دوباره کد، لطفا {differenceInSeconds} ثانیه صبر کنید.");
                        TempData.Keep("PTC");
                        return View();
                    }
                }

                var secretKey = Guid.NewGuid().ToString();
                var totpCode = _phoneTotpProvider.GenerateTotp(secretKey);

                var userExists = await _userManager.Users
                    .AnyAsync(user => user.PhoneNumber == model.PhoneNumber);
                if (userExists)
                {
                    //TODO send totpCode to user.
                }

                TempData["PTC"] = JsonSerializer.Serialize(new PhoneTotpTempDataModel()
                {
                    SecretKey = secretKey,
                    PhoneNumber = model.PhoneNumber,
                    //ExpirationTime = DateTime.Now.AddSeconds(_phoneTotpOptions.StepInSeconds)
                });

                //RedirectToAction("VerifyTotpCode");
                //return Content(totpCode);
                try
                {
                    var dd = _userManager.Users.Single(a => a.PhoneNumber == model.PhoneNumber);



                    if (model.PhoneNumber == dd.PhoneNumber)
                    {
                        var user = await _Shopingcontex.Users.Where(u => u.PhoneNumber == model.PhoneNumber)
                         .SingleOrDefaultAsync();

                        user.PhoneNumberConfirmed = false;
                        user.DateTime = DateTime.Now;
                        user.PasswordHash = model.Password;
                        user.codeconfig = totpCode;
                        await _Shopingcontex.SaveChangesAsync();
                        return RedirectToAction("Register");
                    }
                }
                catch
                {
                    var user = new ApplicationUser()
                    {
                        UserName = model.PhoneNumber,
                        PhoneNumber = model.PhoneNumber,
                        PhoneNumberConfirmed = false,
                        DateTime = DateTime.Now,
                        codeconfig = totpCode,


                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {

                        return RedirectToAction("Register");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
                return View(model);

            }

            return View();
            ;
        }

        [HttpGet]
        public IActionResult VerifyTotpCode()
        {
            if (_signInManager.IsSignedIn(User)) return RedirectToAction("Index", "Home");

            return View();
        }
    }
}





