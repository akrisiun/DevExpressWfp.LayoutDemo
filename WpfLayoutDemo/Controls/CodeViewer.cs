//using DevExpress.Xpf.DemoBase;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using DevExpress.Xpf.Editors;
using System.IO;

namespace DevExpress.Xpf.LayoutControlDemo
{
    // xmlns:local="clr-namespace:DevExpress.Xpf.LayoutControlDemo"
    // <local:CodeViewer CodePath = "Data" CurrentItem="{Binding SelectedObject.Obj}" 

    public class CodeViewer : UserControl
    {
        public FrameworkElement SelectedItem {
            get { return (FrameworkElement)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(FrameworkElement), typeof(CodeViewer), new PropertyMetadata(null));

        // 'The invocation of the constructor on type 'DevExpress.Xpf.LayoutControlDemo.CodeViewer' that matches the specified binding constraints threw an exception.' Line number '54' and line position '18'.
        public static readonly DependencyProperty CodePathProperty =
            DependencyProperty.Register("CodePath", typeof(string), typeof(CodeViewer), new PropertyMetadata(null));
        public static readonly DependencyProperty CurrentItemProperty =
            DependencyProperty.Register("CurrentItem", typeof(object), typeof(CodeViewer), new PropertyMetadata(null));

        public string CodePath {
            get { return (string)GetValue(CodePathProperty); }
            set { SetValue(CodePathProperty, value); }
        }

        public object CurrentItem {
            get { return (string)GetValue(CurrentItemProperty); }
            set { SetValue(CurrentItemProperty, value); }
        }

        // for debugging
        static CodeViewer() { }
        public CodeViewer() { }

        public DataLayout1 ParentPanel {
            [DebuggerStepThrough]
            get; set;
            //get { return this.Parent as DataLayout1; } 
        }

        public void Bind(DataLayout1 parent)
        {
            this.ParentPanel = parent;

            Instance = this;
            DataControlPageViewModel.OnChanged = Changed;
        }

        public static CodeViewer Instance { get; private set; }

        public Action<DataControlPageViewModel, DataControlPageViewModel.ObjectNamePair> Changed = (m, obj) => {

            var @this = Instance;
            var code = @this.ParentPanel.CodeEdit as TextEdit;
            code.Text = obj.ToString();

            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var sourceDir = Path.GetFullPath(baseDir + @"..\WpfLayoutDemo\Data");

            string file = obj.Path;
            if (!string.IsNullOrWhiteSpace(file) && File.Exists(Path.Combine(sourceDir, file)))
            {
                file = Path.Combine(sourceDir, file);
                try
                {
                    code.Text = $"// DevExpress v15.1 WPF demo\n// {file}\n\n{File.ReadAllText(file)}";
                } catch (Exception ex) { code.Text = $"Failed {file} : {ex.Message}"; }
            }
        };
    }
}