using DevExpress.Xpf.Core;
using DevExpress.Xpf.LayoutControlDemo;
using System;

namespace LayoutControlDemo.Modules
{
    public partial class Window1 : DXWindow
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var lay = this.Content;
            var demo = this.demo1 as DataLayout1;
            demo.OnFinishedLoad();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
        }
    }
}

