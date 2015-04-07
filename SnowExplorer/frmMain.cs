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
using System.Linq;
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

        //************* End Polygon Variables ****************

        public frmMain()
        {   
            InitializeComponent();

            //Set this form as a "container control" so the plugins know where to put themselves.
            //Shell = this;

            //appManager1.LoadExtensions();
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
            else
            {
                //right click - reset first mouse click
                firstClick = true;            
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

                polygonFNew.SaveAs("polygonF.shp",true);

                
                polygonmouseClick = false;
                mapMain.Cursor = Cursors.Arrow;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //check the cell size
            IMapRasterLayer[] rasters = mapMain.GetRasterLayers();
            if (rasters.Length == 0)
            {
                MessageBox.Show("Please add the snow data layer to the map");
                return;
            }

            IMapRasterLayer snowLayer = rasters[0];
            IRaster snowRaster = snowLayer.DataSet;
            double cellHeight = snowRaster.CellHeight;
            double cellWidth = snowRaster.CellWidth;
            MessageBox.Show("Cell Height: " + cellHeight.ToString() + "Cell Width: " + cellWidth.ToString());

            //creates a variable for the coordinate
            DotSpatial.Topology.Coordinate c;

            //volume variables
            double volume = 0;
            double cellArea = cellHeight*cellWidth;
            double cellValue = 0;

            //create a feature variable from the polygon
            IFeature f = polygonFNew.Features[0];

            //create a new raster with the same scope as the snowRaster
            IRaster clipped = Raster.Create("clipraster.bgd",null,snowRaster.NumColumns,snowRaster.NumRows, 1,snowRaster.DataType,null);
            clipped.Bounds = snowRaster.Bounds;
            clipped.Projection = snowRaster.Projection;

            //look through each cell and see if it is within the polygon
            for (int i = 0; i < snowRaster.NumRows; i++)
            {
                for (int j = 0; j < snowRaster.NumColumns; j++)
                {
                    c = snowRaster.CellToProj(i, j);

                    if (f.Intersects(c))
                    {
                        //if the value is within the polygon add it to the new raster
                        clipped.Value[i, j] = snowRaster.Value[i, j] ;
                    }
                    else
                    {
                        // if the value is not in the polygon ignore it
                       clipped.Value[i,j] = clipped.NoDataValue;
                    }


                }
            }
            mapMain.Layers.Add(clipped);

            //Calculate the volume of the new raster
            for (int i = 0; i <clipped.NumRows; i++)
            {
                for (int j = 0; j<clipped.NumColumns; j++)
                {
                    cellValue = clipped.Value[i,j];
                    volume = volume + cellValue*cellArea;
                }
            }

            
            string volText = Convert.ToString(Math.Round(volume,3));
            textBox1.Text = volText;
        }
    }
}
