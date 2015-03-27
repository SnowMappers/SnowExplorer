using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowExplorer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            appManager1.LoadExtensions();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmGetData dataForm = new frmGetData();
            dataForm.Show();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            mapMain.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            mapMain.ZoomOut();
        }

        private void btnZoomExtents_Click(object sender, EventArgs e)
        {
            mapMain.ZoomToMaxExtent();
        }

        private void btnPan_Click(object sender, EventArgs e)
        {
            if (mapMain.FunctionMode == DotSpatial.Controls.FunctionMode.None)
            {
                mapMain.FunctionMode = DotSpatial.Controls.FunctionMode.Pan;
            }
            else
            {
                mapMain.FunctionMode = DotSpatial.Controls.FunctionMode.None;
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
