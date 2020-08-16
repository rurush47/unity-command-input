using UnityEngine;

[CreateAssetMenu(fileName = "InputHandler", menuName = "Command/InputHandler")]
public class InputHandler : ScriptableObject
{
    [SerializeField, Range(0, 10)] private int commandBufferSize = 3;
    private CommandQueue _commandQueue;

    public void Start()
    {
        _commandQueue = new CommandQueue(commandBufferSize);
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
