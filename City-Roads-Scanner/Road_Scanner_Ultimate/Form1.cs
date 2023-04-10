using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Drawing.Imaging;
using System.Security;
using Newtonsoft.Json.Linq;

namespace Road_Scanner_Ultimate
{
    public partial class MainPage : Form
    {
        private string progPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private string _actualRedDotMapTextBoxPath = "";
        public TextBox DebugBox { get; set; }
        public PictureBox CityMapPreview { get; set; }

        RoadsMap map;
        ScannerVisualiserPage visualizerPage;
        MapAnalizer mapAnalizer;
        Config config;

        private void Form1_Load(object sender, EventArgs e)
        {
            visualizerPage = new ScannerVisualiserPage(this);

            config = Config.ReadConfig($@"{progPath}\app-config.json");
            //MessageBox.Show(Convert.ToString(config.rangeBetweenPointsInPixels));
            if (config != null)
            {
                config.FillInput(redMapPathTextBox, config.mapPath);
            }
            

            initializeFormProperties();
            if (config != null)
            {
                UpdateMap(config.mapPath);
                config.FillInput(rangeInPixelTextBox, config.rangeBetweenPointsInPixels);
                config.FillInput(realMapHeightInMeetersTextBox, config.realMapHeight);
                config.FillInput(chunkSizeTextBox, config.chunkSize);
            }
            rangeInPixelTextBox.Text = rangeInPixelTextBox.Text += " "; // TODO: Make it analyze without this string

            _actualRedDotMapTextBoxPath = redMapPathTextBox.Text;

        }

        private void UpdateMap(string mapPath)
        {
            if (mapPath == _actualRedDotMapTextBoxPath)
            {
                return;
            }
            _actualRedDotMapTextBoxPath = mapPath;
            // Initialize map properties
            map = new RoadsMap
            {
                DiagonalMaxCheckSize = 25,
                CityMapPath = mapPath
            };
            mapAnalizer = new MapAnalizer(map, this, visualizerPage, visualiseCheckBox.Checked);

            // Assign form fields
            DebugBox = debugBox;
            CityMapPreview = cityMapPreview;


            string mapSizeInfo = map.AssignPreviewImage(cityMapPreview);
            debugBox.Text += $"\r\n{mapSizeInfo}\r\n";
        }

        Color initTextBoxColor;
        Size pathTextBoxesSize;
        private void initializeFormProperties()
        {
            initTextBoxColor = rangeInPixelTextBox.BackColor;
            redMapPathTextBox.BringToFront();

            pathTextBoxesSize = redMapPathTextBox.Size;

            // Assign click to every control (necessary to return textboxes to default after enlargment)
            foreach (Control control in this.Controls)
            {
                control.Click += MainPage_Click;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (visualiseCheckBox.Checked)
            {
                visualizerPage.Show();
                this.Hide();
                visualizerPage.PrepareAndShowBitmap(map);
            }

            // Start Analysis in a new Thread
            if (mapAnalizer == null)
            {
                return;
            }
            Task.Run(() => { mapAnalizer.Start(); });
        }


        private void button2_Click(object sender, EventArgs e)
        {
           debugBox.Text = PointsProcesser.PutDotsIntoChunks(Utils.SelectFolderDialog(progPath), config.chunkSize, map);
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void createPicButton_Click(object sender, EventArgs e)
        {
            debugBox.Text = PointsProcesser.PutDotsIntoImage(Utils.SelectFolderDialog(progPath), "", map);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Returns numeric value from textbox. Returns -1 if doesn't pass
        private int PassNumericValueThroughTextBox(TextBox textBox)
        {
            int textBoxValue = -1;
            try
            {
                textBoxValue = Convert.ToInt32(textBox.Text);
                if (textBoxValue < 0)
                {
                    textBoxValue = -1;
                    throw new ArgumentException("Cant be less than 0");
                }
                textBox.BackColor = initTextBoxColor;
                if (map != null)
                {
                    map.RangeBetweenPointsInPixels = textBoxValue;
                }
            }
            catch (Exception ex)
            {
                textBox.BackColor = Color.IndianRed;
            }

            return textBoxValue;
        }

        // Handle change of TextBox value 
        private void realMapHeightInMeetersTextBox_TextChanged(object sender, EventArgs e)
        {
            int realMapHeight = PassNumericValueThroughTextBox(realMapHeightInMeetersTextBox);
            
            // Calculate pixel size in meeters
            if (realMapHeight != -1)
            {
                if (map != null)
                {
                    map.PixelSizeInMeeters = Math.Round((1.0 * realMapHeight / map.CityMapHeight), 4);
                }
            }
        }
                
        private void rangeInPixelTextBox_TextChanged(object sender, EventArgs e)
        {
            int rangeInPixels = PassNumericValueThroughTextBox(rangeInPixelTextBox);
            
            if (rangeInPixels != -1)
            {
                if (map != null)
                {
                    map.RangeBetweenPointsInPixels = rangeInPixels;
                }
            }
        }

        private void chunkSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            int chunkSize = PassNumericValueThroughTextBox(chunkSizeTextBox);

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        // Enlarge TextBoxes on Enter
        private void redMapPathTextBox_Enter(object sender, EventArgs e)
        {
            redMapPathTextBox.Size = new Size(700, 20);
        }

        private void redMapPathTextBox_Leave(object sender, EventArgs e)
        {
            redMapPathTextBox.Size = pathTextBoxesSize;
        }


        // Handle click at any Control
        private void MainPage_Click(object sender, EventArgs e)
        {
            // Reset size for path TextBoxes if clicked somewhere else (defocusing)
            if (sender != redMapPathTextBox)
            {
                this.ActiveControl = null;


                // Initialize map properties
                if (redMapPathTextBox.Text != config.mapPath)
                {

                    try
                    {
                        UpdateMap(redMapPathTextBox.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Приозошла ошибка. Попробуйте выбрать другой файл карты");
                    }

                }


                /*try
                {
                    UpdateMap(redMapPathTextBox.Text, outputDirectoryPathTextBox.Text);
                }
                catch
                {
                    MessageBox.Show("Приозошла ошибка. Попробуйте выбрать другой файл карты");
                }*/



                rangeInPixelTextBox.Text = rangeInPixelTextBox.Text += " "; // TODO: Make it analyze without this string
            }
        }

        private void mapPathButton_Click(object sender, EventArgs e)
        {
            // As argument using project path
            string filePath = Utils.SelectFileDialog(progPath);
            if (filePath == "")
            {
                return;
            }

            redMapPathTextBox.Text = filePath;
        }

        private void outputPathButton_Click(object sender, EventArgs e)
        {
            string folderPath = Utils.SelectFolderDialog(progPath);
            if (folderPath == "")
            {
                return;
            }

        }
    }
}
