using Newtonsoft.Json.Linq;
using Noesis.Javascript;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TypeScriptSyntaxVisualizer.Model;
using TypeScriptSyntaxVisualizer.TypeScript.Services;

namespace TypeScriptSyntaxVisualizer.TypeScript
{
    public class TypeScriptContext
    {
        internal LanguageServiceHost Host;
        private JavascriptContext context = new JavascriptContext();
        public ObservableCollection<AstTreeItem> SyntaxTree = new ObservableCollection<AstTreeItem>();

        public TypeScriptContext()
        {
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string script = File.ReadAllText(Path.Combine(currentPath, "Scripts", "typescriptServices.js"));
            context.Run(script);

            Host = new LanguageServiceHost(new NullLogger());
            context.SetParameter("host", Host);

            context.Run("var ls = new TypeScript.Services.LanguageService(host);");
        }

        public void OpenFile(string filename, string text)
        {
            Host.OpenFile(filename, text);

            string tree = context.Run("JSON.stringify(ls.getSyntaxTree('" + filename.Replace("\\", "\\\\") + "'), null, 4)") as string;
            JObject treeObj = JObject.Parse(tree);
            this.SyntaxTree.Clear();
            this.SyntaxTree.Add(new AstTreeItem(treeObj["sourceUnit"]));
        }

        public void RemoveFile(string filename)
        {
            Host.RemoveFile(filename);
        }
    }
}
