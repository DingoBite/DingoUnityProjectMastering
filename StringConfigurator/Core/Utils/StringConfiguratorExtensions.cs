namespace DingoUnityProjectMastering.StringConfigurator.Core.Utils
{
    public static class StringConfiguratorExtensions
    {
        public static bool ValidateMessageKey(this string value)
        {
            return value != StringConstants.NONE && 
                   value != StringConstants.UNDEFINED && 
                   value != StringConstants.ERROR;
        }
    }
}