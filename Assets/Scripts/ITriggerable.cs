using UnityEngine;

public interface ISelectable
{
    // apply white tint onto the object.
    public void OnHighlight();

    // pulsing outline.
    public void OnSelect();
}
