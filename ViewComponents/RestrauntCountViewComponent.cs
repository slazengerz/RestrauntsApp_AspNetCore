using Microsoft.AspNetCore.Mvc;
using RestrauntDataNetCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestrauntsAgain.ViewComponents
{
    public class RestrauntCountViewComponent:ViewComponent
    {
        private IRestrauntData IRestrauntData;
        public RestrauntCountViewComponent(IRestrauntData IrestData)
        {
            this.IRestrauntData = IrestData;
        }

        public IViewComponentResult Invoke()
        {
            var count = IRestrauntData.GetRestrauntCount();
            return View(count);
        }
    }
}
