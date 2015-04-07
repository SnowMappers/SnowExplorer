using DotSpatial.Controls;
using DotSpatial.Symbology;
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
    public partial class frmGetData : Form
    {
        public frmGetData()
        {
            InitializeComponent();
        }

        //this is for accessing the main map from frmMain
        public DotSpatial.Controls.Map MainMap;



        private void btnFile_Click(object sender, EventArgs e)
        {
            MapRasterLayer snowLayer = (MapRasterLayer)MainMap.AddRasterLayer();
            
            //we add new categories to the snow layer

            try
            {
                IColorScheme snowColorScheme = snowLayer.Symbolizer.Scheme;
                snowColorScheme.ClearCategories();

                ColorCategory c1 = new ColorCategory(1, 100, Color.LightBlue, Color.LightBlue);
                c1.LegendText = "0 - 100";
                snowColorScheme.AddCategory(c1);

                ColorCategory c2 = new ColorCategory(100, 10000, Color.DarkBlue, Color.DarkBlue);
                c2.LegendText = "> 100";
                snowColorScheme.AddCategory(c2);

                snowLayer.WriteBitmap();
            }
            catch { }
        }
    }
}
