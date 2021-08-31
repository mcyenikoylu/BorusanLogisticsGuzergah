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
using DevExpress.Utils;
using System.Data.SqlClient;

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
            mapControl1.ZoomLevel = 6.0;
            mapControl1.CenterPoint = new GeoPoint(39, 36);
            mapControl1.MapItemClick += OnMapItemClick;

            ToolTipController toolTipController = new ToolTipController();
            toolTipController.BeforeShow += OnBeforeShowToolTip;
            mapControl1.ToolTipController = toolTipController;

            // Create a layer to show vector items.
            VectorItemsLayer itemsLayer = new VectorItemsLayer() {
                Data = CreateData(),
                Colorizer = CreateColorizer(),
                ToolTipPattern = "{NAME}: ${GDP_MD_EST:#,0}M" // "%A0%: %V0%\r\n %A1%: %V1%\r\n %A2%: %V2%"
            };

            mapControl1.Layers.Add(itemsLayer);

            // Show a color legend.
            mapControl1.Legends.Add(new ColorListLegend() { Layer = itemsLayer });

            
        }

        private void OnBeforeShowToolTip(object sender, ToolTipControllerShowEventArgs e)
        {
            if (!(e.SelectedObject is MapPie mapPie)) return;
            e.Title = mapPie.Argument.ToString();
            e.ToolTip = BuildSegmentsTooltip(mapPie.Segments);
        }

        private string BuildSegmentsTooltip(PieSegmentCollection segments)
        {
            if (segments.Count == 0) return String.Empty;
            var segment = segments[0];
            var builder = new StringBuilder()
                .Append(segment.Argument)
                .Append(": ")
                .Append(segment.Value);
            for (int i = 1; i < segments.Count; i++)
            {
                segment = segments[i];
                builder.Append(Environment.NewLine)
                       .Append(segment.Argument)
                       .Append(": ")
                       .Append(segment.Value);
            }
            return builder.ToString();
        }

        public static SqlConnection dbLocal = new SqlConnection();
        public static string LocalDataSource = "(LocalDb)\\MSSQLLocalDB";
        public static string LocalDatabase = "BLGDB";
        public static string LocalAttachDbFilename = "|DataDirectory|\\BLGDB.mdf";
        private void OnMapItemClick(object sender, MapItemClickEventArgs e)
        {
            //if (e.MouseArgs.Button == MouseButtons.Right && e.Item is MapPath)
            //{
            //    popupMenu1.ShowPopup(Cursor.Position);
            //}

            string latitude = ((DevExpress.XtraMap.GeoPoint)((DevExpress.XtraMap.MapBubble)e.Item).Location).Latitude.ToString();
            string longitude = ((DevExpress.XtraMap.GeoPoint)((DevExpress.XtraMap.MapBubble)e.Item).Location).Longitude.ToString();
            //popupMenu1.ShowPopup(Cursor.Position);
            //MessageBox.Show("latitude: "+ latitude + " longitude: "+ longitude);

            BubbleForm frm = new BubbleForm(latitude, longitude);
            frm.ShowDialog();



        }

        public static bool ConnDBLocal(bool Connection)
        {
            try
            {
                if (Connection)
                {
                    string conn = "data source=" + LocalDataSource + ";AttachDbFilename=" + LocalAttachDbFilename + ";Initial Catalog=" + LocalDatabase + ";Integrated Security=True;";
                    dbLocal.ConnectionString = conn;
                    dbLocal.Open();
                    return true;
                }
                else
                {
                    dbLocal.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //ExceptionMessage = ex.Message;
                return false;
            }
        }

        #region #CreateBubbles
        // Create a storage to provide data for the vector layer.
        private IMapDataAdapter CreateData()
        {
            MapItemStorage storage = new MapItemStorage();

            // Add Bubble charts with different values, sizes and 
            // locations to the storage's Items collection.
            storage.Items.Add(new MapBubble()
            {
                Argument = "A",
                Value = 200,
                Location = new GeoPoint(38.4780526, 27.1880704),
                Size = 10,
                Group = 1,
                MarkerType = MarkerType.Diamond
            });
            storage.Items.Add(new MapBubble()
            {
                Argument = "B",
                Value = 400,
                Location = new GeoPoint(38.4811434, 27.1681577),
                Size = 10,
                Group = 2,
                MarkerType = MarkerType.Plus
            });
            storage.Items.Add(new MapBubble()
            {
                Argument = "C",
                Value = 800,
                Location = new GeoPoint(38.4814793, 27.153824),
                Size = 10,
                Group = 1,
                MarkerType = MarkerType.Cross
            });
            storage.Items.Add(new MapBubble()
            {
                Argument = "D",
                Value = 800,
                Location = new GeoPoint(38.48588, 27.1356279),
                Size = 10,
                Group = 3,
                MarkerType = MarkerType.Circle
            });

            return storage;
        }
        #endregion #CreateBubbles

        // Create a colorizer to provide colors for bubble items.    
        private MapColorizer CreateColorizer()
        {
            KeyColorColorizer colorizer = new KeyColorColorizer();

            // Add colors to the colorizer.
            colorizer.Colors.Add(Color.Coral);
            colorizer.Colors.Add(Color.Orange);
            colorizer.Colors.Add(Color.LightBlue);
            colorizer.Colors.Add(Color.OrangeRed);

            colorizer.Keys.Add(new ColorizerKeyItem() { Key = "A", Name = "Category A" });
            colorizer.Keys.Add(new ColorizerKeyItem() { Key = "B", Name = "Category B" });
            colorizer.Keys.Add(new ColorizerKeyItem() { Key = "C", Name = "Category C" });
            colorizer.Keys.Add(new ColorizerKeyItem() { Key = "D", Name = "Category D" });

            // Load color indexes from bubbles via the 'Color' attribute
            colorizer.ItemKeyProvider = new ArgumentItemKeyProvider();

            return colorizer;
        }

    }
}