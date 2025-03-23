using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using NaughtyAttributes;
using UnityEngine;

namespace DingoUnityProjectMastering.StringConfigurator.StringTree
{
    [CreateAssetMenu(menuName = nameof(StringConfigurator) + "/" + nameof(StringsConfigTreeKeys), fileName = nameof(StringsConfigTreeKeys), order = 0)]
    public class StringsConfigTreeKeys : ScriptableObject
    {
        [SerializeField] private SerializedDictionary<string, ParentKeyBranch> _roots;
        [SerializeField] private List<string> _paths;

        private List<string> CollectKeys()
        {
            return _roots.OrderBy(p => p.Key).SelectMany(e => e.Value.CollectKeys(e.Key)).ToList();
        }
        
        [Button]
        private void BakePaths()
        {
            if (_roots == null)
                return;

            _paths = CollectKeys();
        }

        public IReadOnlyList<string> Keys
        {
            get
            {
                if (_paths == null || _paths.Count == 0)
                    _paths = CollectKeys();
                return _paths;
            }
        }
    }
}