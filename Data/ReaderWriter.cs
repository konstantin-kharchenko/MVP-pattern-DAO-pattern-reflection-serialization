using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    public class ReaderWriter
    {
        public static T Read<T>(string connectionString)
        {
            if (File.Exists(connectionString))
            {
                T Array;
                var format = new XmlSerializer(typeof(T));
                using (Stream fstream = File.OpenRead(connectionString))
                {
                    Array = (T)format.Deserialize(fstream);
                }
                return Array;
            }
            return default;

        }

        public static void Write<T>(string connectionString, T a3)
        {
            XmlSerializer format = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(connectionString, FileMode.Create))
            {
                format.Serialize(fs, a3);
            }
        }
    }
}
