using System.Collections.Generic;
using DingoUnityExtensions.GlobalProjectConfiguration;
using DingoUnityProjectMastering.StringConfigurator.Core;
using DingoUnityProjectMastering.StringConfigurator.Core.Utils;
using NaughtyAttributes;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace DingoUnityProjectMastering.AnimationMessages
{
    public abstract class AnimationMessagesBaseScriptableObject : ScriptableObject
    {
        protected IReadOnlyList<string> KeysTree
        {
            get
            {
                var config = ScriptableObjectsRootSettings.GetTypedConfigByKey<StringConfiguratorConfig>(nameof(AnimationMessages));
                return config?.StringsConfigTreeKeys?.Keys ?? InspectorUtils.SingleNoneList;
            }
        }
        
#if UNITY_EDITOR
        [Button]
        private void SelectConfig()
        {
            var config = ScriptableObjectsRootSettings.GetTypedConfigByKey<StringConfiguratorConfig>(nameof(AnimationMessages));
            if (config?.StringsConfigTreeKeys != null)
                EditorUtility.OpenPropertyEditor(config.StringsConfigTreeKeys);
        }
#endif
    }
}