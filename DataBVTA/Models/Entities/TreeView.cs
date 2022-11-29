using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Models.Entities
{
    public class TreeView
    {
        public string text { get; set; }
        public string href { get; set; }
        public List<TreeView> nodes { get; set; }
    }
}
