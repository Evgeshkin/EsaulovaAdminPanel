using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanelEsaulova.Model.BlogDT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanelEsaulova.Pages.Blogis
{
    public class SelectThemaModel : PageModel
    {
        public List<ThemaBloga> themaBlogas { get; set; }
        public async Task<IActionResult> OnGetAsync(int? themaID = 0)
        {
            themaBlogas = await ThemaBloga.GetThemaBloga();
            return Page();
        }
    }
}