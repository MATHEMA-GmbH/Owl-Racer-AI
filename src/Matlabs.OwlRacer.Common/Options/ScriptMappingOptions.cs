using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matlabs.OwlRacer.Common.Options
{
    public class ScriptMappingOptions
    {
        public string Key { get; set; }
        public string File { get; set; }
        public string Args { get; set; }
        public bool ShellExecute { get; set; }
        public string CarName { get; set; }
        public string CarColar { get; set; }
    }
}
