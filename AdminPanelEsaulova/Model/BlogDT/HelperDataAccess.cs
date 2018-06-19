using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelEsaulova.Model.BlogDT
{
    public class HelperDataAccess
    {
        private const string cmdText = "adv_Blogs_SelectByThemaID";

        public static string CmdText => cmdText;

        public List<Blog> listBloga { get; set; }
    }
}
