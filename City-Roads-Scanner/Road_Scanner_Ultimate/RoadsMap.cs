using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Road_Scanner_Ultimate
{
    internal class RoadsMap
    {
        public Bitmap CityMapBitmap { get; set; }
        public Bitmap CityMapProcessBitmap { get; set; }
        public Bitmap CityMapProcessBitmapInitial { get; set; }
        public double PixelSizeInMeeters { get; set; }
        public double RangeBetweenPointsInMeters { get; set; }
        public int RangeBetweenPointsInPixels { get; set; }
        public int CityMapWidth { get; set; }
        public int CityMapHeight { get; set; }
        public int DiagonalMaxCheckSize { get; set; }
        public string CityMapPath { get; set; }

        public RoadsMap()
        {
            
        }

        // Assign preview, also sets height and width fields
        public string AssignPreviewImage(PictureBox pictureBox)
        {
            CityMapBitmap = new Bitmap(CityMapPath);
            pictureBox.BackgroundImage = CityMapBitmap;

            
            CityMapWidth = CityMapBitmap.Width;
            CityMapHeight = CityMapBitmap.Height;

            return $"[Map Size: width: {CityMapWidth}, height: {CityMapHeight}]";
        }

        /*public void CalculateRangeBetweenPointsInPixels() {
            RangeBetweenPointsInPixels = RangeBetweenPointsInMeters / 10;
        }*/
    }

    internal class RoadPoint
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        static public List<RoadPoint> DeserializeJSON(string JSONPath)
        {
            List<RoadPoint> roadPoints = null;
            try
            {
                using (FileStream fs = new FileStream(JSONPath, FileMode.OpenOrCreate))
                {
                    roadPoints = JsonSerializer.Deserialize<List<RoadPoint>>(fs);
                }
            } catch (Exception ex)
            {
                
            }
            return roadPoints;
        }
    }
}
