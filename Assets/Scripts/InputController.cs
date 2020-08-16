using System;
using System.Collections.Generic;
using Commands;
using UnityEngine;

[Serializable]
public struct KeyCommand
{
    public KeyCode Key;
    public InputCommand InputCommand;
}

[CreateAssetMenu(fileName = "InputController", menuName = "Command/InputController")]
public class InputController : ScriptableObject
{
    public static Action<InputCommand> ExecuteInput;
    [SerializeField] private List<KeyCommand> _inputActions = new List<KeyCommand>();
    public List<KeyCommand> InputActions => _inputActions;

    public void Start()
    {
        ScriptableObjectsManager.GameUpdate += Tick;
    }

    private void Tick(float dt)
    {
        foreach (var inputAction in _inputActions)
        {
            if (Input.GetKeyDown(inputAction.Key))
            {
                if (inputAction.InputCommand != null)
                {
                    ExecuteInput?.Invoke(inputAction.InputCommand);
                }
            }
        }
    }
}
