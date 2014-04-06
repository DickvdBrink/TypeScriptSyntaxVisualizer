using Noesis.Javascript;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptSyntaxVisualizer.TypeScript
{
    public class TypeScriptContext
    {
        JavascriptContext context = new JavascriptContext();

        public TypeScriptContext()
        {
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string script = File.ReadAllText(Path.Combine(currentPath, "Scripts", "typescriptServices.js"));
            context.Run(script);
        }
    }
}
