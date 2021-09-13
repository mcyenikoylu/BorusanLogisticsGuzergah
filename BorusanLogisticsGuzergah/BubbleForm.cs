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
            DataTable dt = getS_Waypoints(_latitude, _longitude);
            lblWaypoint.Text = dt.Rows[0].ItemArray[4].ToString();
            lblKM.Text = dt.Rows[0].ItemArray[5].ToString();
            lblCoordinates.Text = dt.Rows[0].ItemArray[1].ToString() + " " + dt.Rows[0].ItemArray[2].ToString();
            lblDescriptions.Text = dt.Rows[0].ItemArray[6].ToString();
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\","");
            string FileName = path + dt.Rows[0].ItemArray[7].ToString();
            pictureEdit1.Image = Image.FromFile(FileName);
        }

        public static System.Data.DataTable getS_Waypoints(string latitude, string longitude)
        {
            //if (jobNum.Equals(""))
            //    jobNum = null;
            //if (cell.Equals(""))
            //    cell = null;

            WaypointForm.ConnDBLocal(true);

            //Cursor.Current = Cursors.WaitCursor;
            SqlCommand sqlCmd = new SqlCommand("S_Waypoints", WaypointForm.dbLocal);
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

            WaypointForm.ConnDBLocal(false);

            //Cursor.Current = Cursors.Default;
            return dt;
        }

    }
}