using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matlabs.OwlRacer.Common.Options
{
    public class PythonOptions
    {
        public string BinPath { get; set; }
        public List<ScriptMappingOptions> ScriptMappings { get; set; }
    }
}
