using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanelEsaulova.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanelEsaulova.Pages.Uslugis
{
    public class IndexModel : PageModel
    {
        UslugiDataAccess uslugiDataAccess = new UslugiDataAccess();
        public List<UslugiDT> UslugiDTs { get; set; }
        public void OnGet()
        {
            UslugiDTs = uslugiDataAccess.GetUslugiDTs().ToList();
        }

        public ActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            uslugiDataAccess.DeleteUslugu(id);
            return RedirectToPage();
        }
    }
}