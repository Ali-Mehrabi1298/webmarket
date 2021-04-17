using Microsoft.AspNetCore.Mvc;
using ShoppDJ.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Component
{
    public class ProductSpecial : ViewComponent
    {
        private IGroupRepository _groupRepository;

        public ProductSpecial(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Component/ProductSpecial.cshtml", _groupRepository.GroupSpecial());

        }




     
    }
}
