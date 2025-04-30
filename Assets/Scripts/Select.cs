using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    List<GameObject> list = new List<GameObject>();
    private float leftClickTracker;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision detected");
        leftClickTracker = InputManager.Instance.DetectLeftClickChange();
        if (collision.gameObject.TryGetComponent<ISelectable>(out ISelectable selectable) == true)
        {
            Debug.Log("component gotten!");
            selectable.OnHighlight(true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<ISelectable>(out ISelectable selectable))
        {
            selectable.OnHighlight(false);
            if (leftClickTracker != InputManager.Instance.DetectLeftClickChange())
            {
                selectable.OnSelect(true);
                list.Add(collision.gameObject);
            }
        }
    }
}
