using System;
using Commands;
using UnityEngine;

namespace ContextGetters
{
    [CreateAssetMenu(fileName = "MoveContextGetter", menuName = "Command/ContextGetters/MoveContextGetter")]
    public class MoveContextGetter : ScriptableObject
    {
        public Tuple<Transform, Vector2> GetContext()
        {
            var context = new Tuple<Transform, Vector2>(null, Vector2.negativeInfinity);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            if (SelectCommand.Selected != null)
            {
                context = new Tuple<Transform, Vector2>(SelectCommand.Selected.GetTransform(), mousePos2D);
            }

            return context;
        }
    }
}