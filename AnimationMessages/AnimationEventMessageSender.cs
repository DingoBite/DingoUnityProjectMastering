using System.Linq;
using RotaryHeart.Lib.AutoComplete;
using UnityEngine;

namespace DingoUnityProjectMastering.AnimationMessages
{
    public class AnimationEventMessageSender : AnimationMessagesBaseBehaviour
    {
        [SerializeField, AutoCompleteDropDown(nameof(KeysTree), allowEmpty: false, returnFullPath: true)] private string _key;
        [SerializeField] private AnimationEventMessagingSystem _bus;

        public void Message(AnimationEvent animationEvent)
        {
            _bus.Invoke(_key, animationEvent);
        }

        private void Reset()
        {
            _bus = Resources.FindObjectsOfTypeAll<AnimationEventMessagingSystem>().FirstOrDefault();
        }
    }
}