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
using TypeScriptSyntaxVisualizer.Editor;
using TypeScriptSyntaxVisualizer.Model;
using TypeScriptSyntaxVisualizer.TypeScript;

namespace TypeScriptSyntaxVisualizer
{
    /// <summary>
    /// Interaction logic for Mai   nWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TypeScriptContext context = new TypeScriptContext();

        public MainWindow()
        {
            InitializeComponent();
            astTree.ItemsSource = context.SyntaxTree;
            astTree.SelectedItemChanged += AstTree_SelectedItemChanged;
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
                if (item.Properties.ContainsKey("start") && item.Properties.ContainsKey("end"))
                {
                    int start = int.Parse(item.Properties["start"]);
                    int end = int.Parse(item.Properties["end"]);
                    OffsetColorizer oc = new OffsetColorizer(start, end);
                    lineTransformers.Add(oc);
                }
            }
        }

        private void OnOpenButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                string allText = File.ReadAllText(dlg.FileName);
                textEditor.Document.Text = allText;
                context.OpenFile(dlg.FileName, allText);
            }
        }
    }
}
