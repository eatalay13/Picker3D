using Assets.Scripts.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class CoreUISignals : MonoBehaviour
    {
        #region Singleton

        public static CoreUISignals Instance;

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

        public UnityAction<UIPanelTypes, int> OnOpenPanel = delegate { };
        public UnityAction<int> OnClosePanel = delegate { };
        public UnityAction OnCloseAllPanels = delegate { };
    }
}
