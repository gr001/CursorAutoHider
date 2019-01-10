using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CursorAutoHider
{
    sealed public class AppSettings
    {
        static AppSettings s_settings;
        public static AppSettings Instance
        {
            get
            {
                if (s_settings == null)
                {
                    string settingsPath = GetSettingFilepath();
                    StreamReader myXmlReader = null;

                    if (File.Exists(settingsPath))
                    {
                        XmlSerializer mySerializer = new XmlSerializer(typeof(AppSettings));
                        myXmlReader = new StreamReader(settingsPath);

                        try
                        {
                            s_settings = (AppSettings)mySerializer.Deserialize(myXmlReader);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Failed when reading settings\n" + e.Message);
                        }
                        finally
                        {
                            myXmlReader.Dispose();
                        }
                    }

                    if (s_settings == null)
                        s_settings = new AppSettings();
                }

                return s_settings;
            }
        }

        public bool Save()
        {

            XmlSerializer mySerializer = new XmlSerializer(typeof(AppSettings));
            StreamWriter myXmlWriter = null;
            try
            {
                myXmlWriter = new StreamWriter(GetSettingFilepath());
                mySerializer.Serialize(myXmlWriter, this);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error when saving settings\n" + e.Message);
            }
            finally
            {
                if (myXmlWriter != null)
                    myXmlWriter.Dispose();
            }

            return false;
        }

        static string GetSettingFilepath()
        {
            string folder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            return System.IO.Path.Combine(folder, "settings.xml");
        }

        public int DistanceThreshold { get; set; } = 5;
        public int TimeThresholdS { get; set; } = 3;
        public string WatchedApplication { get; set; } = "O2TV.UWP";
    }
}
