using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelEsaulova.Model
{
    public class UslugiDT
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public string DataGroup { get; set; }
        [Required]
        public string Opisanie { get; set; }
        [Required]
        public bool TopUsl { get; set; }

        public bool EkonomDela { get; set; }
        public bool GrajdanDela { get; set; }
        public bool UgolovDela { get; set; }
    }
}
