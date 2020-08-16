using UnityEngine;

namespace Commands
{
    public abstract class InputCommand : ScriptableObject
    {
        public bool HistoryTrackable;
        public abstract InputCommand Init();

        public abstract void Undo();

        public abstract void Execute();
    }
}