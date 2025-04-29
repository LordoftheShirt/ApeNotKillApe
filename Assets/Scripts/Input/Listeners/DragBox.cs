using System.Collections;
using UnityEngine;

public class DragBox : MonoBehaviour
{
    [SerializeField, Range(0, 1f)] private float colliderSizeDownScale = 1f;
    [SerializeField] private GameObject dashedBox;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private Coroutine coroutine;

    private bool selectActionPerformed = false;
    void Start()
    {
        spriteRenderer = dashedBox.GetComponent<SpriteRenderer>();
        boxCollider = dashedBox.GetComponent<BoxCollider2D>();

        InputManager.Instance.onLeftClick += DashedBoxToLeftClick;
        InputManager.Instance.onLeftClickRelease += SelectCompleted;
    }

    
    void Update()
    {
        
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

        while (!selectActionPerformed)
        {
            followPointer = InputManager.Instance.PointerWorldPosition();
            spriteRenderer.size = (followPointer - dashedBox.transform.position) / 2;

            // THEORY: the difference between bounds.size and .size is that bounds.size is the absolute value.
            boxCollider.size = (spriteRenderer.bounds.size / 2) * colliderSizeDownScale; 
            boxCollider.offset = new Vector2(spriteRenderer.size.x / 2, spriteRenderer.size.y / 2);
            


            yield return null;
        }
        
        // reset
        selectActionPerformed = false;
        dashedBox.SetActive(false);
    }

    private void SelectCompleted()
    {
        print("mouse release!");
        selectActionPerformed = true;
    }
}
