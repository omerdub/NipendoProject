using Newtonsoft.Json;
using nipendo_project.Services.Interfaces;
using System.IO;

namespace nipendo_project.Services.Implementations
{
    internal class JsonService : IJsonService
    {
        public T Deserialize<T>(string path)
        {
            // First check if file exists, then returning deserialized json object
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found", path);
            string rawJson = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(rawJson);
        }
    }
}
