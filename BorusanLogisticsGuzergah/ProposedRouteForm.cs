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
    public partial class ProposedRouteForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ProposedRouteForm()
        {
            InitializeComponent();
        }

        private void ProposedRouteForm_Load(object sender, EventArgs e)
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
            
            routeDataProvider.BingKey = "Avvc7Zi1mbEsmv7IRo9TnNbP32cLralhqFq3AhC-JsaVXS_qymj9GPT8TdOynshZ";
            routeDataProvider.LayerItemsGenerating += routeLayerItemsGenerating;
            routeDataProvider.RouteOptions.Mode = BingTravelMode.Driving;

            informationLayer.DataProvider = routeDataProvider;
            

            mapControl1.Layers.Add(informationLayer);

            //mapControl1.MapItemClick += OnMapItemClick;

            //ToolTipController toolTipController = new ToolTipController();
            //toolTipController.BeforeShow += OnBeforeShowToolTip;
            //mapControl1.ToolTipController = toolTipController;

            //// Create a layer to show vector items.
            //VectorItemsLayer itemsLayer = new VectorItemsLayer()
            //{
            //    Data = CreateData(),
            //    Colorizer = CreateColorizer(),
            //    ToolTipPattern = "{NAME}: ${GDP_MD_EST:#,0}M" // "%A0%: %V0%\r\n %A1%: %V1%\r\n %A2%: %V2%"
            //};

            //mapControl1.Layers.Add(itemsLayer);

            //// Show a color legend.
            //mapControl1.Legends.Add(new ColorListLegend() { Layer = itemsLayer });

            //BingRouteDataProvider routeDataProvider = new BingRouteDataProvider
            //{

            //};




            // Create three waypoints and add them to the route waypoints list.
            //List<RouteWaypoint> waypoints = new List<RouteWaypoint>();
          

            waypoints2.Add(new RouteWaypoint("Tpi2", new GeoPoint(38.7341797846321, 26.9524066991532)));
            waypoints2.Add(new RouteWaypoint("Istanbul", new GeoPoint(39.5502543286998, 27.0893281049455)));
            waypoints2.Add(new RouteWaypoint("Izmir", new GeoPoint(39.6428451147536, 27.7201506120507)));
            waypoints2.Add(new RouteWaypoint("Bodrum", new GeoPoint(39.9859976512948, 28.1739539653036)));
            waypoints2.Add(new RouteWaypoint("Tpi2", new GeoPoint(40.3392669924001, 27.9652061190535)));
            waypoints2.Add(new RouteWaypoint("Istanbul", new GeoPoint(40.2376000046944, 27.2409117326709)));
            waypoints2.Add(new RouteWaypoint("Izmir", new GeoPoint(40.3659641070493, 26.7058301600364)));
            waypoints2.Add(new RouteWaypoint("Bodrum", new GeoPoint(39.4957370096703, 26.3443925771729)));
            //waypoints2.Add(new RouteWaypoint("Tpi2", new GeoPoint(38.734179, 26.952406)));
            //waypoints2.Add(new RouteWaypoint("Istanbul", new GeoPoint(39.550254, 27.089328)));

           

            //// Call the BingRouteDataProvider.CalculateRoute method.
            routeDataProvider.CalculateRoute(waypoints2);
            //itemStorage.Items.Add(new MapLine() { Point1 = waypoints2[0].Location,
            //Point2 = waypoints2[0].Location,
            //    Stroke = Color.Red,
            //    StrokeWidth = 3
            //});

            ////routeDataProvider.CalculateRoutesFromMajorRoads(
            ////    new RouteWaypoint(description, new GeoPoint(38.6598746619533, 27.2211825614595))
            ////);
            //routeDataProvider.CalculateRoutesFromMajorRoads(new RouteWaypoint("Bergama", new GeoPoint(38.6598746619533, 27.0801503416066)));


            //mapControl1.Layers.Add(new InformationLayer
            //{
            //    DataProvider = routeDataProvider

            //});
        }

        BingRouteDataProvider routeDataProvider = new BingRouteDataProvider();        
        string description = "Route Waypoint";
        double lat;
        double lon;

        InformationLayer informationLayer = new InformationLayer();


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

        private void btnRun_Click(object sender, EventArgs e)
        {
            lat = Convert.ToDouble(txtStart.Text);
            lon = Convert.ToDouble(txtEnd.Text);
            routeDataProvider.CalculateRoutesFromMajorRoads(
                new RouteWaypoint(description, new GeoPoint(lat, lon))
            );
        }

        //private IMapDataAdapter CreateData()
        //{
        //    MapItemStorage storage = new MapItemStorage();

        //    // Add Bubble charts with different values, sizes and 
        //    // locations to the storage's Items collection.
        //    storage.Items.Add(new MapBubble()
        //    {
        //        Argument = "A",
        //        Value = 200,
        //        Location = new GeoPoint(38.4780526, 27.1880704),
        //        Size = 10,
        //        Group = 1,
        //        MarkerType = MarkerType.Diamond
        //    });
        //    storage.Items.Add(new MapBubble()
        //    {
        //        Argument = "B",
        //        Value = 400,
        //        Location = new GeoPoint(38.4811434, 27.1681577),
        //        Size = 10,
        //        Group = 2,
        //        MarkerType = MarkerType.Plus
        //    });
        //    storage.Items.Add(new MapBubble()
        //    {
        //        Argument = "C",
        //        Value = 800,
        //        Location = new GeoPoint(38.4814793, 27.153824),
        //        Size = 10,
        //        Group = 1,
        //        MarkerType = MarkerType.Cross
        //    });
        //    storage.Items.Add(new MapBubble()
        //    {
        //        Argument = "D",
        //        Value = 800,
        //        Location = new GeoPoint(38.48588, 27.1356279),
        //        Size = 10,
        //        Group = 3,
        //        MarkerType = MarkerType.Circle
        //    });

        //    return storage;
        //}

        //private MapColorizer CreateColorizer()
        //{
        //    KeyColorColorizer colorizer = new KeyColorColorizer();

        //    // Add colors to the colorizer.
        //    colorizer.Colors.Add(Color.Coral);
        //    colorizer.Colors.Add(Color.Orange);
        //    colorizer.Colors.Add(Color.LightBlue);
        //    colorizer.Colors.Add(Color.OrangeRed);

        //    colorizer.Keys.Add(new ColorizerKeyItem() { Key = "A", Name = "Category A" });
        //    colorizer.Keys.Add(new ColorizerKeyItem() { Key = "B", Name = "Category B" });
        //    colorizer.Keys.Add(new ColorizerKeyItem() { Key = "C", Name = "Category C" });
        //    colorizer.Keys.Add(new ColorizerKeyItem() { Key = "D", Name = "Category D" });

        //    // Load color indexes from bubbles via the 'Color' attribute
        //    colorizer.ItemKeyProvider = new ArgumentItemKeyProvider();

        //    return colorizer;
        //}

        private void mapControl1_MapItemClick(object sender, MapItemClickEventArgs e)
        {
            if (e.MouseArgs.Button == MouseButtons.Right)
            {
                if (e.Item is MapPushpin)
                {
                    MapPushpin pin = (MapPushpin)e.Item;
                    //GeoPoint geoPoint = new GeoPoint(pin.Location.GetY(), pin.Location.GetX());

                    RouteWaypoint routePoint = new RouteWaypoint(pin.Text, (GeoPoint)pin.Location);
                    //MapPoint point = new MapPoint(routePoint.Location.Latitude, routePoint.Location.Longitude);
                    //GeoPoint geoPoint2 = (GeoPoint)mapControl1.ScreenPointToCoordPoint(point);

                    //RouteWaypoint point = new RouteWaypoint("", (GeoPoint)pin.Location);
                    //waypoints2.Remove(routePoint);

                    //GeoPoint location = (GeoPoint)mapControl1.ScreenPointToCoordPoint(e.MouseArgs.Location);
                    //RouteWaypoint routePoint = new RouteWaypoint("", location);

                    waypoints2.Remove(routePoint);

                   // informationLayer.Data.Items.RemoveAt(1);
                   routeDataProvider.CalculateRoute(waypoints2);

                    //MessageBox.Show(pin.Location.ToString());

                    //if (pin != null)
                    //    pin.Visible = false;

                    //routeDataProvider.LayerItemsGenerating += routeLayerItemsGenerating;
                    //mapControl1.Layers.Add(new InformationLayer
                    //{
                    //    DataProvider = routeDataProvider
                    //});

                }
            }

            //if (e.Item is MapPushpin)
            //{
            //    MapPushpin pin = (MapPushpin)e.Item;
            //    RouteWaypoint routePoint = new RouteWaypoint("", (GeoPoint)pin.Location);
            //    MapPoint point = new MapPoint(routePoint.Location.Latitude, routePoint.Location.Longitude);
            //    waypoints2.Add(new RouteWaypoint("", (GeoPoint)mapControl1.ScreenPointToCoordPoint(point)));
            //    routeDataProvider.CalculateRoute(waypoints2);
            //}






        }

        List<RouteWaypoint> waypoints2 = new List<RouteWaypoint>();
        private void mapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            ////GeoPoint location = (GeoPoint)mapControl1.ScreenPointToCoordPoint(e.Location);
            //////TextEdit1.Text = string.Format("{0} - {1}", location.Latitude, location.Longitude);
            //////storage.Items.Add(new MapCallout() { Text = "Loc", Location = location });
            ////string Latitude = location.Latitude.ToString();
            ////string Longitude = location.Longitude.ToString();

            ////lat = location.Latitude;
            ////lon = location.Longitude;

            ////routeDataProvider.CalculateRoutesFromMajorRoads(
            ////    new RouteWaypoint(description, new GeoPoint(lat, lon))
            ////);

            //if (e.Button == MouseButtons.Right)
            //{
            //    waypoints2.Add(new RouteWaypoint("", (GeoPoint)mapControl1.ScreenPointToCoordPoint(e.Location)));
            //    routeDataProvider.CalculateRoute(waypoints2);
            //}
            ////routeDataProvider.LayerItemsGenerating += routeLayerItemsGenerating;

            ////mapControl1.Layers.Add(new InformationLayer
            ////{
            ////    DataProvider = routeDataProvider,
            ////});
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
         
            routeDataProvider.CalculateRoute(waypoints2);
            informationLayer.DataRequestCompleted += informationLayer2_DataRequestCompleted;

        }
        private void informationLayer2_DataRequestCompleted(object sender, RequestCompletedEventArgs e)
        {
            //var polyline = informationLayer.Data.Items.OfType<MapPolyline>().FirstOrDefault();
            //points = polyline.Points.Cast<GeoPoint>().ToList();
            //pushpin = new MapPushpin() { Location = points[0] };
            MapPushpin pin = new MapPushpin();
            pin.Location = (GeoPoint)waypoints2[0].Location;
            itemStorage.Items.Add(pin);
            timer1.Enabled = true;
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (waypoints2.Count == 0)
            {
                waypoints2.Add(new RouteWaypoint("Tpi2", new GeoPoint(38.7341797846321, 26.9524066991532)));
                waypoints2.Add(new RouteWaypoint("Istanbul", new GeoPoint(39.5502543286998, 27.0893281049455)));
                waypoints2.Add(new RouteWaypoint("Izmir", new GeoPoint(39.6428451147536, 27.7201506120507)));
                waypoints2.Add(new RouteWaypoint("Bodrum", new GeoPoint(39.9859976512948, 28.1739539653036)));
                waypoints2.Add(new RouteWaypoint("Tpi2", new GeoPoint(40.3392669924001, 27.9652061190535)));
                waypoints2.Add(new RouteWaypoint("Istanbul", new GeoPoint(40.2376000046944, 27.2409117326709)));
                waypoints2.Add(new RouteWaypoint("Izmir", new GeoPoint(40.3659641070493, 26.7058301600364)));
                waypoints2.Add(new RouteWaypoint("Bodrum", new GeoPoint(39.4957370096703, 26.3443925771729)));

            }

            routeDataProvider.CalculateRoute(waypoints2);

            //routeDataProvider.LayerItemsGenerating += routeLayerItemsGenerating;

            //mapControl1.Layers.Add(new InformationLayer
            //{
            //    DataProvider = routeDataProvider

            //});
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            waypoints2.Clear();
            if (informationLayer != null)
                informationLayer.Data.Items.Clear();

            //VectorItemsLayer layer = (VectorItemsLayer)this.mapControl1.Layers[0];
            //((MapItemStorage)layer.Data).Items.Clear();
        }

        private void mapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (waypoints2.Count > 0)
            {
                informationLayer.Data.Items.Clear();
                waypoints2.Add(new RouteWaypoint("", (GeoPoint)mapControl1.ScreenPointToCoordPoint(e.Location)));
                routeDataProvider.CalculateRoute(waypoints2);
            }
            else
            {
                //GeoPoint geoPoint = (GeoPoint)mapControl1.ScreenPointToCoordPoint(e.Location);
                //routeDataProvider.CalculateRoutesFromMajorRoads(
                //    new RouteWaypoint(description, geoPoint)
                //);
                MapPushpin pin = new MapPushpin();
                pin.Location = (GeoPoint)mapControl1.ScreenPointToCoordPoint(e.Location);
                informationLayer.Data.Items.Add(pin);
                waypoints2.Add(new RouteWaypoint("", (GeoPoint)mapControl1.ScreenPointToCoordPoint(e.Location)));
                
            }
        }

        int i = 0;
        List<GeoPoint> points;
        MapPushpin pushpin;
        MapItemStorage itemStorage;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i + 1 < points.Count)
            {
                itemStorage.Items.BeginUpdate();
                itemStorage.Items.Add(new MapLine() { Point1 = points[i], Point2 = points[i + 1], Stroke = Color.Red, StrokeWidth = 3 });
                pushpin.Location = points[i + 1];
                itemStorage.Items.EndUpdate();
                i++;
            }
        }
    }
}