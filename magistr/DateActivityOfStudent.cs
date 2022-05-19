using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magistr
{
    public class DateActivityOfStudent
    {
        public DateTime DateP { get; set; }
        public string Date { get => DateP.ToShortDateString(); }
    }
}
