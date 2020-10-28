using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EshopWebApp.Pages
{
    public class ConfirmedModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string firstname { get; set; }
        [BindProperty(SupportsGet = true)]
        public string lastname { get; set; }
        [BindProperty(SupportsGet = true)]
        public double TotalPrice { get; set; }
        public void OnGet()
        {
        }
    }
}
