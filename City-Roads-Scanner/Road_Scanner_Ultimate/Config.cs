using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;

namespace Road_Scanner_Ultimate
{
    internal class Config
    {
        public string mapPath { get; set; }
        public string outputPath { get; set; }
        public int chunkSize { get; set; }
        public int realMapHeight { get; set; }
        public int rangeBetweenPointsInPixels { get; set; }


        // TODO: Add dialog for finding config if it's not initialized
        public static Config ReadConfig(string configPath)
        {
            Config config = null;
            using (FileStream fs = new FileStream(configPath, FileMode.OpenOrCreate))
            {
                try
                {
                    config = JsonSerializer.Deserialize<Config>(fs);
                } catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить конфиг программы");
                }
            }
            return config;
        }

        public void FillInput(Control control, dynamic property)
        {
            control.Text = Convert.ToString(property);
        }
    }


}
