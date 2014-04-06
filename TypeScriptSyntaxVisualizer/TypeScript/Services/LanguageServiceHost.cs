using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptSyntaxVisualizer.TypeScript.Services
{
    class LanguageServiceHost : ILanguageServiceHost
    {

        public string getCompilationSettings()
        {
            throw new NotImplementedException();
        }

        public string getScriptFileNames()
        {
            throw new NotImplementedException();
        }

        public int getScriptVersion(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool getScriptIsOpen(string fileName)
        {
            throw new NotImplementedException();
        }

        public ByteOrderMark getScriptByteOrderMark(string fileName)
        {
            throw new NotImplementedException();
        }

        public ILanguageServicesDiagnostics getDiagnosticsObject()
        {
            throw new NotImplementedException();
        }

        public string getLocalizedDiagnosticMessages()
        {
            throw new NotImplementedException();
        }

        #region IReferenceResolverHost

        public IScriptSnapshot getScriptSnapshot(string fileName)
        {
            throw new NotImplementedException();
        }

        public string resolveRelativePath(string path, string directory)
        {
            throw new NotImplementedException();
        }

        public bool fileExists(string path)
        {
            throw new NotImplementedException();
        }

        public bool directoryExists(string path)
        {
            throw new NotImplementedException();
        }

        public string getParentDirectory(string path)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ILogger

        public bool information()
        {
            throw new NotImplementedException();
        }

        public bool debug()
        {
            throw new NotImplementedException();
        }

        public bool warning()
        {
            throw new NotImplementedException();
        }

        public bool error()
        {
            throw new NotImplementedException();
        }

        public bool fatal()
        {
            throw new NotImplementedException();
        }

        public void log(string s)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
