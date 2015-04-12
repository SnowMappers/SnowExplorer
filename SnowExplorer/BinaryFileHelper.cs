using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowExplorer
{
    /// <summary>
    /// This class helps with reading the SNODAS binary files
    /// </summary>
    public static class BinaryFileHelper
    {
        public static Int16[] ReadBinaryArray(string fileName, int numCells)
        {
            int numBytes = numCells * 2;
            //reading the file. The data is Big-Endian
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                byte[] rawData = BinaryFileHelper.ReadFully(stream, numBytes);

                //we need to swap the byte order in the raw data
                Swap(rawData);
                Int16[] myArray = new Int16[numCells];
                Buffer.BlockCopy(rawData, 0, myArray, 0, numBytes);
                return myArray;
            }
        }


        /// <summary>
        /// Swaps the byte array from big-endian to little-endian
        /// </summary>
        /// <param name="data">the byte array. our function modifies it.</param>
        public static void Swap(byte[] data)
        {
            for (int i = 0; i < data.Length; i += 2)
            {
                byte b = data[i];
                data[i] = data[i + 1];
                data[i + 1] = b;
            }
        }
        
        
        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="initialLength">The initial buffer length</param>
        public static byte[] ReadFully(Stream stream, int initialLength)
        {
            // If we've been passed an unhelpful initial length, just
            // use 32K.
            if (initialLength < 1)
            {
                initialLength = 32768;
            }

            byte[] buffer = new byte[initialLength];
            int read = 0;

            int chunk;
            while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
            {
                read += chunk;

                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = stream.ReadByte();

                    // End of stream? If so, we're done
                    if (nextByte == -1)
                    {
                        return buffer;
                    }

                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
            }
            // Buffer is now too big. Shrink it.
            byte[] ret = new byte[read];
            Array.Copy(buffer, ret, read);
            return ret;
        }
    }
}
