using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelouge.Model
{
    internal class CheckListItem
    {
        public string Text{ get; set; }
        public DateTime? Date { get; set; }
        public int Priority{ get; set; }
        public bool Clearance{ get; set; }
    }
}
