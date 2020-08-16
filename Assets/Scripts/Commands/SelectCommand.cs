using DefaultNamespace;
using UnityEngine;

namespace Commands
{
    [CreateAssetMenu(fileName = "SelectCommand", menuName = "Command/Commands/SelectCommand")]
    public class SelectCommand  : InputCommand
    {
        [SerializeField] private SelectContextGetter _selectContextGetter;
    
        public static ISelectable Selected;
        private ISelectable _previousSelected;
        private ISelectable _toSelect;

        public override InputCommand Init()
        {
            _toSelect = _selectContextGetter.GetContext();
            
            if (_toSelect == null || _toSelect == Selected)
            {
                return null;
            }

            return this;
        }

        public override void Execute()
        {
            Selected?.OnDeselect();

            _previousSelected = Selected;
            Selected = _toSelect;
            Selected?.OnSelect();
        }

        public override void Undo()
        {
            Selected = null;
            _toSelect?.OnDeselect();
            if (_previousSelected != null)
            {
                Selected = _previousSelected;
                Selected.OnSelect();
            }
        }
    }
}