using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XIVRecord.ActLog
{
    public class Act
    {
        public string DataDir
        {
            get
            {
                var appdir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(appdir, "Advanced Combat Tracker");
            }
        }

        public string FFXIVLogDirPath
        {
            get
            {
                var config = Path.Combine(this.DataDir, "Config", "FFXIV_ACT_Plugin.config.xml");
                using (var fs = new FileStream(config, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var doc = XDocument.Load(config);
                    var query = doc.Root
                        .Elements("SettingsSerializer")
                        .Elements("TextBox")
                        .First(e => e.Attribute("Name").Value == "txtLogFileDirectory");
                    var dirpath = query.Attribute("Value").Value;
                    if (Directory.Exists(dirpath))
                        return dirpath;
                    else
                        throw new IOException(string.Format("Directory '{0}' not found", dirpath));
                }
            }
        }

        public LogDir FFXIVLogDir
        {
            get
            {
                var dirpath = this.FFXIVLogDirPath;
                return new LogDir(new DirectoryInfo(dirpath));
            }
        }

        public static Act Default = new Act();
    }
}
