using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.UI
{
    public class UIPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<Transform> _layers = new();

        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreUISignals.Instance.OnClosePanel += OnClosePanel;
            CoreUISignals.Instance.OnOpenPanel += OnOpenPanel;
            CoreUISignals.Instance.OnCloseAllPanels += OnCloseAllPanels;
        }

        private void OnClosePanel(int value)
        {
            if (_layers[value].childCount <= 0) return;

#if UNITY_EDITOR
            DestroyImmediate(_layers[value].GetChild(0).gameObject);
#else
            Destroy(_layers[value].GetChild(0).gameObject);
#endif
        }

        private void OnOpenPanel(UIPanelTypes panelType, int value)
        {
            OnClosePanel(value);

            Instantiate(Resources.Load<GameObject>($"Screens/{panelType}Panel"), _layers[value]);
        }

        private void OnCloseAllPanels()
        {
            foreach (var layer in _layers)
            {
                if (layer.childCount <= 0) continue;
#if UNITY_EDITOR
                DestroyImmediate(layer.GetChild(0).gameObject);
#else
                Destroy(layer.GetChild(0).gameObject);
#endif
            }
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            CoreUISignals.Instance.OnClosePanel -= OnClosePanel;
            CoreUISignals.Instance.OnOpenPanel -= OnOpenPanel;
            CoreUISignals.Instance.OnCloseAllPanels -= OnCloseAllPanels;
        }
    }
}
