using UnityEngine;

namespace ContextGetters
{
    [CreateAssetMenu(fileName = "InputHandlerGetter", menuName = "Command/ContextGetters/InputHandlerGetter")]
    public class InputHandlerGetter : ScriptableObject
    {
        [SerializeField] private InputHandler _inputHandler;
        
        public InputHandler GetContext()
        {
            return _inputHandler;
        }
    }
}