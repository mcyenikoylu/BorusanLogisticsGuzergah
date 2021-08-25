using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraMap;

namespace BorusanLogisticsGuzergah
{
    public partial class WaypointForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public WaypointForm()
        {
            InitializeComponent();
        }

        private void WaypointForm_Load(object sender, EventArgs e)
        {
            mapControl1.Layers.Add(new ImageLayer()
            {
                DataProvider = new BingMapDataProvider()
                {
                    //https://www.bingmapsportal.com/Application#
                    BingKey = "Avvc7Zi1mbEsmv7IRo9TnNbP32cLralhqFq3AhC-JsaVXS_qymj9GPT8TdOynshZ",
                    Kind = BingMapKind.Road
                }
            });
        }
    }
}