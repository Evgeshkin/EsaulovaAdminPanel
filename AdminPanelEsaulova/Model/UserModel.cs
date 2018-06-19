using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelEsaulova.Model
{
    public class UserModel
    {
        public TeaType SelectTeaType { get; set; }
    }

    public enum TeaType
    {
        Tea, Coffee, GreenTea, BlackTea
    }
}