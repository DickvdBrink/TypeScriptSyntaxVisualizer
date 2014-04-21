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

        public int StartOffset { get; set; }
        public int EndOffset { get; set; }

        public OffsetColorizer(int start, int end)
        {
            this.StartOffset = start;
            this.EndOffset = end;
        }
        protected override void ColorizeLine(DocumentLine line)
        {
            if (line.Length == 0)
                return;

            if (line.Offset < StartOffset || line.Offset > EndOffset)
                return;

            int start = line.Offset > StartOffset ? line.Offset : StartOffset;
            int end = EndOffset > line.EndOffset ? line.EndOffset : EndOffset;

            ChangeLinePart(start, end, element => element.TextRunProperties.SetBackgroundBrush(Brushes.Azure));
        }
    }
}
