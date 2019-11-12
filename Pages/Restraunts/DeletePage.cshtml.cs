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
    public class DeletePageModel : PageModel
    {
        private IRestrauntData IRestrauntData;
        [TempData]
        public string DelMessage { get; set; }
        [BindProperty(SupportsGet =true)]
        public Restraunt Restraunt { get; set; }
        public DeletePageModel(IRestrauntData irestrauntdata)
        {
            this.IRestrauntData = irestrauntdata;
        }
        public IActionResult OnGet(int? restrauntId)
        {
            Restraunt = IRestrauntData.GetRestrauntById(restrauntId);
            return Page();
        }
        public IActionResult OnPost(int restrauntId)
        {
            var result = IRestrauntData.DeleteRestraunt(restrauntId);
            if (result)
            {
                TempData["DelMessage"] = $"Restraunt {Restraunt.Name} deleted successfully";
            }
            else
            {
                TempData["DelMessage"] = $"Unable to delete Restraunt {Restraunt.Name} ";
            }
            return RedirectToPage("./MainPage");
        }
    }
}