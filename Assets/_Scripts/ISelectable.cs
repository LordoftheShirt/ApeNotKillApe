using UnityEngine;

public interface ISelectable
{
    // apply white tint onto the object.
    public void OnHighlight(bool isOn);

    // pulsing outline.
    public void OnSelect(bool isOn);
}
