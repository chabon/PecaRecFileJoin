using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PecaRecFileJoin
{
    public class JoinProfile
    {
        public string OutputFileName { get; set; }
        public string OutputDir { get; set; }
        public string Extension { get; set; }
        public string[] Files { get; set; }
        public string State { get; set; } = "待機";

        public JoinProfile()
        {
        }
    }
}
