using Assets.Scripts.Extensions;
using System;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction<short> OnLevelInitialize = delegate { };
        public UnityAction OnClearActiveLevel = delegate { };
        public Func<byte> OnGetLevelValue = delegate { return 0; };
        public UnityAction OnNextLevel = delegate { };
        public UnityAction OnReset = delegate { };
        public UnityAction OnRestartLevel = delegate { };
        public UnityAction OnLevelSuccesful = delegate { };
        public UnityAction OnLevelFailed = delegate { };
    }
}
