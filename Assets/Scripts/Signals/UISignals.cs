using Assets.Scripts.Extensions;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<byte> OnSetStageColor = delegate { };
        public UnityAction<byte> OnSetLevelValue = delegate { };
        public UnityAction OnPlay = delegate { };
    }
}
