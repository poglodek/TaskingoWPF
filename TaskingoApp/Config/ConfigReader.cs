using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskingoApp.Builder;

namespace TaskingoApp.Config
{
    public class ConfigReader
    {
        private const string FileName = "Config.json";
        public string ApiUrl { get; set; }
        public ConfigReader()
        {
            
        }

        public void ReadConfig()
        {
            if (!File.Exists(FileName)) CreateDefaultConfig();
            var json = File.ReadAllText(FileName);
            var config = JsonConvert.DeserializeObject<ConfigReader>(json);
            Properties.Settings.Default.ApiUrl =  config?.ApiUrl;
        }

        private void CreateDefaultConfig()
        {
            ApiUrl = "https://localhost:5001/";
            var json = JsonConvert.SerializeObject(this);
            using (var stream = File.Create(FileName))
            {
            }
            using (var file = File.AppendText(FileName))
            {
                file.WriteLine(json);
            }
        }
    }
}
