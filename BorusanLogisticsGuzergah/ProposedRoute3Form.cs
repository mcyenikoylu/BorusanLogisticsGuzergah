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
    public partial class ProposedRoute3Form : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ProposedRoute3Form()
        {
            InitializeComponent();
        }
        const string airportAddress = "Los Angeles International Airport LAX";
        const string devExpressAddress = "505 N. Brand Blvd, Glendale CA 91203, USA";
        const string santaMonicaAddress = "380 Santa Monica Pier, Santa Monica, CA 90401";
        const string longBeachAddress = "236 W Shoreline Dr, Long Beach, CA 90802";
        const string beverlyHillsAddress = "9666 Sunset Blvd, Beverly Hills, CA 90210";
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //bingSearchDataProvider1.Search(devExpressAddress);
            bingRouteDataProvider1.CalculateRoute(
                   new RouteWaypoint[] {
                    new RouteWaypoint("Tpi2", new GeoPoint(38.7341797846321, 26.9524066991532)),
                    new RouteWaypoint("Istanbul", new GeoPoint(39.5502543286998, 27.0893281049455)),
                    new RouteWaypoint("Izmir", new GeoPoint(39.6428451147536, 27.7201506120507)),
                    new RouteWaypoint("Bodrum", new GeoPoint(39.9859976512948, 28.1739539653036)),
                    new RouteWaypoint("Tpi2", new GeoPoint(40.3392669924001, 27.9652061190535))
                    }.ToList());
        }
        List<GeoPoint> points;
        MapPushpin pushpin;
        private void bingRouteDataProvider1_RouteCalculated(object sender, BingRouteCalculatedEventArgs e)
        {


        }

        private void bingRouteDataProvider1_LayerItemsGenerating(object sender, LayerItemsGeneratingEventArgs e)
        {
            mapControl1.ZoomToFit(e.Items);
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i + 1 < points.Count)
            {
                mapItemStorage1.Items.BeginUpdate();
                mapItemStorage1.Items.Add(new MapLine()
                {
                    Point1 = points[i],
                    Point2 = points[i + 1],
                    Stroke = Color.Red,
                    StrokeWidth = 3
                });
                pushpin.Location = points[i + 1];
                mapItemStorage1.Items.EndUpdate();
                i++;
            }
        }
        private void informationLayer2_DataRequestCompleted(object sender, RequestCompletedEventArgs e)
        {
            var polyline = informationLayer2.Data.Items.OfType<MapPolyline>().FirstOrDefault();
            points = polyline.Points.Cast<GeoPoint>().ToList();
            pushpin = new MapPushpin() { Location = points[0] };
            mapItemStorage1.Items.Add(pushpin);
            timer1.Enabled = true;
        }

        private void ProposedRoute3Form_Load(object sender, EventArgs e)
        {

        }
    }
}