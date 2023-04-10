using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Road_Scanner_Ultimate
{
    internal static class Utils
    {
        // TODO: Refactor try catch 
        public static void DoInAnotherThread(Control someControl, Action<Control> callbackAction)
        {
            try
            {
                someControl.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    callbackAction(someControl);
                    // example: visualizerPage.InfoLabel.Text = Convert.ToString();
                });
            }
            catch (Exception ex)
            {

            }
        }

        public static Boolean IsRedOrGreen(Color pixelColor)
        {
            bool isRed = pixelColor.R == 255 && pixelColor.G != 255 && pixelColor.B != 255;
            bool isGreen = pixelColor.R == 0 && pixelColor.G == 255 && pixelColor.B == 0;
            return (isRed || isGreen);
        }
        public static Boolean IsWhite(Color pixelColor)
        {
            bool isWhite = pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255;
            return (isWhite);
        }
        public static Boolean isInRange(int initialValue, int maxValue)
        {
            return initialValue > 0 && initialValue < maxValue;
        }

        public static void CreateFile(string path, string filename, string text, string format)
        {

            // Get amount of previously created files from File
            string filesCreatedAmountFullPath = $@"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\filesCreatedAmount.txt";
            string filesCreatedAmount = "";
            using (StreamReader sr = File.OpenText(filesCreatedAmountFullPath))
            {
                filesCreatedAmount = sr.ReadLine();
            }

            // Update amount of previously created files in File
            using (StreamWriter sw = File.CreateText(filesCreatedAmountFullPath))
            {
                filesCreatedAmount = Convert.ToString(Convert.ToInt64(filesCreatedAmount) + 1);
                sw.WriteLine(filesCreatedAmount);
            }


            // Create File with certain text
            string fullPath = $@"{path}_{filename}_{filesCreatedAmount}.{format}";

            using (StreamWriter sw = File.CreateText(fullPath))
            {
                sw.WriteLine(text);
            }
        }

        public static string SelectFileDialog(string initialPath)
        {
            String filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = initialPath;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }

            return filePath;
        }

        public static string SelectFolderDialog(string initialPath)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            string folderPath = "";

            // Show the FolderBrowserDialog
            folderBrowserDialog.SelectedPath = initialPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;  
            }

            return folderPath;
        }
    }
}
