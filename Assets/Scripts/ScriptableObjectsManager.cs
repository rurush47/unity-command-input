using System;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectsManager : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private InputController _inputManager;
    public static event Action GameStart;
    public static event Action<float> GameUpdate;
    void Start()
    {
        _inputHandler.Start();
        _inputManager.Start();

        GameStart?.Invoke();
    }

    void Update()
    {
        GameUpdate?.Invoke(Time.deltaTime);
    }
}
