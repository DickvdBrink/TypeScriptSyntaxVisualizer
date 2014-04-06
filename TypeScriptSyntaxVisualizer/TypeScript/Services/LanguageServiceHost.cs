using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptSyntaxVisualizer.TypeScript.Services
{
    class LanguageServiceHost : ILanguageServiceHost
    {
        Dictionary<string, ScriptInfo> scripts = new Dictionary<string, ScriptInfo>();

        public CompilationSettings getCompilationSettings()
        {
            throw new NotImplementedException();
        }

        public string[] getScriptFileNames()
        {
            return scripts.Keys.ToArray();
        }

        public int getScriptVersion(string fileName)
        {
            ScriptInfo info;
            if(scripts.TryGetValue(fileName, out info))
            {
                return info.Version ;
            }
            throw new ArgumentException();
        }

        public bool getScriptIsOpen(string fileName)
        {
            ScriptInfo info;
            if (scripts.TryGetValue(fileName, out info))
            {
                return info.IsOpen;
            }
            throw new ArgumentException();
        }

        public ByteOrderMark getScriptByteOrderMark(string fileName)
        {
            ScriptInfo info;
            if (scripts.TryGetValue(fileName, out info))
            {
                return info.ByteOrderMark;
            }
            throw new ArgumentException();
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

        private class ScriptInfo
        {
            public string Filename;
            public int Version;
            public string Content;
            public ByteOrderMark ByteOrderMark;
            public bool IsOpen;
        }
    }
}
