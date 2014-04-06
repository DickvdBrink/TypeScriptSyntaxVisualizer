using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptSyntaxVisualizer.TypeScript
{
    interface IScriptSnapshot
    {
        string getText(int start, int end);
        int getLength();
        int[] getLineStartPositions();
        //TextChangeRange
        string getTextChangeRangeSinceVersion(int scriptVersion);
    }
}