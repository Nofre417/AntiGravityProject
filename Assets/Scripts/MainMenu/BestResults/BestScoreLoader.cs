using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MainMenu
{
    public static class BestScoreLoader
    {
        public static void SaveResults(string path, object data)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter binaryFormatter = new();
                
                binaryFormatter.Serialize(stream, data);
            }
        }

        public static T LoadResults<T>(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new();

                T data = (T) binaryFormatter.Deserialize(stream);
                return data;
            }
        }
    }
}