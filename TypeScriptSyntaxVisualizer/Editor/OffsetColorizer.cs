using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TypeScriptSyntaxVisualizer.Editor
{
    public class OffsetColorizer : DocumentColorizingTransformer
    {

        public Brush Brush { get; private set; }
        public int StartOffset { get; private set; }
        public int EndOffset { get; private set; }

        public OffsetColorizer(Brush brush, int start, int end)
        {
            this.Brush = brush;
            this.StartOffset = start;
            this.EndOffset = end;
        }

        protected override void ColorizeLine(DocumentLine line)
        {
            if (line.Length == 0)
                return;

            if (StartOffset > line.EndOffset || EndOffset < line.Offset)
                return;

            int start = line.Offset > StartOffset ? line.Offset : StartOffset;
            int end = EndOffset > line.EndOffset ? line.EndOffset : EndOffset;

            ChangeLinePart(start, end, element => element.TextRunProperties.SetBackgroundBrush(this.Brush));
        }

    }
}
