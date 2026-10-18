using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ServerSystem.Commands
{
    public class Command
    {
        public string PROCLIST = "proclist";
        public string KILL = "kill";
        public string RUN = "run";
        public string? Text { get; set; }
        public string? Param { get; set; }
    }
}