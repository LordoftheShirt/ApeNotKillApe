using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBox : MonoBehaviour
{

    [SerializeField, Range(0, 1f)] private float colliderSizeDownScale = 1f;
    [SerializeField] private GameObject dashedBox;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private Coroutine coroutine;

    private bool EndSelect = false;
    void Awake()
    {
        List<GameObject> selectedObjects = new List<GameObject>();
        spriteRenderer = dashedBox.GetComponent<SpriteRenderer>();
        boxCollider = dashedBox.GetComponent<BoxCollider2D>();

        InputManager.Instance.OnRightClick += SelectActionCanceled;
        InputManager.Instance.OnLeftClick += DashedBoxToLeftClick;
        InputManager.Instance.OnLeftClickRelease += SelectCompleted;
        //InputManager.Instance.O
    }

    private void DashedBoxToLeftClick(Vector3 position)
    {
        dashedBox.transform.position = position;
        spriteRenderer.size = new Vector2(0f, 0f);
        dashedBox.SetActive(true);
        print("start coroutine!");
        coroutine = StartCoroutine(BoxStretchToPointer());
    }

    private IEnumerator BoxStretchToPointer()
    {
        Vector3 followPointer;

        while (!EndSelect)
        {
            followPointer = InputManager.Instance.PointerWorldPosition();
            spriteRenderer.size = (followPointer - dashedBox.transform.position) / 2;

            // THEORY: the difference between bounds.size and .size is that bounds.size is the absolute value.
            boxCollider.size = (spriteRenderer.bounds.size / 2) * colliderSizeDownScale; 
            boxCollider.offset = new Vector2(spriteRenderer.size.x / 2, spriteRenderer.size.y / 2);
            


            yield return null;
        }
        
        // reset.
        EndSelect = false;
        dashedBox.SetActive(false);
    }

    private void SelectCompleted()
    {
        // left click release
        EndSelect = true;
    }

    private void SelectActionCanceled(Vector3 position)
    {
        // right click. Doesn't actually use the vector at all lol.
        EndSelect = true;
    }
}
