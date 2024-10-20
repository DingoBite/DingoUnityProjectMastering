using System.Collections.Generic;
using System.Linq;
using DingoUnityExtensions.Utils;
using NaughtyAttributes;
using UnityEngine;

namespace DingoUnityProjectMastering.AnimationMessages
{
    public class AnimationEventMessagingSystem : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private List<AnimationEventMessageInterpreter> _interpreters;
    
        public void Invoke(string key, AnimationEvent e)
        {
            _interpreters.FirstOrDefault(messageInterpreter => messageInterpreter.Key == key)?.ReceiveMessage(e);
        }

        [Button]
        private void FindInterpereters()
        {
            if (_parent != null)
                _interpreters = _parent.FindComponents<AnimationEventMessageInterpreter>();
        }

        private void Reset()
        {
            _parent = transform;
        }
    }
}