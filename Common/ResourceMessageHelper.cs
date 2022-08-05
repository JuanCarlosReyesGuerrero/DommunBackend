using System.Reflection;
using System.Resources;

namespace Common
{
    public class ResourceMessageHelper
    {
        public static string GetMessage(string key)
        {
            ResourceManager rm = new ResourceManager("Dommun.API.Resources.DommunResource",
               Assembly.GetExecutingAssembly());
            return rm.GetString(key);
        }
    }
}
