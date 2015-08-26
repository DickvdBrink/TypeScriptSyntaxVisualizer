namespace TypeScriptSyntaxVisualizer.TypeScript
{
    class CompilerOptions
    {
        public bool allowNonTsExtensions = false;
        public string charset;
        public bool declaration  = false;
        public bool emitBOM = false;
        public bool inlineSourceMap = false;
        public bool inlineSources = false;
        public JsxEmit jsx;
        public bool listFiles;
        public string locale;
        public string mapRoot = "";
        public ModuleKind module = ModuleKind.None;
        public NewLineKind newLine;
        public bool noEmit;
        public bool noEmitHelpers;
        public bool noEmitOnError;
        public bool noErrorTruncation;
        public bool noImplicitAny = false;
        public bool noLib = false;
        public bool noResolve = false;
        public string @out;
        public string outFile;
        public string outDir;
        public bool preserveConstEnums;
        public string project;
        public bool removeComments = false;
        public string rootDir;
        public bool sourceMap;
        public string sourceRoot = "";
        public bool suppressImplicitAnyIndexErrors;
        public ScriptTarget target = ScriptTarget.ES3;
        public bool version;
        public bool watch = false;
        public bool isolatedModules;
        public bool experimentalDecorators;
        public bool experimentalAsyncFunctions;
        public bool emitDecoratorMetadata;
        public ModuleResolutionKind moduleResolution;
    }
}
