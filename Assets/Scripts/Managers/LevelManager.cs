using Assets.Scripts.Commands.Level;
using Assets.Scripts.Data.ValueObjects;
using UnityEngine;

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
        GetLevelData();
        GetActiveLevel();

        Init();
    }

    private void Start()
    {
        CoreGameSignals.Instance.OnLevelInitialize?.Invoke((byte)(_currentLevel % _totalLevelCount));
        //UISignals
    }

    private void Init()
    {
        _levelLoaderCommand = new OnLevelLoaderCommand(_levelHolder);
        _levelDestroyerCommand = new OnLevelDestroyerCommand(_levelHolder);

        _levelLoaderCommand.Execute(_currentLevel);
    }

    private void GetLevelData()
    {
        _levelData = Resources.Load<CD_Level>("Data/CD_Level").Levels[_currentLevel];
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
