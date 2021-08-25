using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BorusanLogisticsGuzergah
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Ribbon.MdiMergeStyle = RibbonMdiMergeStyle.Always; //ribbon barı masterForm ribbon üzerine aktarmak için gerekiyor.
            this.backstageViewControl1.SelectedTabIndex = 0;

            barStaticItem2.Caption = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void ribbonControl1_ApplicationButtonClick(object sender, EventArgs e)
        {
            menuWayPoints1.Ribbon = ribbonControl1;
        }

        private void xtraTabbedMdiManager1_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            e.Page.Pinned = true;
        }

        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (xtraTabbedMdiManager1.SelectedPage == null)
            {
                ribbonControl1.SelectedPage = this.Ribbon.Pages[0];
                return;
            }

            //string formCaption = xtraTabbedMdiManager1.SelectedPage.Text;
            string formName = xtraTabbedMdiManager1.SelectedPage.Text + "Form";

            //var formList = Functions.db.S_Form(-1).ToList();
            //string formName = formList.Where(c => c.FormCaption == formCaption).FirstOrDefault().FormName.ToString();

            string FormTypeFullName = string.Format("{0}.{1}", this.GetType().Namespace, formName);
            Type type = Type.GetType(FormTypeFullName, true);
            RibbonForm frm = (RibbonForm)Activator.CreateInstance(type);

            if (xtraTabbedMdiManager1.SelectedPage.MdiChild.Name == frm.Name)
            {
                ribbonControl1.SelectedPage = frm.Ribbon.Pages[0];
            }
        }
    }
}
