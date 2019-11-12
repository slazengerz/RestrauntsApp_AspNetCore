using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestrauntDataNetCore.Services;
using RestrauntsDataNetCore;

namespace RestrauntsAgain.Pages.Restraunts
{
    public class EditRestrauntModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Restraunt RestrauntToEdit { get; set; }
        public string CreateOrEditProperty { get; set; }
        readonly IRestrauntData restrauntData;

        public int restrauntId;
        public IEnumerable<SelectListItem> CusineOptions { get; set; }
        private IHtmlHelper htmlhelper;

        public EditRestrauntModel(IRestrauntData restrauntdata,IHtmlHelper htmlHelper)
        {
            this.restrauntData = restrauntdata;
            this.htmlhelper = htmlHelper;
        }
        public IActionResult OnGet(int? restrauntId)
        {
            this.CusineOptions = htmlhelper.GetEnumSelectList<CusineType>();
            if (restrauntId != null)
            {
                CreateOrEditProperty = "Edit Restraunt";
                TempData["Message"] = "Edited Successfully";
                RestrauntToEdit = restrauntData.GetRestrauntById(restrauntId);
                if(RestrauntToEdit == null)
                {
                    return RedirectToPage("./NotFoundPage");
                }
                return Page();
            }
            else
            {
                //else user is trying to create restraunt
                TempData["Message"] = "Created Successfully";
                CreateOrEditProperty = "Create Restraunt";
                RestrauntToEdit = new Restraunt();
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            this.CusineOptions = htmlhelper.GetEnumSelectList<CusineType>();
            if (ModelState.IsValid)
            {
                RestrauntToEdit = restrauntData.CreateEditRestraunt(RestrauntToEdit);
                return RedirectToPage("./DetailsPage", new { restrauntId = RestrauntToEdit.Id });
            }
            return Page();
        }
    }
}