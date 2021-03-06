using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Yaml.Serialization;
using System.Yaml;
using System.IO;
using Brevitee;

namespace Brevitee.Yaml
{
    public static class Extensions
    {
        /// <summary>
        /// Serialize the specified object to yaml
        /// </summary>
        /// <param name="val"></param>
        /// <param name="conf"></param>
        /// <returns></returns>
        public static string ToYaml(this object val, YamlConfig conf = null)
        {
            YamlSerializer ser = conf == null ? new YamlSerializer() : new YamlSerializer(conf);
            return ser.Serialize(val);
        }

        public static void ToYamlFile(this object val, string filePath, YamlConfig conf = null)
        {
            ToYamlFile(val, new FileInfo(filePath), conf);
        }

        public static void ToYamlFile(this object val, FileInfo file, YamlConfig conf = null)
        {
            using (StreamWriter sw = new StreamWriter(file.FullName))
            {
                sw.Write(val.ToYaml());
            }
        }
        
        public static object[] FromYaml(this string yaml, params Type[] expectedTypes)
        {
            YamlSerializer ser = new YamlSerializer();
            return ser.Deserialize(yaml, expectedTypes);
        }

        public static object[] FromYamlFile(this string filePath, params Type[] expectedTypes)
        {
            YamlSerializer ser = new YamlSerializer();
            return ser.DeserializeFromFile(filePath, expectedTypes);
        }
        
		public static object[] FromYamlFile(this FileInfo file, params Type[] expectedTypes)
		{
			return File.ReadAllText(file.FullName).FromYaml(expectedTypes);
		}

        public static T FromYaml<T>(this FileInfo file, params Type[] expectedTypes)
        {
            return FromYaml<T>(File.ReadAllText(file.FullName));
        }

        public static T FromYaml<T>(this string yaml)
        {
            return yaml.ArrayFromYaml<T>().FirstOrDefault();
        }

        public static T[] ArrayFromYaml<T>(this string yaml)
        {
            YamlSerializer ser = new YamlSerializer();
            YamlConfig c = new YamlConfig();
            object[] des = ser.Deserialize(yaml, typeof(T));
            return des.Each<T>((o) =>
            {
                return (T)o;
            });
        }
    }
}
