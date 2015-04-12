using DotSpatial.Data;
using DotSpatial.Topology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowExplorer
{   
    /// <summary>
    /// This class is responsible to calculate the raster snow volume
    /// </summary>
    public class VolumeCalculator
    {
     
        /// <summary>
        /// the length of one degree of latitude (and one degree of longitude at equator) in meters.
        /// </summary>
        private int DEGREE_DISTANCE_AT_EQUATOR = 111329;
        
        
        /// <summary>
        /// calculates the length of one degree of longitude at the given latitude.
        /// </summary>
        /// <param name="latitude">latitude the latitude to calculate the longitude distance for</param>
        /// <returns>return the length of one degree of longitude at the given latitude in meters.</returns>
        public double longitudeDistanceAtLatitude(double latitude)
        {
            double longitudeDistanceScaleForCurrentLatitude = Math.Cos(latitude * (Math.PI / 180.0));
            return DEGREE_DISTANCE_AT_EQUATOR * longitudeDistanceScaleForCurrentLatitude;
        }

        /// <summary>
        /// Given a degree of latitude, get the raster cell width in meters
        /// when the raster spacing is in decimal degrees
        /// </summary>
        /// <param name="latitude">the latitude of center of the raster cell</param>
        /// <returns>the cell width in meters</returns>
        private double CalculateCellWidth(double cellWidthDegrees, double latitude)
        {
            double cellWidthMeters = longitudeDistanceAtLatitude(latitude) * cellWidthDegrees;
            return cellWidthMeters;
        }

        private double CalculateCellHeight(double cellHeightDegrees)
        {
            return DEGREE_DISTANCE_AT_EQUATOR * cellHeightDegrees;
        }

        /// <summary>
        /// Calculates the volume, if the raster is Decimal Degrees (WGS84) and
        /// the z-units are millimeters
        /// </summary>
        /// <param name="cRaster">the Snow Water Equivalent raster with units in mm</param>
        /// <returns>the snow water volume in cubic meters</returns>
        private double CalculateVolumeForLatLon(IRaster cRaster)
        {
            //volume in cubic meters
            double volume_m3 = 0;

            //our raster is in decimal degrees (Lat/Lon). In this case
            //the cell width changes with latitude!
            
            //cell height (this is same for all rows)
            double cellHeight_m = CalculateCellHeight(cRaster.CellHeight);

            for (int row = 0; row < cRaster.NumRows; row++)
            {
                //cell width for the row depends on latitude
                Coordinate lonLat = cRaster.CellToProj(0, row);
                double lat = lonLat.Y;
                double cellWidth_m = CalculateCellWidth(cRaster.CellWidth, lat);

                for (int col = 0; col < cRaster.NumColumns; col++)
                {
                    //SWE in millimeters
                    double cellValue_mm = cRaster.Value[row, col];
                    //set any NoData to Zero
                    if (cellValue_mm < 0)
                    {
                        cellValue_mm = 0;
                    }
                    //SWE in meters
                    double cellValue_m = cellValue_mm / 1000.0;

                    //Snow Volume in cubic meters
                    double cellVolume_m3 = cellValue_m * cellHeight_m * cellWidth_m;

                    //Add the cell volume to the total volume
                    volume_m3 += cellVolume_m3;
                }
            }
            return volume_m3;
        }

        /// <summary>
        /// Calculates the Snow Water Equivalent volume, when the raster is in projected
        /// coordinates, the horizontal units are meters, and the SWE units are milimeters
        /// </summary>
        /// <param name="cRaster">The raster with SWE in milimeters</param>
        /// <returns>The snow water volume in cubic meters</returns>
        private double CalculateVolumeProjected(IRaster cRaster)
        {
            double volume_m3 = 0;
            double cellHeight_m = cRaster.CellHeight;
            double cellWidth_m = cRaster.CellWidth;
            double cellArea_m2 = cellHeight_m * cellWidth_m;

            //Calculate the volume of the new raster
            for (int row = 0; row < cRaster.NumRows; row++)
            {
                for (int col = 0; col < cRaster.NumColumns; col++)
                {
                    //SWE in millimeters
                    double cellValue_mm = cRaster.Value[row, col];
                    //set any NoData to Zero
                    if (cellValue_mm < 0)
                    {
                        cellValue_mm = 0;
                    }
                    //cell SWE in meters
                    double cellValue_m = cellValue_mm / 1000.0;

                    //Snow Volume in cubic meters
                    double cellVolume_m3 = cellValue_m * cellHeight_m * cellWidth_m;

                    //Add the cell volume to the total volume
                    volume_m3 += cellVolume_m3;
                }
            }
            return volume_m3;
        }

        /// <summary>
        /// Calculates the volume of the raster in cubic meters
        /// The z-units of the raster must be the Snow Water Equivalent
        /// (SWE) in millimeters. NoData cells are treated as zero snow.
        /// </summary>
        /// <param name="cRaster">The SWE raster with values in mm</param>
        /// <returns>The snow water volume in cubic meters</returns>
        public double CalculateVolume(IRaster cRaster)
        {
            if (cRaster.Projection.IsLatLon)
            {
                return CalculateVolumeForLatLon(cRaster);
            }
            else
            {
                return CalculateVolumeProjected(cRaster);
            } 
        }
    }
}
