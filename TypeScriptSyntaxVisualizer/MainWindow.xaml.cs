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
        }

        private void OnOpenButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                string allText = File.ReadAllText(dlg.FileName);
                textEditor.Document.Text = allText;
                context.OpenFile(dlg.SafeFileName, allText);
            }
        }
    }
}
