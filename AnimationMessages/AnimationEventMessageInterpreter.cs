using RotaryHeart.Lib.AutoComplete;
using UnityEngine;

namespace DingoUnityProjectMastering.AnimationMessages
{
    public class AnimationEventMessageInterpreter : AnimationMessagesBaseBehaviour
    {
        [SerializeField, AutoCompleteDropDown(nameof(KeysTree), returnFullPath: true)] private string _key;

        public string Key => _key;
    
        public void ReceiveMessage(AnimationEvent animationEvent)
        {
            Debug.Log($"{name}: {animationEvent}");
        }
    }
}