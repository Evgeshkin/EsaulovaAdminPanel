using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanelEsaulova.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanelEsaulova.Pages.Uslugis
{
    public class EditModel : PageModel
    {
        UslugiDataAccess uslugiDataAccess = new UslugiDataAccess();
        [BindProperty]
        public UslugiDT Usluga { get; set; }

        /* public ActionResult OnGet(int? id)
         {
             Usluga = uslugiDataAccess.GetUslugaByID(id);
             return Page();
         }*/

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            uslugiDataAccess.UpdateUslugu(Usluga);
            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Usluga = await GetUslugu(id);
            return Page();
        }
        private Task<UslugiDT> GetUslugu(int? id)
        {
            return Task.Run(() =>
            {
                UslugiDT usl = uslugiDataAccess.GetUslugaByID(id);
                return usl;
            });
        }
    }
}