using Assets.Scripts.Commands.Level;
using Assets.Scripts.Data.ValueObjects;
using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using UnityEngine;


namespace Assets.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Transform _levelHolder;
        [SerializeField] private byte _totalLevelCount;

        #endregion

        #region Private Variables

        private OnLevelLoaderCommand _levelLoaderCommand;
        private OnLevelDestroyerCommand _levelDestroyerCommand;

        private short _currentLevel;
        private LevelData _levelData;

        #endregion

        #endregion

        private void Awake()
        {
            GetActiveLevel();
            GetLevelData();

            Init();
        }

        private void Start()
        {
            CoreUISignals.Instance.OnOpenPanel?.Invoke(UIPanelTypes.Start, 1);
            CoreGameSignals.Instance.OnLevelInitialize?.Invoke((byte)(_currentLevel % _totalLevelCount));
        }

        private void Init()
        {
            _levelLoaderCommand = new OnLevelLoaderCommand(_levelHolder);
            _levelDestroyerCommand = new OnLevelDestroyerCommand(_levelHolder);

            _levelLoaderCommand.Execute(_currentLevel);
        }

        private void GetLevelData()
        {
            var leves = Resources.Load<CD_Level>("Data/CD_Level");

            if (leves is null or { Levels: null }) return;

            _levelData = leves.Levels[_currentLevel];
        }

        private void GetActiveLevel()
        {
            _currentLevel = 0;
        }

        private void OnEnable() => SubscribeEvents();

        private void OnDisable() => UnsubscribeEvents();

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnLevelInitialize += _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.OnClearActiveLevel += _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.OnGetLevelValue += OnGetLevelValue;
            CoreGameSignals.Instance.OnNextLevel += OnNextLevel;
            CoreGameSignals.Instance.OnRestartLevel += OnRestartLevel;
        }

        private byte OnGetLevelValue() => (byte)_currentLevel;

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.OnLevelInitialize -= _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.OnClearActiveLevel -= _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.OnGetLevelValue -= OnGetLevelValue;
            CoreGameSignals.Instance.OnNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.OnRestartLevel -= OnRestartLevel;
        }

        private void OnNextLevel()
        {
            _currentLevel++;
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.OnReset?.Invoke();
            CoreGameSignals.Instance.OnLevelInitialize?.Invoke((byte)(_currentLevel % _totalLevelCount));
        }

        private void OnRestartLevel()
        {
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.OnReset?.Invoke();
            CoreGameSignals.Instance.OnLevelInitialize?.Invoke((byte)(_currentLevel % _totalLevelCount));
        }
    }
}
