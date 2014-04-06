using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptSyntaxVisualizer.TypeScript
{
    interface IReferenceResolverHost
    {
        IScriptSnapshot getScriptSnapshot(string fileName);
        string resolveRelativePath(string path, string directory);
        bool fileExists(string path);
        bool directoryExists(string path);
        string getParentDirectory(string path);
    }
}
