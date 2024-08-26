using System;
using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoBehaviour
{
    #region Singleton

    public static CoreGameSignals Instance;

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


    public UnityAction<short> OnLevelInitialize = delegate { };
    public UnityAction OnClearActiveLevel = delegate { };
    public Func<byte> OnGetLevelValue = delegate { return 0; };
    public UnityAction OnNextLevel = delegate { };
    public UnityAction OnReset = delegate { };
    public UnityAction OnRestartLevel = delegate { };
} 
