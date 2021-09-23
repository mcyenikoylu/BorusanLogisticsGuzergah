using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace BorusanLogisticsGuzergah
{
    public partial class BubbleForm : DevExpress.XtraEditors.XtraForm
    {
        string _latitude;
        string _longitude;
        public BubbleForm(string latitude, string longitude)
        {
            InitializeComponent();
            _latitude = latitude;
            _longitude = longitude;
        }
      
        private void BubbleForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(); //getS_Waypoints(_latitude, _longitude);

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Waypoint", typeof(String));
            dt.Columns.Add("KM", typeof(String));
            dt.Columns.Add("Descriptions", typeof(String));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("ImageFilePath", typeof(String));
            dt.Columns.Add("Latitude", typeof(String));
            dt.Columns.Add("Longitude", typeof(String));

            DataRow row;

            row = dt.NewRow();
            row["ID"] = 1;
            row["Waypoint"] = "1";
            row["KM"] = "0";
            row["Descriptions"] = "Tpi-2 Çıkış Çanakkale yönü bağlantınoktası";
            row["Name"] = "A Name";
            row["ImageFilePath"] = @"\Image\1.png";
            row["Latitude"] = "38,48588";
            row["Longitude"] = "27,1356279";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["ID"] = 2;
            row["Waypoint"] = "2";
            row["KM"] = "5,6";
            row["Descriptions"] = "Yükseklik:6,30m";
            row["Name"] = "B Name";
            row["ImageFilePath"] = @"\Image\2.png";
            row["Latitude"] = "38,4814793";
            row["Longitude"] = "27,153824";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["ID"] = 3;
            row["Waypoint"] = "3";
            row["KM"] = "8,3";
            row["Descriptions"] = "Yükseklik: 5,50m";
            row["Name"] = "C Name";
            row["ImageFilePath"] = @"\Image\3.png";
            row["Latitude"] = "38,4811434";
            row["Longitude"] = "27,1681577";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["ID"] = 4;
            row["Waypoint"] = "4";
            row["KM"] = "12,7";
            row["Descriptions"] = "Yükseklik: 5,35(Sağ taraf yüksekliği)";
            row["Name"] = "D Name";
            row["ImageFilePath"] = @"\Image\4.png";
            row["Latitude"] = "38,4780526";
            row["Longitude"] = "27,1880704";
            dt.Rows.Add(row);

            lblWaypoint.Text = dt.Rows[0].ItemArray[1].ToString();
            lblKM.Text = dt.Rows[0].ItemArray[2].ToString();
            lblCoordinates.Text = dt.Rows[0].ItemArray[6].ToString() + " " + dt.Rows[0].ItemArray[7].ToString();
            lblDescriptions.Text = dt.Rows[0].ItemArray[3].ToString();
            //var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\","");
            var path = @"C:\bldb";

            string FileName = path + dt.Rows[0].ItemArray[5].ToString();
            pictureEdit1.Image = Image.FromFile(FileName);
        }

        public static System.Data.DataTable getS_Waypoints(string latitude, string longitude)
        {
            //if (jobNum.Equals(""))
            //    jobNum = null;
            //if (cell.Equals(""))
            //    cell = null;

            Conn.ConnDBLocal(true);

            //Cursor.Current = Cursors.WaitCursor;
            SqlCommand sqlCmd = new SqlCommand("S_Waypoints", Conn.dbLocal);
            sqlCmd.CommandTimeout = 30000;
            sqlCmd.Parameters.AddWithValue("@latitude", latitude);
            sqlCmd.Parameters.AddWithValue("@longitude", longitude);

            //sqlCmd.Parameters.AddWithValue("@Cell", cell);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;

            DataTable dt = new DataTable();

            da.Fill(dt);
            //gridControl1.DataSource = ds;
            //gcDashboard.ItemsSource = ds;

            Conn.ConnDBLocal(false);

            //Cursor.Current = Cursors.Default;
            return dt;
        }

    }
}