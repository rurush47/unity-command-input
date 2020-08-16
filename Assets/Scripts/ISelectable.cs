using UnityEngine;

namespace DefaultNamespace
{
    public interface ISelectable
    {
        void OnSelect();
        void OnDeselect();

        Transform GetTransform();
    }
}