using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using NaughtyAttributes;
using UnityEngine;

namespace DingoUnityProjectMastering.StringConfigurator.StringTree
{
    [CreateAssetMenu(menuName = nameof(StringsConfigTreeKeys) + "/" + nameof(StringsConfigTreeKeys), fileName = nameof(StringsConfigTreeKeys), order = 0)]
    public class StringsConfigTreeKeys : ScriptableObject
    {
        [SerializeField] private SerializedDictionary<string, ParentKeyBranch> _messageKeyRoots;
        [SerializeField] private List<string> _messageKeysPaths;
        
        private List<string> CollectKeys()
        {
            return _messageKeyRoots.OrderBy(p => p.Key).SelectMany(e => e.Value.CollectKeys(e.Key)).ToList();
        }

        [Button]
        private void BackPaths()
        {
            if (_messageKeyRoots == null)
                return;

            _messageKeysPaths = CollectKeys();
        }

        public IReadOnlyList<string> Keys
        {
            get
            {
                if (_messageKeysPaths == null || _messageKeysPaths.Count == 0)
                    _messageKeysPaths = CollectKeys();
                return _messageKeysPaths;
            }
        }
    }
}