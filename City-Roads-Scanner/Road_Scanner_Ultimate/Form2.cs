using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Road_Scanner_Ultimate
{
    public partial class ScannerVisualiserPage : Form
    {
        // TODO: Make fields private?
        public PictureBox MapProcessingPicture { get; set; }
        public TextBox DebugConsole { get; set; }
        public MainPage MainPage { get; private set; }

        public ScannerVisualiserPage(MainPage mainPage)
        {
            InitializeComponent();
            MainPage = mainPage;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MapProcessingPicture = mapProcessingPicture;
            DebugConsole = debugConsole;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Preprocessing image before apply
        internal void PrepareAndShowBitmap(RoadsMap map)
        {
            // Create another bitmap for VisualizerPage
            map.CityMapProcessBitmap = new Bitmap(map.CityMapBitmap);
            Bitmap cityMapProcessBitmap = map.CityMapProcessBitmap;

            // Apply black and white filter to bitmap
            int rgb; Color c;
            for (int y = 0; y < cityMapProcessBitmap.Height; y++)
                for (int x = 0; x < cityMapProcessBitmap.Width; x++)
                {
                    c = cityMapProcessBitmap.GetPixel(x, y);
                    rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    cityMapProcessBitmap.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            map.CityMapProcessBitmapInitial = new Bitmap(cityMapProcessBitmap);

            // Apply preview settings
            MapProcessingPicture.Image = cityMapProcessBitmap;
            MapProcessingPicture.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
