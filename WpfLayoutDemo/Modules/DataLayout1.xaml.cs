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
        public DataLayout1()
        {
            InitializeComponent();
        }

        public TextEdit CodeEdit { [DebuggerStepThrough] get; set; }
        public CodeViewer CodeViewer { [DebuggerStepThrough] get; set; }

        public void OnFinishedLoad()
        {
            CodeEdit = this.codeEdit;
            CodeViewer = this.code;
            CodeViewer.Bind(this);

            var data = this.DataContext as DataControlPageViewModel;
            if (data != null && DataControlPageViewModel.OnChanged != null)
               DataControlPageViewModel.OnChanged(data, data.SelectedObject);    // Lazy init
        }
        
        void comboEdit_SelectedIndexChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            var data = DataContext as DataControlPageViewModel;
            if (data == null) return;

            // please react finally on SelectedObject change!!
            DataControlPageViewModel.OnChanged(data, data.SelectedObject);    
        }
    }
}
