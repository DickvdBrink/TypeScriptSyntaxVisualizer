using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TypeScriptSyntaxVisualizer.TypeScript.ScriptSnapshot;

namespace TypeScriptSyntaxVisualizer.TypeScript.Services
{
    class LanguageServiceHost : ILanguageServiceHost
    {
        private CompilerOptions settings;
        private Dictionary<string, ScriptInfo> scripts = new Dictionary<string, ScriptInfo>();
        private HostCancellationToken token;

        public LanguageServiceHost(CompilerOptions settings)
        {
            this.settings = settings;
            token = new HostCancellationToken();
        }

        public void RemoveFile(string filename)
        {
            this.scripts.Remove(filename);
        }

        public void OpenFile(string filename, string content)
        {
            this.scripts.Add(filename, new ScriptInfo()
            {
                Content = content,
                Filename = filename,
                IsOpen = true,
                Version = "1"
            });
        }

        #region ILanguageServiceHost

        public CompilerOptions getCompilationSettings()
        {
            return settings ?? new CompilerOptions();
        }

        public string[] getScriptFileNames()
        {
            return scripts.Keys.ToArray();
        }

        public string getScriptVersion(string fileName)
        {
            ScriptInfo info;
            if(scripts.TryGetValue(fileName, out info))
            {
                return info.Version;
            }
            throw new ArgumentException();
        }

        public string getLocalizedDiagnosticMessages()
        {
            return null;
        }

        public string getNewLine()
        {
            throw new NotImplementedException();
        }

        public string getProjectVersion()
        {
            throw new NotImplementedException();
        }

        public IScriptSnapshot getScriptSnapshot(string filename)
        {
            ScriptInfo info;
            if (scripts.TryGetValue(filename, out info))
            {
                return new StringScriptSnapshot(info.Content);
            }
            throw new ArgumentException();
        }

        public HostCancellationToken getCancellationToken()
        {
            return token;
        }

        public string getCurrentDirectory()
        {
            throw new NotImplementedException();
        }

        public string getDefaultLibFileName(CompilerOptions options)
        {
            throw new NotImplementedException();
        }

        public void log(string s)
        {
            throw new NotImplementedException();
        }

        public void trace(string s)
        {
            throw new NotImplementedException();
        }

        public void error(string s)
        {
            throw new NotImplementedException();
        }

        public bool useCaseSensitiveFileNames()
        {
            throw new NotImplementedException();
        }

        public string[] resolveModuleNames(string[] moduleNames, string containingFile)
        {
            throw new NotImplementedException();
        }

        #endregion

        private class ScriptInfo
        {
            public string Filename;
            public string Version;
            public string Content;
            public bool IsOpen;
        }
    }
}
