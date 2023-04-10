using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Road_Scanner_Ultimate
{
    internal class MapAnalizer
    {
        private string dotsJSON = "";
        // Slope should be in range [-1, 1]
        private double[] slopes = { 0, 0.17, 0.36, 0.57, 0.83, 1, -0.17, -0.36, -0.57, -0.83, -1 };
        private MainPage _mainPage;
        public RoadsMap Map { get; set; }
        public ScannerVisualiserPage VisualizerPage { get; private set; }
        private bool _doVisualise = false;

        public MapAnalizer(RoadsMap map, MainPage mainPage, ScannerVisualiserPage visualizerPage, bool doVisualise)
        {
            Map = map;
            _mainPage = mainPage;
            VisualizerPage = visualizerPage;
            _doVisualise = doVisualise;
        }

        public bool Start()
        {
            Utils.DoInAnotherThread(_mainPage.DebugBox, (control) => control.Text = "");
            dotsJSON = "[\r\n";

            // Image analysis 
            Color currentPixelColor;


            // Scanning
            if (Map.CityMapBitmap == null)
            {
                return false;
            }
            Bitmap cityMapTmp = new Bitmap(Map.CityMapBitmap);
            int idCounter = 0;
            for (int i = 0; i < Map.CityMapHeight; i++)
            {
                for (int j = 0; j < Map.CityMapWidth; j++)
                {

                    currentPixelColor = Map.CityMapBitmap.GetPixel(j, i);
                    // detect any color but white
                    // TODO: set range to red color

                    if (!(currentPixelColor.R == 255 && currentPixelColor.G != 255 && currentPixelColor.B != 255))
                    {
                        continue;
                    }

                    bool isGreenFound = false;
                    for (int k = i - Map.RangeBetweenPointsInPixels; k < i + Map.RangeBetweenPointsInPixels; k++)
                    {
                        for (int g = j - Map.RangeBetweenPointsInPixels; g < j + Map.RangeBetweenPointsInPixels; g++)
                        {

                            if (!Utils.isInRange(k, Map.CityMapHeight))
                            {
                                continue;
                            }

                            if (!Utils.isInRange(g, Map.CityMapWidth))
                            {
                                continue;
                            }

                            //if (k < 0 || k >= cityMapHeight)
                            //{
                            //    continue;
                            //}
                            //if (g < 0 || g >= cityMapWidth)
                            //{
                            //    continue;
                            //}
                            //debugBox.Text += $"_{k}, {g}_\r\n";

                            Color newPixelColorInRange = Map.CityMapBitmap.GetPixel(g, k);

                            if (newPixelColorInRange.R == 0 && newPixelColorInRange.G == 255 && newPixelColorInRange.B == 0)
                            {
                                isGreenFound = true;
                            }
                        }
                    }

                    for (int g = j - Map.RangeBetweenPointsInPixels; g < j + Map.RangeBetweenPointsInPixels; g++)
                    {
                        if (!Utils.isInRange(g, Map.CityMapWidth))
                        {
                            continue;
                        }

                        Color newPixelColorInRange = Map.CityMapBitmap.GetPixel(g, i);

                        if (newPixelColorInRange.R == 0 && newPixelColorInRange.G == 255 && newPixelColorInRange.B == 0)
                        {
                            isGreenFound = true;
                        }
                    }

                    if (isGreenFound)
                    {
                        continue;
                    }

                    // // FINDING SIZE

                    // Check for red dots around
                    bool isRightOkay = Utils.isInRange(j + 1, Map.CityMapWidth) 
                        && Utils.IsRedOrGreen(Map.CityMapBitmap.GetPixel(j + 1, i));
                    bool isLeftOkay = Utils.isInRange(j - 1, Map.CityMapWidth) 
                        && Utils.IsRedOrGreen(Map.CityMapBitmap.GetPixel(j - 1, i));
                    bool isTopOkay = Utils.isInRange(i + 1, Map.CityMapHeight) 
                        && Utils.IsRedOrGreen(Map.CityMapBitmap.GetPixel(j, i + 1));
                    bool isBottomOkay = Utils.isInRange(i - 1, Map.CityMapHeight) 
                        && Utils.IsRedOrGreen(Map.CityMapBitmap.GetPixel(j, i - 1));

                    int sizePointX = 0;
                    int sizePointY = 0;
                    int minRoadSize = 99999999;
                    bool slopeReversed = false;
                    if (isRightOkay && isLeftOkay && isTopOkay && isBottomOkay)
                    {
                        minRoadSize = 99999999;
                        double minSlope = 99999999;
                        bool isWhiteStrikedLeft = false;
                        bool isWhiteStrikedRight = false;
                        for (int m = 0; m < 2; m++)
                        {
                            isWhiteStrikedLeft = false;
                            isWhiteStrikedRight = false;
                            foreach (double k in slopes)
                            {
                                // Reset picture before started
                                if (_doVisualise)
                                {
                                    Utils.DoInAnotherThread(VisualizerPage, (control) =>
                                    {
                                        VisualizerPage.MapProcessingPicture.Image = Map.CityMapProcessBitmapInitial;
                                        Map.CityMapProcessBitmap = new Bitmap(Map.CityMapProcessBitmapInitial);
                                        //Map.CityMapProcessBitmap = Map.CityMapProcessBitmapInitial;
                                    });
                                }


                                int roadSizeCount = 0;
                                isWhiteStrikedLeft = false;
                                isWhiteStrikedRight = false;
                                // one line loop
                                for (int x = 0; x < Map.DiagonalMaxCheckSize; x++)
                                {
                                    int y = (int)Math.Round(x * k, MidpointRounding.AwayFromZero);
                                    int xValue = x;
                                    int yValue = y;
                                    if (m == 1)
                                    {
                                        xValue = y;
                                        yValue = x;
                                    }

                                    if (!isWhiteStrikedRight)
                                    {
                                        bool isPixelInRange = Utils.isInRange(j + xValue, Map.CityMapWidth) 
                                            && Utils.isInRange(i + yValue, Map.CityMapHeight);
                                        if (isPixelInRange && Utils.IsRedOrGreen(Map.CityMapBitmap.GetPixel(j + xValue, i + yValue)))
                                        {
                                            roadSizeCount++;
                                            // paint
                                            if (_doVisualise)
                                            {
                                                Utils.DoInAnotherThread(VisualizerPage, (control) =>
                                                {
                                                    Color currentColor = Map.CityMapProcessBitmap.GetPixel(j + xValue, i + yValue);

                                                    Map.CityMapProcessBitmap.SetPixel(j + xValue, i + yValue, Color.Orange);

                                                    VisualizerPage.MapProcessingPicture.Image = new Bitmap(Map.CityMapProcessBitmap);
                                                    //VisualizerPage.MapProcessingPicture.Image = Map.CityMapProcessBitmap;

                                                });
                                                Thread.Sleep(4);
                                            }
                                        }
                                        else if (isPixelInRange 
                                            && !Utils.IsRedOrGreen(Map.CityMapBitmap.GetPixel(j + xValue, i + yValue)))
                                        {
                                            isWhiteStrikedRight = true;
                                        }
                                        else if (!isPixelInRange)
                                        {
                                            // TODO: REMOVE IT
                                            cityMapTmp.SetPixel(j, i, Color.FromArgb(0, 0, 255));
                                            //MessageBox.Show(Convert.ToString(y));
                                        }
                                    }

                                    if (!isWhiteStrikedLeft)
                                    {
                                        bool isPixelInRange = Utils.isInRange(j - xValue, Map.CityMapWidth) 
                                            && Utils.isInRange(i - yValue, Map.CityMapHeight);
                                        if (isPixelInRange && Utils.IsRedOrGreen(Map.CityMapBitmap.GetPixel(j - xValue, i - yValue)))
                                        {
                                            roadSizeCount++;
                                            // paint
                                            if (_doVisualise)
                                            {
                                                Utils.DoInAnotherThread(VisualizerPage, (control) =>
                                                {
                                                    Map.CityMapProcessBitmap.SetPixel(j - xValue, i - yValue, Color.Orange);
                                                    VisualizerPage.MapProcessingPicture.Image = new Bitmap(Map.CityMapProcessBitmap);
                                                    //visualizerPage.MapProcessingPicture.Image = cityMapProcessBitmap;

                                                    VisualizerPage.DebugConsole.Text = $"k = {k}\r\nx = {xValue}";
                                                });
                                            }
                                        }
                                        else if (isPixelInRange && !Utils.IsRedOrGreen(Map.CityMapBitmap.GetPixel(j - xValue, i - yValue)))
                                        {
                                            isWhiteStrikedLeft = true;
                                        }
                                    }
                                }

                                // find minimum road size to get road width
                                if (roadSizeCount < minRoadSize)
                                {
                                    minRoadSize = roadSizeCount;
                                    minSlope = k;
                                    if (m == 1)
                                    {
                                        slopeReversed = true;
                                    }
                                }
                            }
                        }
                        // add 1 (with initial pixel)
                        minRoadSize += 1;


                        // find A and B
                        isWhiteStrikedLeft = false;
                        isWhiteStrikedRight = false;
                        int xA = 0, xB = 0, yA = 0, yB = 0;
                        for (int x = 0; x < Map.DiagonalMaxCheckSize; x++)
                        {
                            int y = (int)(Math.Round(x * minSlope, 0));
                            int xValue = x;
                            int yValue = y;
                            if (slopeReversed)
                            {
                                xValue = y;
                                yValue = x;
                            }

                            if (!isWhiteStrikedRight)
                            {
                                bool isPixelInRange = Utils.isInRange(j + xValue, Map.CityMapWidth) 
                                    && Utils.isInRange(i + yValue, Map.CityMapHeight);

                                if (isPixelInRange && !Utils.IsRedOrGreen(Map.CityMapBitmap.GetPixel(j + xValue, i + yValue)))
                                {
                                    isWhiteStrikedRight = true;
                                    xB = j + xValue;
                                    yB = i + yValue;
                                    // paint
                                    //DoInAnotherThread(visualizerPage, (control) =>
                                    //{
                                    //    cityMapProcessBitmap.SetPixel(xB, yB, Color.Purple);
                                    //    visualizerPage.MapProcessingPicture.Image = new Bitmap(cityMapProcessBitmap);
                                    //    //visualizerPage.MapProcessingPicture.Image = cityMapProcessBitmap;

                                    //});
                                    //Thread.Sleep(10);
                                }
                            }

                            if (!isWhiteStrikedLeft)
                            {
                                bool isPixelInRange = Utils.isInRange(j - xValue, Map.CityMapWidth) 
                                    && Utils.isInRange(i - yValue, Map.CityMapHeight);
                                if (isPixelInRange && !Utils.IsRedOrGreen(Map.CityMapBitmap.GetPixel(j - xValue, i - yValue)))
                                {
                                    isWhiteStrikedLeft = true;
                                    xA = j - xValue;
                                    yA = i - yValue;
                                    //DoInAnotherThread(visualizerPage, (control) =>
                                    //{
                                    //    cityMapProcessBitmap.SetPixel(xA, yA, Color.Red);
                                    //    visualizerPage.MapProcessingPicture.Image = new Bitmap(cityMapProcessBitmap);
                                    //    //visualizerPage.MapProcessingPicture.Image = cityMapProcessBitmap;

                                    //});
                                }
                            }

                            if (x == Map.DiagonalMaxCheckSize - 1 && (!isWhiteStrikedLeft || !isWhiteStrikedRight))
                            {
                                xA = j;
                                yA = i;
                                xB = j;
                                yB = i;
                            }
                        }

                        sizePointX = (xB + xA) / 2;
                        sizePointY = (yB + yA) / 2;
                    }

                    else
                    {
                        continue;
                    }



                    // //




                    dotsJSON += $@"    {{
        ""id"": {idCounter},
        ""x"": {sizePointX},
        ""y"": {sizePointY},
        ""size"": {minRoadSize / 2},
        ""type"": ""car_road""
    }},
";

                    idCounter++;
                    Map.CityMapBitmap.SetPixel(sizePointX, sizePointY, Color.FromArgb(0, 255, 0));

                    // Also show progress in VisualizerPage
                    if (_doVisualise)
                    {
                        Utils.DoInAnotherThread(VisualizerPage, (control) =>
                        {
                            Map.CityMapProcessBitmapInitial.SetPixel(sizePointX, sizePointY, Color.Pink);
                            VisualizerPage.MapProcessingPicture.Image = new Bitmap(Map.CityMapProcessBitmapInitial);
                            VisualizerPage.DebugConsole.Text = $"roadSize = {minRoadSize}\r\nsizePointX = {sizePointX}\r\nsizePointY = {sizePointY}";
                        });
                        Thread.Sleep(1000);
                    }
                }

            }



            // trim last ','
            dotsJSON = dotsJSON.Substring(0, dotsJSON.Length - 3) + "\r\n]";

            Utils.DoInAnotherThread(_mainPage, (control) => {
                _mainPage.DebugBox.Text += "Map has been successfully generated";
            });
            //_mainPage.CityMapPreview.BackgroundImage = new Bitmap(Map.CityMapBitmap);
            //cityMapPreview.SizeMode = PictureBoxSizeMode.Zoom;

            Utils.CreateFile($"{Map.CityMapPath}", "_dots", dotsJSON, "json");

            //visualizerPage.Invoke((MethodInvoker)delegate {
            //    // Running on the UI thread
            //    visualizerPage.InfoLabel.Text = Convert.ToString(i);
            //});

            // Display real range in debugBox
            Map.RangeBetweenPointsInMeters = Map.RangeBetweenPointsInPixels * Map.PixelSizeInMeeters;
            Utils.DoInAnotherThread(_mainPage.DebugBox, 
                (control) => control.Text += $"\r\nReal range between points: {Map.RangeBetweenPointsInMeters}m\r\n");

            Utils.DoInAnotherThread(_mainPage,
                (control) => {
                    _mainPage.Show();
                    VisualizerPage.Hide();
                });
            
            return true;
        }
    }
}
