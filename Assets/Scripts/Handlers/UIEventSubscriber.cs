using Assets.Scripts.Enums;
using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Handlers
{
    public class UIEventSubscriber : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIEventSubscriptionTypes _type;
        [SerializeField] private Button _button;

        #endregion

        #region Private Variables

        private UIManager _manager;

        #endregion

        #endregion


        private void Awake()
        {
            FindReferences();
        }

        private void FindReferences()
        {
           _manager = FindObjectOfType<UIManager>();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            switch (_type)
            {
                case UIEventSubscriptionTypes.Play:
                    _button.onClick.AddListener(() => _manager.Play());
                    break;

                case UIEventSubscriptionTypes.RestartLevel:
                    _button.onClick.AddListener(() => _manager.RestartLevel());
                    break;

                case UIEventSubscriptionTypes.NextLevel:
                    _button.onClick.AddListener(() => _manager.NextLevel());
                    break;
                default:
                    break;
            }
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            switch (_type)
            {
                case UIEventSubscriptionTypes.Play:
                    _button.onClick.RemoveListener(() => _manager.Play());
                    break;

                case UIEventSubscriptionTypes.RestartLevel:
                    _button.onClick.RemoveListener(() => _manager.RestartLevel());
                    break;

                case UIEventSubscriptionTypes.NextLevel:
                    _button.onClick.RemoveListener(() => _manager.NextLevel());
                    break;
                default:
                    break;
            }
        }
    }
}
