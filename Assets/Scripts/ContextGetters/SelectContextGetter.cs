using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "SelectContextGetter", menuName = "Command/ContextGetters/SelectContextGetter")]
    public class SelectContextGetter : ScriptableObject
    {
        public ISelectable GetContext()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            
            ISelectable selectable = null;
            Transform transform = hit.transform;
            
            if (transform != null)
            {
                selectable = transform.GetComponent<ISelectable>();
            }

            return selectable;
        }
    }
}