using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptSyntaxVisualizer.TypeScript.ScriptSnapshot
{
    class StringScriptSnapshot : IScriptSnapshot
    {
        private string text;

        public StringScriptSnapshot(string text)
        {
            this.text = text;
        }

        public string getText(int start, int end)
        {
            return text.Substring(start, end - start);
        }

        public int getLength()
        {
            return this.text.Length;
        }

        public int[] getLineStartPositions()
        {
            throw new NotImplementedException();
        }

        public string getTextChangeRangeSinceVersion(int scriptVersion)
        {
            throw new NotImplementedException();
        }
    }
}
