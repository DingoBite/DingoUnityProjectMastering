using DingoUnityExtensions.GlobalProjectConfiguration;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DingoUnityProjectMastering.AnimationMessages
{
#if UNITY_EDITOR
    [InitializeOnLoad]
    public static class Registerer
    {
        static Registerer()
        {
            ScriptableObjectsRootSettings.TryAddKey(nameof(AnimationMessages));
        }
#endif
    }
}