namespace TypeScriptSyntaxVisualizer.TypeScript
{
    class NullLogger : ILogger
    {
        public bool information()
        {
            return false;
        }

        public bool debug()
        {
            return false;
        }

        public bool warning()
        {
            return false;
        }

        public bool error()
        {
            return false;
        }

        public bool fatal()
        {
            return false;
        }

        public void log(string s)
        {
        }
    }
}
