using System.Collections.Generic;
using Commands;

public class CommandQueue
{
    public CommandQueue(int maxCapacity)
    {
        _maxCapacity = maxCapacity;
    }
        
    private readonly List<InputCommand> _commandsList = new List<InputCommand>();
    private int _currentIndex = -1;
    private readonly int _maxCapacity;

    public void Add(InputCommand command)
    {
        //Null check for empty commands (example - blank selection)
        if (command is null)
        {
            return;
        }
        
        //Add new command on the top of current one
        _currentIndex++;
        _commandsList.Insert(_currentIndex, command);

        //remove all redo commands after newly added one
        if (_currentIndex + 1 < _commandsList.Count)
        {
            _commandsList.RemoveRange(_currentIndex + 1, _commandsList.Count - (_currentIndex + 1));
        }
        
        //Check for buffer extension
        if (_commandsList.Count > _maxCapacity)
        {
            _commandsList.RemoveAt(0);
            _currentIndex--;
        }
    }
        
    public void Undo()
    {
        //Failure
        if (_commandsList.Count < 1 || _currentIndex < 0)
        {
            return;
        }
        //Success
        _commandsList[_currentIndex].Undo();
        _currentIndex--;
    }

    public void Redo()
    {
        //Failure
        int workingIndex = _currentIndex + 1;
        if (_currentIndex >= _commandsList.Count - 1)
        {
            return;
        }
        //Success
        _commandsList[workingIndex].Execute();
        _currentIndex++;
    }
}