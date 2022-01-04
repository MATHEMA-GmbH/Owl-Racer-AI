using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matlabs.OwlRacer.Common.Options;

namespace Matlabs.OwlRacer.Common.Options
{
    public struct StartLineOptions
    {
        public StartLineOptions(VectorOptions start, VectorOptions end)
        {
            Start = start;
            End = end;
        }

        public VectorOptions Start { get; set; }
        public VectorOptions End { get; set; }
    }
}
