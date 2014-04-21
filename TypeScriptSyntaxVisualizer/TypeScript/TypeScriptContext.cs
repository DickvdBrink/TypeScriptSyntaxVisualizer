using Noesis.Javascript;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TypeScriptSyntaxVisualizer.TypeScript.Services;

namespace TypeScriptSyntaxVisualizer.TypeScript
{
    public class TypeScriptContext
    {
        public JavascriptContext context = new JavascriptContext();
        internal LanguageServiceHost host;

        public TypeScriptContext()
        {
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string script = File.ReadAllText(Path.Combine(currentPath, "Scripts", "typescriptServices.js"));
            context.Run(script);

            host = new LanguageServiceHost(new NullLogger());
            context.SetParameter("host", host);

            context.Run("var ls = new TypeScript.Services.LanguageService(host);");
        }
    }
}
