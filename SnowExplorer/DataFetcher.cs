using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using tar_cs;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Core;
using DotSpatial.Data;
using System.Windows.Forms;

namespace SnowExplorer
{
    // This class retrieves data from SNODAS FTP site
    class DataFetcher
    {
        private string baseURLunmasked = "ftp://sidads.colorado.edu/DATASETS/NOAA/G02158/unmasked/";
        private string baseURLmasked = "ftp://sidads.colorado.edu/DATASETS/NOAA/G02158/masked/";

        public string ExtractGZip(string gzipFileName)
        {
            // Use a 4K buffer. Any larger is a waste.    
            byte[] dataBuffer = new byte[4096];

            using (System.IO.Stream fs = new FileStream(gzipFileName, FileMode.Open, FileAccess.Read))
            {
                using (GZipInputStream gzipStream = new GZipInputStream(fs))
                {

                    // Change this to your needs
                    string fnOut = Path.GetFileNameWithoutExtension(gzipFileName);

                    using (FileStream fsOut = File.Create(fnOut))
                    {
                        StreamUtils.Copy(gzipStream, fsOut, dataBuffer);
                    }
                    return fnOut;
                }
            }
        }

        private string makeURL(DateTime date, bool masked)
        {
            int year = date.Year;
            string monthNumber = date.Month.ToString("00");
            string monthName = date.ToString("MMM");
            string dayNumber = date.Day.ToString("00");
            if (masked == true)
            {
                return string.Format(baseURLmasked + "{0}/{1}_{2}/SNODAS_{3}{4}{5}.tar", year, monthNumber, monthName, year, monthNumber, dayNumber);
            }
            else
            {
                return string.Format(baseURLunmasked + "{0}/{1}_{2}/SNODAS_unmasked_{3}{4}{5}.tar", year, monthNumber, monthName, year, monthNumber, dayNumber);
            }
        }
        
        public string FetchSnow(DateTime date, bool masked)
        {
            string url = makeURL(date, masked);
            string localFile = url.Substring(url.LastIndexOf("/") + 1);
            FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(url);
            FtpWebResponse ftpResponse = null;
            try
            {
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            }
            catch
            {
                throw new WebException("Cannot download file: " + url);
            }

            Stream ftpStream = null;
            int bufferSize = 2048;
            ftpStream = ftpResponse.GetResponseStream();
            /* Open a File Stream to Write the Downloaded File */
            FileStream localFileStream = new FileStream(localFile, FileMode.Create);
            /* Buffer for the Downloaded Data */
            byte[] byteBuffer = new byte[bufferSize];
            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
            /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
            try
            {
                while (bytesRead > 0)
                {
                    localFileStream.Write(byteBuffer, 0, bytesRead);
                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Resource Cleanup */
            localFileStream.Close();
            ftpStream.Close();
            ftpResponse.Close();
            ftpRequest = null;
            string datFileName = null;
            string hdrFileName = null;

            //now untar the required files
            FileStream unarchFile = File.OpenRead(localFile);
            TarReader reader = new TarReader(unarchFile);
            //the mask character indicates whether the data is whole area or u.s
            //only.
            string mask = "zz";
            if (masked)
            {
                mask = "us";
            }
            string sweStart = String.Format("{0}_ssmv11034tS__T0001TTNATS{1}{2}", mask, date.Year.ToString(), date.Month.ToString("00"));

            while (reader.MoveNext(true))
            {
                string fn = reader.FileInfo.FileName;
                
                
                if (fn.Contains(sweStart))
                {
                    using (FileStream file = File.Create(fn))
                    {
                        reader.Read(file);
                    }
                    string unzippedFile = ExtractGZip(fn);
                    if (unzippedFile.ToLower().EndsWith("dat"))
                    {
                        datFileName = unzippedFile;
                    }
                    if (unzippedFile.ToLower().EndsWith("hdr"))
                    {
                        hdrFileName = unzippedFile;
                    }
                }
                
            }
            return datFileName;
        }

        /// <summary>
        /// Makes a snow raster in bgd format from the downloaded SNODAS data file
        /// </summary>
        /// <param name="snodasDatFile">the SNODAS unzipped data file in .dat format</param>
        /// <param name="bgdFile">the output bgd data file</param>
        /// <returns>The IRaster object</returns>
        public IRaster MakeSnowRaster(string snodasDatFile, string bgdFile)
        {
            //for masked case rows and columns:
            int numCols = 6935;
            int numRows = 3351;

            //for masked case lat and long bounding box:
            Extent maskedExtent = new Extent(-124.7337, 24.9504, -66.9421, 52.8754);

            int numCells = numCols * numRows;

            //read the SNODAS .dat binary file into an array
            Int16[] binaryData = BinaryFileHelper.ReadBinaryArray(snodasDatFile, numCells);

            IRaster ras = Raster.Create(bgdFile, "bgd", numCols, numRows, 1, typeof(Int16), new string[0]);

            //set the properties of our raster: bounds, projection, NoDataValue
            ras.Bounds = new RasterBounds(numRows, numCols, maskedExtent);
            ras.ProjectionString = "+proj=longlat +datum=WGS84 +no_defs";
            ras.NoDataValue = -9999;

            //set the raster's values
            for (int row=0; row<numRows; row++)
            {
                for(int col=0; col< numCols; col++)
                {
                    ras.Value[row, col] = binaryData[row * numCols + col];
                }
            }
            ras.Save();
            return ras;
        }


    }
}
