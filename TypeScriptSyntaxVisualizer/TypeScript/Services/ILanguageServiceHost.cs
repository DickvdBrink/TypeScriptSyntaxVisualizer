using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptSyntaxVisualizer.TypeScript.Services
{
    interface ILanguageServiceHost : ILogger, IReferenceResolverHost
    {
        //TypeScript.CompilationSettings
        string getCompilationSettings();

        //string[];
        string getScriptFileNames();
        int getScriptVersion(string fileName);
        bool getScriptIsOpen(string fileName);
        ByteOrderMark getScriptByteOrderMark(string fileName);
        ILanguageServicesDiagnostics getDiagnosticsObject();
        string getLocalizedDiagnosticMessages();
    }    
}
