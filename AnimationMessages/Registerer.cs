using DingoUnityExtensions.GlobalProjectConfiguration;
using UnityEditor;

namespace DingoUnityProjectMastering.AnimationMessages
{
    public static class Registerer
    {
        [InitializeOnLoadMethod]
        public static void Register()
        {
            ScriptableObjectsRootSettings.TryAddKey(nameof(AnimationMessages));
        }
    }
}