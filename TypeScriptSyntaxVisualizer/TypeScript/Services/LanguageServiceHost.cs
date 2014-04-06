using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptSyntaxVisualizer.TypeScript.Services
{
    class LanguageServiceHost : ILanguageServiceHost
    {
        private CompilationSettings settings;
        private Dictionary<string, ScriptInfo> scripts = new Dictionary<string, ScriptInfo>();
        private ILogger logger;

        public LanguageServiceHost(ILogger logger)
        {
            this.logger = logger;
        }

        public LanguageServiceHost(CompilationSettings settings, ILogger logger)
            : this(logger)
        {
            this.settings = settings;
        }

        public void RemoveFile(string filename)
        {
            this.scripts.Remove(filename);
        }

        public void OpenFile(string filename, string content)
        {
            this.scripts.Add(filename, new ScriptInfo()
            {
                ByteOrderMark = ByteOrderMark.None,
                Content = content,
                Filename = filename,
                IsOpen = true,
                Version = 1
            });
        }

        #region ILanguageServiceHost

        public CompilationSettings getCompilationSettings()
        {
            return settings ?? new CompilationSettings();
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
                return info.Version;
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
            return null;
        }

        #endregion

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
            return File.Exists(path);
        }

        public bool directoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public string getParentDirectory(string path)
        {
            return Directory.GetParent(path).FullName;
        }

        #endregion

        #region ILogger

        public bool information()
        {
            return logger.information();
        }

        public bool debug()
        {
            return logger.debug();
        }

        public bool warning()
        {
            return logger.warning();
        }

        public bool error()
        {
            return logger.error();
        }

        public bool fatal()
        {
            return logger.fatal();
        }

        public void log(string s)
        {
            logger.log(s);
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
