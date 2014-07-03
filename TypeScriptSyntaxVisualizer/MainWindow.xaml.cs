using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TypeScriptSyntaxVisualizer.Editor;
using TypeScriptSyntaxVisualizer.Model;
using TypeScriptSyntaxVisualizer.TypeScript;

namespace TypeScriptSyntaxVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TypeScriptContext context = new TypeScriptContext();

        public MainWindow()
        {
            InitializeComponent();
            astTree.ItemsSource = context.SyntaxTree;
            astTree.SelectedItemChanged += AstTree_SelectedItemChanged;

            textEditor.TextArea.Caret.PositionChanged += (_, __) =>
            {
                var caret = textEditor.TextArea.Caret;
                string labelText = string.Format("Line: {0} Col: {1} Position: {2}", caret.Line, caret.Column, caret.Offset);
                lbStatusBarCaretPosition.Content = labelText;
            };
        }

        private void AstTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var lineTransformers = textEditor.TextArea.TextView.LineTransformers;
            for (int i = lineTransformers.Count - 1; i > 0; i--)
            {
                var transformer = lineTransformers[i];
                if (transformer is OffsetColorizer)
                {
                    lineTransformers.RemoveAt(i);
                }
            }

            AstTreeItem item = e.NewValue as AstTreeItem;
            if (item != null)
            {
                if (item.Properties.ContainsKey("fullStart") && item.Properties.ContainsKey("fullEnd"))
                {
                    int start = int.Parse(item.Properties["fullStart"]);
                    int end = int.Parse(item.Properties["fullEnd"]);
                    OffsetColorizer oc = new OffsetColorizer(Brushes.Azure, start, end);
                    lineTransformers.Add(oc);
                }
            }
        }

        private void OnOpenButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                var files = context.Host.getScriptFileNames();
                // Remove all files (we only show one), so opening the same files doesn't crash.
                // When we have a multidocument interface we could make this better
                for (var i = 0; i < files.Length; i++)
                {
                    context.Host.RemoveFile(files[i]);
                }
                string allText = File.ReadAllText(dlg.FileName);
                textEditor.Document.Text = allText;
                context.OpenFile(dlg.FileName, allText);
            }
        }
    }
}
