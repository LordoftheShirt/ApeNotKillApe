using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
//using Unity.Collections;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

// there was an attempt.
struct Entity
{
    public GameObject myObject;
    public ISelectable selectable;
}

public class Select : MonoBehaviour
{
    List<Entity> currentCollisions = new List<Entity>();

    List<Entity> thingsSelectedList = new List<Entity>();
    private float leftClickTracker;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        leftClickTracker = InputManager.Instance.DetectLeftClickChange();


        if (collision.gameObject.TryGetComponent<ISelectable>(out ISelectable selectable) == true)
        {
            var findPriorlySelected = thingsSelectedList.FirstOrDefault(x => x.selectable == selectable);

            if (findPriorlySelected.selectable == null)
            {
                Entity entity = new Entity();
                entity.selectable = selectable;
                entity.myObject = collision.gameObject;
                currentCollisions.Add(entity);
            }
            else 
            {
                currentCollisions.Add(findPriorlySelected);
            }

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

            // a left mouse release has occured, I.E a new selection.
            if (leftClickTracker != InputManager.Instance.DetectLeftClickChange())
            {
                // assume from the beginning that bro is being deleted:
                selectable.OnSelect(false);

                var keepers = thingsSelectedList.RemoveAll(x => !currentCollisions.Contains(x));
                
                //Debug.Log("kept? : " +  keepers);

                var filterOutDuplicates = currentCollisions.RemoveAll(x => thingsSelectedList.Contains(x));
                //Debug.Log("Filtered out ?: " + filterOutDuplicates);

                thingsSelectedList.AddRange(currentCollisions);

                foreach (Entity entity in thingsSelectedList) 
                {
                    entity.selectable.OnSelect(true);
                }

                Debug.Log(thingsSelectedList.Count);
            }
            else 
            {
                //currentCollisions.RemoveAll(x => x.selectable == selectable);
            }

        }
    }

    // apparently this is a trigger once kind of thing?
    [ContextMenu("PrintList")]
    public void CheckList()
    {

        Debug.Log("------------------");
        Debug.Log("CurrentCollisions: " + currentCollisions.Count);
        Debug.Log("Things selected: " + thingsSelectedList.Count);
    }
}
