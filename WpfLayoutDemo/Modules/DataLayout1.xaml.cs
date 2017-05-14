//using DevExpress.Xpf.DemoBase;
using System.Windows.Controls;
using System.Diagnostics;
using DevExpress.Xpf.Editors;

namespace DevExpress.Xpf.LayoutControlDemo
{
    /*
        // DevExpress.Xpf.LayoutControlDemo.DataLayout1
        //DevExpress.Xpf.DemoBase.DemoModule

       <dxdb:DemoModule
        xmlns:dxdb= "http://schemas.devexpress.com/winfx/2008/xaml/demobase"
        x:Class= "DevExpress.Xpf.LayoutControlDemo.DataLayout1"
    */

    public partial class DataLayout1 : UserControl
    {
        public const string UriPrefix = "/LayoutControlDemo;component";

        public DataLayout1()
        {
            // Debugger.Break();
            // 'Provide value on 'System.Windows.StaticResourceExtension' threw an exception.' Line number '45' and line position '107'.

            InitializeComponent();
        }

        public void OnFinishedLoad()
        {
            this.CodeEdit = this.codeEdit;
            this.CodeViewer = this.code;

            CodeViewer.Bind(this);
            this.DataContextChanged += this.DataLayout1_DataContextChanged;

            var data = this.DataContext as DataControlPageViewModel;
            if (data != null && DataControlPageViewModel.OnChanged != null)
               DataControlPageViewModel.OnChanged(data, data.SelectedObject);    // Lazy init
        }

        private void DataLayout1_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            // TODO

            var prop = this.DataContext as controlProperties;
        }

        public TextEdit CodeEdit {
            [DebuggerStepThrough]
            get; set;
        }
        public CodeViewer CodeViewer {
            [DebuggerStepThrough]
            get; set;
        }

    }
}
