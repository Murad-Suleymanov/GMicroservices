using GMicroservices.Common.Constants;
using System.Resources;

namespace GMicroservices.Common.ResourceValues
{
    public static class ErrorMessageValues
    {
        static ResourceManager _resourceManager = null;

        public static string InternalServerError => GetValues(ErrorMessageNames.InternalServerError);

        public static string GetValues(string key)
        {
            _resourceManager = new ResourceManager(typeof(NetTestTask.Common.Properties.ErrorMessages));

            return _resourceManager.GetString(key);
        }
    }
}
