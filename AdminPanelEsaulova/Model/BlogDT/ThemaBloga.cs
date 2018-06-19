using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdminPanelEsaulova.Model.BlogDT
{
    public class ThemaBloga
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

       static ThemaDataAccess themaDataAccess = new ThemaDataAccess();

        public static Task<List<ThemaBloga>> GetThemaBloga()
        {
            return Task.Factory.StartNew<List<ThemaBloga>>(() =>
            {
                List<ThemaBloga> them = themaDataAccess.GetThemaBlog().ToList();
                return them;
            });
        }
    }



}
