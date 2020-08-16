using ContextGetters;
using UnityEngine;

namespace Commands
{
    [CreateAssetMenu(fileName = "MoveCommand", menuName = "Command/Commands/MoveCommand")]
    public class MoveCommand : InputCommand
    {
        [SerializeField] private MoveContextGetter _moveContextGetter;
        
        private Transform _transform;
        private Vector2 _newPos;
        private Vector2 _oldPos;

        public override InputCommand Init()
        {
            var context = _moveContextGetter.GetContext();

            if (context.Item1 == null || context.Item2 == Vector2.negativeInfinity)
            {
                return null;
            }
            
            _transform = context.Item1;
            _newPos = context.Item2;
            
            return this;
        }
        
        public override void Execute()
        {
            _oldPos = _transform.position;
            _transform.position = _newPos;
        }

        public override void Undo()
        {
            _transform.position = _oldPos;
        }
    }
}