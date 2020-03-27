using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MarbaxViewer
{
    public class DataManager
    {
        private BinaryFormatter _bf = new BinaryFormatter();
        private string _dataPath = "MarbaxViewer.dat";

        public AppSettings AppSettings;

        public DataManager()
        {
            LoadData();
            if (AppSettings == null)
                AppSettings = new AppSettings();
        }

        public void LoadData()
        {
            try
            {
                using (FileStream fs = new FileStream(_dataPath, FileMode.Open))
                {

                    AppSettings = (AppSettings)_bf.Deserialize(fs);
                }
            }
            catch (SerializationException sex)
            {
                Console.WriteLine($"Serialization load exception : {sex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Serialization load exception : {ex.Message}");
            }
        }
        public void SaveData()
        {
            try
            {
                using (FileStream fs = new FileStream(_dataPath, FileMode.Create))
                {
                    _bf.Serialize(fs, AppSettings);
                }
            }
            catch (SerializationException sex)
            {
                Console.WriteLine($"Serialization save exception : {sex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Serialization save exception : {ex.Message}");
            }
        }

    }
}
