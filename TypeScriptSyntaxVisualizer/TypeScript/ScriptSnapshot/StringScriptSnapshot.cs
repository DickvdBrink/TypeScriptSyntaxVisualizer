using System;

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

        public TextChangeRange getChangeRange(IScriptSnapshot oldSnapshot)
        {
            throw new NotImplementedException();
        }

        public void dispose()
        {
            throw new NotImplementedException();
        }
    }
}
