using ContextGetters;
using UnityEngine;

namespace Commands
{
    [CreateAssetMenu(fileName = "UndoCommand", menuName = "Command/Commands/UndoCommand")]
    public class UndoCommand : InputCommand
    {
        [SerializeField] private InputHandlerGetter _inputHandlerGetter;
        private InputHandler _inputHandler;
        public override InputCommand Init()
        {
            _inputHandler = _inputHandlerGetter.GetContext();
            return this;
        }

        public override void Undo()
        {
            
        }

        public override void Execute()
        {
            _inputHandler.Undo();
        }
    }
}