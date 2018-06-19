using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanelEsaulova.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanelEsaulova.Pages.Uslugis
{
    public class CreateModel : PageModel
    {
        UslugiDataAccess uslugiDataAccess = new UslugiDataAccess();

        [BindProperty]
        public UslugiDT Usluga { get; set; }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            uslugiDataAccess.AddUslugu(Usluga);
            return RedirectToPage("Index");
        }
    }
}