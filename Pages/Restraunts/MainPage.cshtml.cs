using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestrauntDataNetCore.Services;
using RestrauntsDataNetCore;

namespace RestrauntsAgain.Pages
{
    public class MainPageModel : PageModel
    {
        private IRestrauntData IRestrauntData;
        public IEnumerable<Restraunt> RestrauntList { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public MainPageModel(IRestrauntData restraunt)
        {
            this.IRestrauntData = restraunt;
        }
        public void OnGet(string SearchTerm)
        {
            RestrauntList = IRestrauntData.SearchAllRestratuns(SearchTerm);
        }
    }
}