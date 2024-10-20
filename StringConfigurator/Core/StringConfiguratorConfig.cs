using DingoUnityProjectMastering.StringConfigurator.StringTree;
using UnityEngine;

namespace DingoUnityProjectMastering.StringConfigurator.Core
{
    [CreateAssetMenu(menuName = nameof(StringConfigurator) + "/" + nameof(StringConfiguratorConfig), fileName = nameof(StringConfiguratorConfig), order = 0)]
    public class StringConfiguratorConfig : ScriptableObject
    {
        [field: SerializeField] public StringsConfigTreeKeys StringsConfigTreeKeys { get; private set; }
    }
}