using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project_PRG281.BusinessLogicLayer
{
    internal class Modules
    {
        string ModuleCode;
        string ModuleName;
        string ModuleDescription;
        string OnlineResourcesLink;

        public Modules() { }

        public Modules(string moduleCode, string moduleName, string moduleDescription, string onlineResourcesLink)
        {
            ModuleCode = moduleCode;
            ModuleName = moduleName;
            ModuleDescription = moduleDescription;
            OnlineResourcesLink = onlineResourcesLink;
        }

        public string ModuleCode1 { get; set; }
        public string ModuleName1 { get; set; }
        public string ModuleDescription1 { get; set; }
        public string OnlineResourcesLink1 { get; set; }
    }
}
