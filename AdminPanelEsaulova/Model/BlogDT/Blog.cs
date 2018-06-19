using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdminPanelEsaulova.Model.BlogDT
{
    public class Blog
    {
        public int ID { get; set; }
        [Required]
        public string HederText { get; set; }
        [Required]
        public string FillText { get; set; }
        [Required]
        public string FullText { get; set; }
        public string ImgDir { get; set; }
        public DateTime DataPublick { get; set; }
        [Required]
        public int ThemaID { get; set; }
        public int RazdelID { get; set; }
        [Required]
        public bool NewsArhiv { get; set; }
        [Required]
        public bool TopNews { get; set; }

        private string _data;
        public string DatePublick
        {
            get
            {
                return _data;
            }
            set { _data = DataPublick.ToLongDateString(); }
        }
    }
}
