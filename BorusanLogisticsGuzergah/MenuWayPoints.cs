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

namespace BorusanLogisticsGuzergah
{
    public partial class MenuWayPoints : DevExpress.XtraEditors.XtraUserControl
    {
        List<Size> sizes;
        private DevExpress.XtraBars.Ribbon.RibbonControl _Ribbon;
        public DevExpress.XtraBars.Ribbon.RibbonControl Ribbon
        {
            get
            {
                return _Ribbon;
            }
            set
            {
                _Ribbon = value;
            }
        }

        public MenuWayPoints()
        {
            InitializeComponent();

            sizes = new List<System.Drawing.Size>();
            sizes.Add(new Size(48, 48));
            sizes.Add(new Size(32, 32));
            sizes.Add(new Size(24, 24));
            sizes.Add(new Size(16, 16));
            SizeChanged += new EventHandler(XtraUserControl1_SizeChanged);
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

        private void galleryControl1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {

        }
    }
}
