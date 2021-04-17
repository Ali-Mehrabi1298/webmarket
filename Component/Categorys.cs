using Microsoft.AspNetCore.Mvc;
using ShoppDJ.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Component
{
    public class Categorys : ViewComponent
    {
        private IGroupRepository _groupRepository;

        public Categorys(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Component/Categorys.cshtml", _groupRepository.GetGroupForShow());


        }
    }
}
