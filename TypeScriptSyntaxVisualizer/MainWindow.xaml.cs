using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        public ObservableCollection<AstTreeItem> syntaxTree = new ObservableCollection<AstTreeItem>();
        
        public MainWindow()
        {
            InitializeComponent();
            astTree.ItemsSource = this.syntaxTree;
        }

        private void OnOpenButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                string allText = File.ReadAllText(dlg.FileName);
                context.host.OpenFile(dlg.SafeFileName, allText);
                textEditor.Document.Text = allText;
                
                string tree = context.context.Run("JSON.stringify(ls.getSyntaxTree('" + dlg.SafeFileName + "'), null, 4)") as string;
                JObject treeObj = JObject.Parse(tree);
                this.syntaxTree.Clear();
                this.syntaxTree.Add(new AstTreeItem(treeObj["sourceUnit"]));
            }
        }
    }
}
