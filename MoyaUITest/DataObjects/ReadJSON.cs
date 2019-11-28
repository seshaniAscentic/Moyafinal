using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Reflection;

namespace MoyaUITest.DataObjects
{
    public static class ReadJSON
    {
        public static Rootobject _data;

        /// <summary>
        /// Reading the JSON file and adding JSON Object to the Class Object
        /// </summary>
        static ReadJSON()
        {
            var webClient = new WebClient();
            var rawJSON = webClient.DownloadString(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/DataCollection.json");
            _data = JsonConvert.DeserializeObject<Rootobject>(rawJSON);
        }

        /// <summary>
        /// Getting the Test Data from the JSON file by calling section with key pair 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetData(string section, string key)
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("DataCollection.json", optional: false, reloadOnChange: true)
            .Build();
            var value = config.GetSection(section + ":" + key).Value;
            return value;
        }
    }
}
