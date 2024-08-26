using Assets.Scripts.Extensions;
using Assets.Scripts.Keys;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction OnFirstTimeTouchTaken = delegate { };
        public UnityAction OnInputTaken = delegate { };
        public UnityAction OnInputReleased = delegate { };
        public UnityAction OnEnableInput = delegate { };
        public UnityAction OnDisableInput = delegate { };
        public UnityAction<HorizontalInputParams> OnInputDragged = delegate { };
    }
}
