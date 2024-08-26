using Assets.Scripts.Keys;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class InputSignals : MonoBehaviour
    {
        #region Singleton

        public static InputSignals Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        #endregion

        public UnityAction OnFirstTimeTouchTaken = delegate { };
        public UnityAction OnInputTaken = delegate { };
        public UnityAction OnInputReleased = delegate { };
        public UnityAction OnEnableInput = delegate { };
        public UnityAction OnDisableInput = delegate { };
        public UnityAction<HorizontalInputParams> OnInputDragged = delegate { };
    }
}
