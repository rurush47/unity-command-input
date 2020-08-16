using UnityEngine;

[CreateAssetMenu(fileName = "InputHandler", menuName = "Command/InputHandler")]
public class InputHandler : ScriptableObject
{
    private CommandQueue _commandQueue = new CommandQueue(3);

    public void Start()
    {
        ScriptableObjectsManager.GameStart += Init;
    }

    private void Init()
    {
        InputController.ExecuteInput += command =>
        {
            command = Instantiate(command);
            command = command.Init();
            if (command != null)
            {
                command.Execute();
                if (command.HistoryTrackable)
                {
                    _commandQueue.Add(command);
                }
            }
        };
    }

    public void Undo()
    {
        _commandQueue.Undo();
    }

    public void Redo()
    {
        _commandQueue.Redo();
    }
}
