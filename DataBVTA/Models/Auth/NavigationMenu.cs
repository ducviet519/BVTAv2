using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataBVTA.Models
{
    public class NavigationMenu
    {
        public string MenuID { get; set; }

        public string Name { get; set; }

        public string Area { get; set; }

        public string ControllerID { get; set; }

        public string ActionID { get; set; }

        public bool Visible { get; set; }

        public bool Checked { get; set; }
    }

    public class ModuleController
    {
        public string ControllerID { get; set; }
        public string ControllerName { get; set; }
    }

    public class ModuleAction
    {
        public string ActionID { get; set; }
        public string ActionName { get; set; }
    }
}
