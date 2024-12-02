using System;
using System.Collections.Generic;
using DingoUnityProjectMastering.StringConfigurator.Core.Utils;
using UnityEngine;
using static DingoUnityProjectMastering.StringConfigurator.Core.Utils.StringConstants;

namespace DingoUnityProjectMastering.StringConfigurator.StringTree
{
    [Serializable]
    public abstract class EmptyKeyBranch
    {
        public virtual IEnumerable<string> CollectKeys(string root = "") => ArraySegment<string>.Empty;
    }
    
    [Serializable]
    public class SingleKeyBranch : EmptyKeyBranch
    {
        public string Key;

        public override IEnumerable<string> CollectKeys(string root = "")
        {
            yield return $"{root}{D}{Key}";
        }
    }
    
    [Serializable]
    public class ParentKeyBranch : SingleKeyBranch
    {
        [SerializeReference, SubclassSelector] public List<EmptyKeyBranch> SubKeys;
        
        private string _root;

        public override IEnumerable<string> CollectKeys(string root = "")
        {
            if (string.IsNullOrWhiteSpace(Key) || !Key.Valid())    
                yield break;

            _root = $"{root}{D}{Key}";
            if (SubKeys.Count == 0)
            {
                yield return _root;
                yield break;
            }
            foreach (var subKey in SubKeys)
            {
                foreach (var key in subKey.CollectKeys(_root))
                {
                    yield return key;
                }
            }
        }
    }
}