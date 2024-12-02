namespace DingoUnityProjectMastering.StringConfigurator.Core.Utils
{
    public static class StringConfiguratorExtensions
    {
        public static bool Valid(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value != StringConstants.NONE && 
                   value != StringConstants.UNDEFINED && 
                   value != StringConstants.ERROR;
        }
    }
}