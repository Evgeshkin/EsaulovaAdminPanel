using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdminPanelEsaulova.Model.BlogDT;

namespace AdminPanelEsaulova.Pages.Blogis
{
    public class IndexModel : PageModel
    {
        ThemaDataAccess themaDataAccess = new ThemaDataAccess();
        BlogDataAccess blogDataAccess = new BlogDataAccess();
        public List<ThemaBloga> themaBlogas { get; set; }
        public List<Blog> blogis { get; set; }
        public int themaID { get; set; }
        public async Task<IActionResult> OnGetAsync(int? themaID=0)
        {
            
            themaBlogas = await GetThemaBloga();
            if (themaID != null || themaID > 0)
                blogis = await GetBlogsByTemaID(themaID);
            else
                blogis = await GetBlogs();
            return Page();
        }

        [HttpPost]
        public ActionResult Index(int? themaID=1)
        {
            return Page();
        }
        public ActionResult Result(int? id)
        {

            return RedirectToPage();
        }

        private Task<List<ThemaBloga>> GetThemaBloga()
        {
            return Task.Factory.StartNew<List<ThemaBloga>>(() =>
            {
                List<ThemaBloga> them = themaDataAccess.GetThemaBlog().ToList();
                return them;
            });
        }
        /// <summary>
        /// Возвращаем коллекцию записей блога без исключения
        /// </summary>
        /// <returns>List Blog</returns>
        private Task<List<Blog>> GetBlogs()
        {
            return Task.Factory.StartNew<List<Blog>>(() =>
            {
                List<Blog> blog = blogDataAccess.GetBlog().ToList();
                return blog;
            });
        }
        /// <summary>
        /// Возвращаем коллекцию записей блога по выбранной теме
        /// </summary>
        /// <param name="idtema">индентификатор выбраной темы</param>
        /// <returns>List<Blog></returns>
        private Task<List<Blog>> GetBlogsByTemaID(int? idtema)
        {
            return Task.Factory.StartNew<List<Blog>>(() =>
            {
                List<Blog> blog = blogDataAccess.GetBlogByThema(idtema).ToList();
                return blog;
            });
        }
    }
}