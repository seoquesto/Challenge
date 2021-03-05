using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Challenge
{
  class WindowsConfigurationManager : IConfigurationManager
  {
    private const string ConfigFileName = "configuration.json";

    public LoanConfiguration GetConfiguration()
    {
      string textConfig = System.IO.File.ReadAllText(ConfigLocation());
      return JsonConvert.DeserializeObject<LoanConfiguration>(System.IO.File.ReadAllText(ConfigLocation()));
    }

    private static string ConfigLocation()
    {
      string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      return Path.Combine(executableLocation, ConfigFileName);
    }
  }
}