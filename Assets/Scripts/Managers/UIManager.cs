using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        private void OnEnable()
        {
            SubscribeEvent();
        }

        private void SubscribeEvent()
        {
            CoreGameSignals.Instance.OnLevelInitialize += OnLevelInitialize;
            CoreGameSignals.Instance.OnLevelSuccesful += OnLevelSuccesful;
            CoreGameSignals.Instance.OnLevelFailed += OnLevelFailed;
            CoreGameSignals.Instance.OnReset += OnReset;
        }

        private void OnLevelFailed()
        {
            CoreUISignals.Instance.OnOpenPanel?.Invoke(UIPanelTypes.Fail, 2);
        }

        private void OnLevelSuccesful()
        {
            CoreUISignals.Instance.OnOpenPanel?.Invoke(UIPanelTypes.Win, 2);
        }

        private void OnReset()
        {
            CoreUISignals.Instance.OnCloseAllPanels?.Invoke();
            CoreUISignals.Instance.OnOpenPanel?.Invoke(UIPanelTypes.Start, 1);
        }

        private void OnLevelInitialize(short value)
        {
            CoreUISignals.Instance.OnOpenPanel?.Invoke(UIPanelTypes.Level, 0);
            UISignals.Instance.OnSetLevelValue?.Invoke((byte)CoreGameSignals.Instance.OnGetLevelValue?.Invoke());
        }

        private void OnDisable()
        {
            UnsubscribeEvent();
        }

        private void UnsubscribeEvent()
        {
            CoreGameSignals.Instance.OnLevelInitialize -= OnLevelInitialize;
            CoreGameSignals.Instance.OnLevelSuccesful -= OnLevelSuccesful;
            CoreGameSignals.Instance.OnLevelFailed -= OnLevelFailed;
            CoreGameSignals.Instance.OnReset -= OnReset;
        }

        public void NextLevel()
        {
            CoreGameSignals.Instance.OnNextLevel?.Invoke();
        }

        public void Play()
        {
            UISignals.Instance.OnPlay?.Invoke();
            CoreUISignals.Instance.OnClosePanel?.Invoke(1);
            InputSignals.Instance.OnEnableInput?.Invoke();
        }

        public void RestartLevel()
        {
            CoreGameSignals.Instance.OnRestartLevel?.Invoke();
            CoreGameSignals.Instance.OnReset?.Invoke();
        }

        public void Reset()
        {
            CoreGameSignals.Instance.OnRestartLevel?.Invoke();

        }
    }
}
