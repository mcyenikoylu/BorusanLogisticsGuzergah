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
    public partial class ProposedRoute5Form : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ProposedRoute5Form()
        {
            InitializeComponent();
        }

        InformationLayer informationLayer = new InformationLayer();
        BingRouteDataProvider routeDataProvider = new BingRouteDataProvider();

        InformationLayer informationLayer2 = new InformationLayer();

        private void ProposedRoute5Form_Load(object sender, EventArgs e)
        {
            try
            {
                //https://docs.devexpress.com/WindowsForms/114673/controls-and-libraries/map-control/vector-data/clusterers
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
                mapControl1.ShowSearchPanel = false;

                routeDataProvider.BingKey = "Avvc7Zi1mbEsmv7IRo9TnNbP32cLralhqFq3AhC-JsaVXS_qymj9GPT8TdOynshZ";
                routeDataProvider.LayerItemsGenerating += routeLayerItemsGenerating;
                routeDataProvider.RouteOptions.Mode = BingTravelMode.Driving;
                
                informationLayer.DataProvider = routeDataProvider;
                
                searchDataProvider.SearchCompleted += OnSearchCompleted;
                informationLayer2.DataRequestCompleted += OnDataRequestCompleted;
                searchDataProvider.BingKey = "Avvc7Zi1mbEsmv7IRo9TnNbP32cLralhqFq3AhC-JsaVXS_qymj9GPT8TdOynshZ";

                informationLayer2.DataProvider = searchDataProvider;


                routeDataProvider.CalculateRoute(waypoints2);


                mapControl1.Layers.Add(informationLayer);
                mapControl1.Layers.Add(informationLayer2);

                

                textEdit1.Text = "1494. Sokak, Umurbey, alsancak, izmir";
            }
            catch (Exception ex)
            {

            }
        }

        private void routeLayerItemsGenerating(object sender, LayerItemsGeneratingEventArgs e)
        {
            if (e.Cancelled || (e.Error != null)) return;

            //char letter = '1';

            char pushpinMarker = 'A';
            foreach (MapItem item in e.Items)
            {
                MapPushpin pushpin = item as MapPushpin;
                if (pushpin != null)
                {
                    pushpin.Text = pushpinMarker++.ToString();
                }

                MapPolyline polyline = item as MapPolyline;
                if (polyline != null)
                {
                    polyline.Stroke = Color.FromArgb(0xFF, 0x00, 0x72, 0xC6);
                    polyline.StrokeWidth = 4;

                }

                //MapPushpin pushpin = item as MapPushpin;
                //if (pushpin != null)
                //    pushpin.Text = letter++.ToString();
            }
            //splashScreenManager.CloseWaitForm();
            mapControl1.ZoomToFit(e.Items, 0.4);
        }

        BingSearchDataProvider searchDataProvider = new BingSearchDataProvider();

        #region #SearchResultProcessing
        void OnSearchCompleted(object sender, BingSearchCompletedEventArgs e)
        {
            if (e.Cancelled) return;
            if (e.RequestResult.ResultCode != RequestResultCode.Success)
            {
                meResult.Text = "The Bing Search service does not work for this location.";
                return;
            }

            StringBuilder resultList = new StringBuilder("");
            int resCounter = 1;
            foreach (BingLocationInformation resultInfo in e.RequestResult.SearchResults)
            {
                resultList.Append(String.Format("Result {0}:  \r\n", resCounter));
                resultList.Append(String.Format("Name: {0}\r\n", resultInfo.DisplayName));
                resultList.Append(String.Format("Address: {0}\r\n", resultInfo.Address.FormattedAddress));
                resultList.Append(String.Format("Confidence level: {0}\r\n", resultInfo.Confidence));
                resultList.Append(String.Format("Geographic coordinates:  [{0}]\r\n", resultInfo.Location));
                resultList.Append(String.Format("Match code: {0}\r\n", resultInfo.MatchCode));
                resultList.Append(String.Format("___________________\r\n"));
                resCounter++;
            }
            meResult.Text = resultList.ToString();
        }
        #endregion #SearchResultProcessing

        void OnDataRequestCompleted(object sender, RequestCompletedEventArgs e)
        {
            mapControl1.ZoomToFitLayerItems(0.4);
        }

        private void textEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //SearchProvider.Search(teKeyword.Text);

            if(e.Button.Index == 0) //search
            {
                searchDataProvider.Search(textEdit1.Text);
            }
            else if (e.Button.Index == 1) //add
            {
                if (buttonEdit1.Text == "")
                {
                    buttonEdit1.Text = textEdit1.Text;
                    buttonEdit1.Visible = true;
                }
                else if(buttonEdit2.Text == "")
                {
                    buttonEdit2.Text = textEdit1.Text;
                    buttonEdit2.Visible = true;
                }

                string loc = meResult.Text;
                string[] locSip = loc.Split('[');
                string[] locSip2 = locSip[1].Split(']');
                string[] locSip3 = locSip2[0].Split(',');
                waypoints2.Add(new RouteWaypoint("DisplayName", new GeoPoint(Convert.ToDouble(locSip3[0]), Convert.ToDouble(locSip3[1]))));
                routeDataProvider.CalculateRoute(waypoints2);
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //deleted
            buttonEdit1.Visible = false;
            buttonEdit1.Text = "";
        }

        private void buttonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //deleted
            buttonEdit2.Visible = false;
            buttonEdit2.Text = "";
        }

        List<RouteWaypoint> waypoints2 = new List<RouteWaypoint>();
        private void mapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MapPushpin pin = new MapPushpin();
            //pin.Location = (GeoPoint)mapControl1.ScreenPointToCoordPoint(e.Location);
            //informationLayer.Data.Items.Add(pin);
            //waypoints2.Add(new RouteWaypoint("", (GeoPoint)mapControl1.ScreenPointToCoordPoint(e.Location)));

        }

        private MapPushpin mapItem;
        private void mapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            var hitInfo = mapControl1.CalcHitInfo(e.Location);
            if (hitInfo.InMapPushpin)
            {
                mapControl1.EnableScrolling = false;
                mapItem = hitInfo.HitObjects[0] as MapPushpin;
            }
        }

        private void mapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mapItem != null)
            {
                var point = mapControl1.ScreenPointToCoordPoint(new MapPoint(e.X, e.Y));
                mapItem.Location = point;
                mapControl1.EnableScrolling = true;
                mapItem = null;

                //waypoints2.Add(new RouteWaypoint("DisplayName", (GeoPoint)mapControl1.ScreenPointToCoordPoint(e.Location)));
                //routeDataProvider.CalculateRoute(waypoints2);
            }
        }

        private void mapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mapItem != null)
            {
                var point = mapControl1.ScreenPointToCoordPoint(new MapPoint(e.X, e.Y));
                mapItem.Location = point;
            }
        }
    }
}