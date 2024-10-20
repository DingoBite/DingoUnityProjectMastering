using System;
using System.Collections.Generic;
using DingoUnityProjectMastering.StringConfigurator.Core.Utils;
using UnityEngine;

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
            yield return $"{root}/{Key}";
        }
    }
    
    [Serializable]
    public class ParentKeyBranch : SingleKeyBranch
    {
        [SerializeReference, SubclassSelector] public List<EmptyKeyBranch> SubKeys;
        
        private string _root;

        public override IEnumerable<string> CollectKeys(string root = "")
        {
            if (string.IsNullOrWhiteSpace(Key) || !Key.ValidateMessageKey())    
                yield break;

            _root = $"{root}/{Key}";
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