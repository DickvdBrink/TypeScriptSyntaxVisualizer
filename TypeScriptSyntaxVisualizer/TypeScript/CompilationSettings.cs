namespace TypeScriptSyntaxVisualizer.TypeScript
{
    class CompilationSettings
    {
        public bool propagateEnumConstants = false;
        public bool removeComments = false;
        public bool watch = false;
        public bool noResolve = false;
        public bool allowAutomaticSemicolonInsertion = true;
        public bool noImplicitAny = false;
        public bool noLib = false;
        public LanguageVersion codeGenTarget = LanguageVersion.EcmaScript3;
        public ModuleGenTarget moduleGenTarget = ModuleGenTarget.Unspecified;
        public string outFileOption = "";
        public string outDirOption = "";
        public bool mapSourceFiles = false;
        public string mapRoot = "";
        public string sourceRoot = "";
        public bool generateDeclarationFiles = false;
        public bool useCaseSensitiveFileResolution = false;
        public bool gatherDiagnostics = false;
        public int? codepage = null;
        public bool createFileLog = false;
    }
}
