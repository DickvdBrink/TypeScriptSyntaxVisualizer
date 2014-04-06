using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptSyntaxVisualizer.TypeScript
{
    interface ILogger
    {
        bool information();
        bool debug();
        bool warning();
        bool error();
        bool fatal();
        void log(string s);
    }
}
