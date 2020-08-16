using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HighlightSelection : MonoBehaviour, ISelectable
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnSelect()
    {
        _spriteRenderer.color = Color.red;
    }

    public void OnDeselect()
    {
        _spriteRenderer.color = Color.white;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
