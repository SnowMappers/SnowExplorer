using DotSpatial.Analysis;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Topology;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowExplorer
{

    public partial class frmMain : Form
    {
        //Exporting basically gives this form a name that the plugins can see
        //A container contorl is a control that can hold other controls. 
        //These two lines are required to support 3rd party plugins
        //[Export("Shell", typeof(ContainerControl))]
        //private static ContainerControl Shell;


        //*************polygon Shapefile variables***************
        //which type of shapefile is created
        string shapeType;

        //new polygon feeture set
        FeatureSet polygonF = new FeatureSet(FeatureType.Polygon);
        FeatureSet polygonFNew = new FeatureSet(FeatureType.Polygon);

        //the id of the polygon
        int polygonID = 0;

        //the x coordinates
        List<double> xCoordinates = new List<double>();
        //the y coordinates
        List<double> yCoordinates = new List<double>();

        //differentiate between right and left mouse clicks
        bool polygonmouseClick = false;

        //variable for first time mouse click
        bool firstClick = false;

        //the polygon layer
        MapPolygonLayer polygonLayer = null;

        //************* End Polygon Variables ****************

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmGetData dataForm = new frmGetData();
            dataForm.MainMap = mapMain;
            dataForm.DateLabel = lblDate;
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

        /// <summary>
        /// Default loading: We add the U.S states layer to our map
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            //set superscript in grpVolume
            grpResults.Text = "Results";

            string executablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dataFolder = Path.Combine(executablePath, "Snow_Data");

            //get path of the shapefile in the Snow_Data subfolder
            string statesShapefile = Path.Combine(dataFolder, "us_states.shp");
            if (File.Exists(statesShapefile))
            {
                //set map symbol to transparent color and black outline
                IFeatureSet statesF = FeatureSet.Open(statesShapefile);
                MapPolygonLayer statesLayer = new MapPolygonLayer(statesF);
                statesLayer.Symbolizer.SetOutline(Color.Black, 1.0);
                statesLayer.Symbolizer.SetFillColor(Color.Transparent);
                mapMain.Layers.Add(statesLayer);
            }

            //get path of the shapefile in the Snow_Data subfolder
            string lakesShapefile = Path.Combine(dataFolder, "us_lakes.shp");
            if (File.Exists(lakesShapefile))
            {
                //set map symbol to blue color and blue outline
                IFeatureSet lakesF = FeatureSet.Open(lakesShapefile);
                MapPolygonLayer lakesLayer = new MapPolygonLayer(lakesF);
                lakesLayer.Symbolizer.SetOutline(Color.Blue, 1.0);
                lakesLayer.Symbolizer.SetFillColor(Color.LightBlue);
                mapMain.Layers.Add(lakesLayer);
            }
        }

        private void btnDrawPolygon_Click(object sender, EventArgs e)
        {
            if (polygonLayer != null)
            {
                mapMain.Layers.Remove(polygonLayer);
                polygonLayer = null;

                //reset everything
                polygonF = new FeatureSet(FeatureType.Polygon);
                polygonFNew = new FeatureSet(FeatureType.Polygon);

                //the id of the polygon
                polygonID = 0;

                //the x coordinates
                xCoordinates = new List<double>();
                //the y coordinates
                yCoordinates = new List<double>();
            }
            
            
            //change the mouse cursor
            mapMain.Cursor = Cursors.Cross;

            //set shape type
            shapeType = "polygon";

            //set the polygon projection to the maps
            polygonF.Projection = mapMain.Projection;

            //initialize attribute table
            DataColumn column = new DataColumn("PolygonID");
            DataColumn volume = new DataColumn("Volume");

            if (!polygonF.DataTable.Columns.Contains("PolygonID"))
            {
                polygonF.DataTable.Columns.Add(column);
            }

            if (!polygonF.DataTable.Columns.Contains("Volume"))
            {
                polygonF.DataTable.Columns.Add(volume);
            }

            //add the polygon to the map layer
            polygonLayer = (MapPolygonLayer)mapMain.Layers.Add(polygonF);

            //polygon symbology
            PolygonSymbolizer symbol = new PolygonSymbolizer(Color.Peru);
            polygonLayer.Symbolizer = symbol;

            polygonLayer.LegendText = "Polygon";

            MessageBox.Show("Click on the map to draw a ploygon. Double click to stop drawing.");

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

                        //add to the list of coordinates
                        xCoordinates.Add(coord.X);
                        yCoordinates.Add(coord.Y);

                        //set the polygon feature attribute
                        polygonID = polygonID + 1;
                        polygonFeature.DataRow["PolygonID"] = polygonID;
                        firstClick = false;

                        //Add volume data column 
                        polygonFeature.DataRow["Volume"] = 0;

                    }
                    else
                    {
                        //second or more clicks-add points to the existing feature
                        IFeature existingFeature = (IFeature)polygonF.Features[polygonF.Features.Count - 1];

                        existingFeature.Coordinates.Add(coord);

                        //add to the list of coordinates
                        xCoordinates.Add(coord.X);
                        yCoordinates.Add(coord.Y);

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
        }

        private void mapMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            if (polygonmouseClick == true)
            {
                //get polygonGeomety instance of existing polygonFeature
                IFeature polygonFeature = polygonF.GetFeature(0);

                //add first coordinate
                Coordinate coord = polygonFeature.Coordinates[0];
                polygonFeature.Coordinates.Add(coord);

                polygonF.InitializeVertices();
                mapMain.ResetBuffer();

                //add first coordinate to the list
                xCoordinates.Add(coord.X);
                yCoordinates.Add(coord.Y);



                //we add new feature
                //Creat a list to contain the polygon coordinates
                List<Coordinate> polygonArray = new List<Coordinate>();
                for (int i = 0; i < xCoordinates.Count; i++)
                {
                    polygonArray.Add(new Coordinate(xCoordinates[i], yCoordinates[i]));
                }

                //Create an instance for LinearRing class.
                //We pass the polygon List to the constructor of this class
                LinearRing polygonGeometry = new LinearRing(polygonArray);
                DotSpatial.Topology.Polygon polygon = new Polygon(polygonGeometry);

                //add polygonGeomety instance to polygonFeature
                IFeature polygonFeatureNew = polygonFNew.AddFeature(polygon);

                FeatureType ft = polygonFNew.FeatureType;

                polygonFNew.SaveAs("polygonF.shp", true);


                polygonmouseClick = false;
                mapMain.Cursor = Cursors.Arrow;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //check if there is a raster in the map
            IMapRasterLayer[] rasters = mapMain.GetRasterLayers();
            if (rasters.Length == 0)
            {
                MessageBox.Show("Please add the snow data layer to the map");
                return;
            }

            //we use the first raster layer for snow calculation
            IMapRasterLayer snowLayer = rasters[0];
            IRaster snowRaster = snowLayer.DataSet;
            
            //creates a variable for the coordinate
            DotSpatial.Topology.Coordinate c;

            //create a feature variable from the polygon
            IFeature polygon = polygonFNew.Features[0];
            IRaster cRaster = null;

            //clip raster with polygon: using built-in function
            //note: this is slow because it still makes a huge raster...
            cRaster = DotSpatial.Analysis.ClipRaster.ClipRasterWithPolygon(polygon, snowRaster, "snowRasterClip.bgd");

            //add the new clipped raster to the map
            mapMain.Layers.Add(cRaster);

            //calculate the volume using function in our VolumeCalculator class
            VolumeCalculator volumeCalc = new VolumeCalculator();
            double volume_m3 = volumeCalc.CalculateVolume(cRaster);
            List<double> areas_m2 = volumeCalc.CalculateAreaForLatLon(cRaster);
            
            //show the volume in the "results" textbox
            string volText = Convert.ToString(Math.Round(volume_m3, 0));

            string snowAreaText = Convert.ToString(Math.Round(areas_m2[0], 0));

            string totalAreaText = Convert.ToString(Math.Round(areas_m2[1], 0));

            double snowPercent = 100 * (areas_m2[0] / areas_m2[1]);
            string snowPercentText = Convert.ToString(Math.Round(snowPercent , 1));

            tbVolume.Text = "Volume: " + volText + "(m\xB3)" + "\n" +
                "Snow-covered area: " + snowAreaText + "(m\xB2)" + "\n"; //+
                //"Total area: " + totalAreaText + "\n" +
                //"Percent snow-covered: " + snowPercentText + "\n";
        }

        private void cmbBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            mapMain.AddLayer();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Opens the Help Files and Technical Documents
            System.Diagnostics.Process.Start("EndUser.docx");
            System.Diagnostics.Process.Start("TechSpec.docx");

        }

      
    }
}
