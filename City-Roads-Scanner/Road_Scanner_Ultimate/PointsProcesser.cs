using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Road_Scanner_Ultimate
{
    internal static class PointsProcesser
    {
        // TODO: Make pathDist useful but use default path if not set
        public static string PutDotsIntoImage(string initialDirOpen, string pathDist, RoadsMap map)
        {
            string JSONPointsFilePath = Utils.SelectFileDialog(initialDirOpen);
            List<RoadPoint> roadPoints = RoadPoint.DeserializeJSON(JSONPointsFilePath);
            if (roadPoints == null)
            {
                return "You are trying to put dots into image";
            }
            Bitmap roadPointsImage = new Bitmap(map.CityMapWidth, map.CityMapHeight);

            using (Graphics graph = Graphics.FromImage(roadPointsImage))
            {
                Rectangle ImageSize = new Rectangle(0, 0, map.CityMapWidth, map.CityMapHeight);
                graph.FillRectangle(Brushes.White, ImageSize);
            }

            roadPoints.ForEach(item =>
            {
                int id = item.id;
                int x = item.x;
                int y = item.y;
                int size = item.size;
                string type = item.type;

                roadPointsImage.SetPixel(x, y, Color.Red);
            });


            roadPointsImage.Save(JSONPointsFilePath + ".png", ImageFormat.Png);

            return "Picture of dots has been created";
        }

        private static string chunksJSON = "";
        public static string PutDotsIntoChunks(string initialDirOpen, int chunkSize, RoadsMap map)
        {
            chunksJSON = "";
            string JSONPointsFilePath = Utils.SelectFileDialog(initialDirOpen);
            string JSONPointsDirPath = "";
            try
            {
                JSONPointsDirPath = JSONPointsFilePath.Substring(0, JSONPointsFilePath.LastIndexOf('\\'));
            } catch (Exception ex)
            {
                return "You are trying to put dots into chunks";
            }
            List<RoadPoint> roadPoints = RoadPoint.DeserializeJSON(JSONPointsFilePath);
            if (roadPoints == null)
            {
                return "You are trying to put dots into chunks";
            }
            chunksJSON = "[\r\n";

            int idCounter = 0;
            for (int y = 0; y < map.CityMapHeight; y += chunkSize)
            {
                for (int x = 0; x < map.CityMapWidth; x += chunkSize)
                {

                    chunksJSON += $@"    {{
        ""id"": {idCounter},
        ""xA"": {x},
        ""yA"": {y},
        ""xB"": {x + chunkSize},
        ""yB"": {y + chunkSize},
        ""xC"": {(x + x + chunkSize) / 2},
        ""yC"": {(y + y + chunkSize) / 2},
        ""road_points_IDs"": [";

                    idCounter++;

                    bool somePointsFound = false;
                    roadPoints.ForEach(item =>
                    {
                        int roadPointID = item.id;
                        int roadPointX = item.x;
                        int roadPointY = item.y;
                        int roadPointSize = item.size;
                        string roadType = item.type;

                        // Check if the road point in a square 
                        // TODO: > change to >= and < change to <= ??????????
                        if (roadPointX > x && roadPointX < (x + chunkSize)
                            && roadPointY > y && roadPointY < (y + chunkSize))
                        {
                            chunksJSON += $"{roadPointID}, ";
                            somePointsFound = true;
                        }

                    });
                    // trim  last ','
                    if (somePointsFound)
                    {
                        chunksJSON = chunksJSON.Substring(0, chunksJSON.Length - 2) + "]";
                    }
                    else
                    {
                        chunksJSON += "]";
                    }
                    chunksJSON += $@"
    }},
";
                }

            }

            // trim last ','
            chunksJSON = chunksJSON.Substring(0, chunksJSON.Length - 3) + "\r\n]";


            Utils.CreateFile(JSONPointsDirPath + "\\", "chunk", chunksJSON, "json");
            
            return "Chunks have been created";
        }
    }
}
