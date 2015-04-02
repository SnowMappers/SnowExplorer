using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Topology;
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

        //*************polygon Shapefile variables***************
        //which type of shapefile is created
        string shapeType;

        //new polygon feeture set
        FeatureSet polygonF = new FeatureSet(FeatureType.Polygon);

        //the id of the polygon
        int polygonID = 0;

        //differentiate between right and left mouse clicks
        bool polygonmouseClick = false;

        //variable for first time mouse click
        bool firstClick = false;

        //************* End Polygon Variables ****************

        public frmMain()
        {
            InitializeComponent();
            appManager1.LoadExtensions();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmGetData dataForm = new frmGetData();
            dataForm.MainMap = mapMain;
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
            if (mapMain.FunctionMode != DotSpatial.Controls.FunctionMode.Pan)
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

        private void btnDrawPolygon_Click(object sender, EventArgs e)
        {

            //change the mouse cursor
            mapMain.Cursor = Cursors.Cross;

            //set shape type
            shapeType = "polygon";

            //set the polygon projection to the maps
            polygonF.Projection = mapMain.Projection;
            
            //initialize attribute table
            DataColumn column = new DataColumn("PolygonID");

            if (!polygonF.DataTable.Columns.Contains("PolygonID"))
            {
                polygonF.DataTable.Columns.Add(column);
            }

            //add the polygon to the map layer
            MapPolygonLayer polygonLayer = (MapPolygonLayer)mapMain.Layers.Add(polygonF);

            //polygon symbology
            PolygonSymbolizer symbol = new PolygonSymbolizer(Color.Peru);
            polygonLayer.Symbolizer = symbol;

            polygonLayer.LegendText = "Polygon";

            MessageBox.Show("Click on the map to draw a ploygon. Right click to start a new polygon. Double click to stop drawing.");

            //intializes drawing polygon mode
            firstClick = true;

            polygonmouseClick = true;

        }

        private void mapMain_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                //left click - fill array of coordinates
                Coordinate coord = mapMain.PixelToProj(e.Location);

                if (polygonmouseClick == true)
                {
                    if (firstClick == true)
                    {

                        //Creat a list to contain the polygon coordinates
                        List<Coordinate> polygonArray = new List<Coordinate>();

                        //Create an instance for LinearRing class.
                        //We pass the polygon List to the constructor of this class
                        LinearRing polygonGeometry = new LinearRing(polygonArray);

                        //add polygonGeomety instance to polygonFeature
                        IFeature polygonFeature = polygonF.AddFeature(polygonGeometry);

                        //add first coordinate
                        polygonFeature.Coordinates.Add(coord);

                        //set the polygon feature attribute
                        polygonID = polygonID + 1;
                        polygonFeature.DataRow["PolygonID"] = polygonID;
                        firstClick = false;

                    }
                    else
                    {
                        //second or more clicks-add points to the existing feature
                        IFeature existingFeature = (IFeature)polygonF.Features[polygonF.Features.Count - 1];

                        existingFeature.Coordinates.Add(coord);

                        //refresh the map if line has 2 or more points
                        if (existingFeature.Coordinates.Count != 0)
                        {
                            //refresh the map
                            polygonF.InitializeVertices();
                            mapMain.ResetBuffer();
                        }
                    }
                }

            }
            else
            {
                //right click - reset first mouse click
                firstClick = true;  
          

            }
           
        }

        private void mapMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            Coordinate coord = mapMain.PixelToProj(e.Location);

            if (polygonmouseClick == true)
            {
                
                
                
                
                
                //Creat a list to contain the polygon coordinates
                List<Coordinate> polygonArray = new List<Coordinate>();

                //Create an instance for LinearRing class.
                //We pass the polygon List to the constructor of this class
                LinearRing polygonGeometry = new LinearRing(polygonArray);

                //add polygonGeomety instance to polygonFeature
                IFeature polygonFeature = polygonF.AddFeature(polygonGeometry);

                //add first coordinate
                polygonFeature.Coordinates.Add(coord);

                //set the polygon feature attribute
                polygonID = polygonID + 1;
                polygonFeature.DataRow["PolygonID"] = polygonID;         
             
                polygonFeature.Coordinates.Add(polygonFeature.Coordinates[0]);


                polygonF.InitializeVertices();
                   mapMain.ResetBuffer();


                
                polygonF.SaveAs("polygonF.shp",true);
                polygonmouseClick = false;
                mapMain.Cursor = Cursors.Arrow;
            }
        }
    }
}
