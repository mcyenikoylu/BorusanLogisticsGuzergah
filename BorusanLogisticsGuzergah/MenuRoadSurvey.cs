using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTabbedMdi;

namespace BorusanLogisticsGuzergah
{
    public partial class MenuRoadSurvey : DevExpress.XtraEditors.XtraUserControl
    {
        List<Size> sizes;
        public MenuRoadSurvey()
        {
            InitializeComponent();

            sizes = new List<System.Drawing.Size>();
            sizes.Add(new Size(48, 48));
            sizes.Add(new Size(32, 32));
            sizes.Add(new Size(24, 24));
            sizes.Add(new Size(16, 16));
            SizeChanged += new EventHandler(XtraUserControl1_SizeChanged);
        }

        private void galleryControl1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            BackstageViewControl bvc = Parent.Parent as BackstageViewControl;
            bvc.Ribbon.HideApplicationButtonContentControl();

            int value = Convert.ToInt32(e.Item.Value);
            if (value == 200)
            {
                ProposedRouteForm frm = new ProposedRouteForm();
                ButtonItemClickMethod(frm, 0);
            }
            else if (value == 201)
            {
                ProposedRoute2Form frm = new ProposedRoute2Form();
                ButtonItemClickMethod(frm, 0);
            }
            else if (value == 202)
            {
                ProposedRoute3Form frm = new ProposedRoute3Form();
                ButtonItemClickMethod(frm, 0);
            }
            else if (value == 203)
            {
                ProposedRoute5Form frm = new ProposedRoute5Form();
                ButtonItemClickMethod(frm, 0);
            }
        }

        void XtraUserControl1_SizeChanged(object sender, EventArgs e)
        {
            Size size = Size.Empty;
            if (Width > 600)
                size = sizes[1];
            if (Width <= 600 && Width > 400)
                size = sizes[1];
            if (Width <= 400 && Width > 200)
                size = sizes[2];
            if (Width <= 200)
                size = sizes[3];
            galleryControl1.Gallery.ImageSize = size;
        }

        private void ButtonItemClickMethod(RibbonForm frm, int RibbonPages)
        {
            try
            {
                RibbonForm f = FormFind(frm.Name);
                if (mdiFormOpened(f))
                {
                    XtraMdiTabPage page = FindPageByText(f.Text);
                    xtraTabbedMdiManager1.SelectedPage = page;
                    f.Ribbon.HideApplicationButtonContentControl();
                    return;
                }
                f.Ribbon.HideApplicationButtonContentControl();
                f.Ribbon.MdiMergeStyle = RibbonMdiMergeStyle.Always;
                f.MdiParent = Form1.ActiveForm;
                f.Show();
                f.Ribbon.SelectedPage = f.Ribbon.Pages[RibbonPages];
            }
            catch (Exception Ex)
            {

            }
        }

        private RibbonForm FormFind(string FormName)
        {
            try
            {
                if (FormName == "") return null;
                string FormTypeFullName = string.Format("{0}.{1}", this.GetType().Namespace, FormName);
                Type type = Type.GetType(FormTypeFullName, true);
                RibbonForm frm = (RibbonForm)Activator.CreateInstance(type);
                return frm;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        private bool mdiFormOpened(RibbonForm frm)
        {
            try
            {
                Form OpenForms = Application.OpenForms[frm.Name];
                if (OpenForms == null)
                    return false;
                else
                    return true;
            }
            catch (Exception Ex)
            {
                return true;
            }
        }

        private XtraMdiTabPage FindPageByText(string pageText)
        {
            foreach (XtraMdiTabPage page in xtraTabbedMdiManager1.Pages)
            {
                if (page.MdiChild.Text == pageText)
                    return page;
            }
            return null;
        }





    }
}
