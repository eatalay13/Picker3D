using Assets.Scripts.Enums;
using Assets.Scripts.Extensions;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class CoreUISignals : MonoSingleton<CoreUISignals>
    {
        public UnityAction<UIPanelTypes, int> OnOpenPanel = delegate { };
        public UnityAction<int> OnClosePanel = delegate { };
        public UnityAction OnCloseAllPanels = delegate { };
    }
}
