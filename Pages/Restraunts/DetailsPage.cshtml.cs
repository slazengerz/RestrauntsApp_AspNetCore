using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestrauntDataNetCore.Services;
using RestrauntsDataNetCore;

namespace RestrauntsAgain.Pages.Restraunts
{
    public class DetailsPageModel : PageModel
    {
        public IRestrauntData IRestrauntData { get; set; }
        public Restraunt Restraunt { get; set; }
        [TempData]
        public string Message { get; set; }
        public DetailsPageModel(IRestrauntData restrauntData)
        {
            this.IRestrauntData = restrauntData;
        }    
        public void OnGet(int? restrauntID)
        {
            Restraunt = IRestrauntData.GetRestrauntById(restrauntID);
        }
    }
}