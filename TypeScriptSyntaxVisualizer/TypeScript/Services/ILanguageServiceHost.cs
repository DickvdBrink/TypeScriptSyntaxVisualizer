using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptSyntaxVisualizer.TypeScript.Services
{
    interface ILanguageServiceHost
    {
        CompilerOptions getCompilationSettings();

        string getNewLine();
        string getProjectVersion();
        string[] getScriptFileNames();
        string getScriptVersion(string filename);
        IScriptSnapshot getScriptSnapshot(string filename);

        string getLocalizedDiagnosticMessages();
        HostCancellationToken getCancellationToken();
        string getCurrentDirectory();
        string getDefaultLibFileName(CompilerOptions options);

        void log(string s);
        void trace(string s);
        void error(string s);
        bool useCaseSensitiveFileNames();
        string[] resolveModuleNames(string[] moduleNames, string containingFile);
    }    
}
