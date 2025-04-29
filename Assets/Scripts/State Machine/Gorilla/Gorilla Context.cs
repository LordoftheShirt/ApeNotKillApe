using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GorillaContext
{
    public GameObject MyObject;
    public Material MyMaterial;
    public GorillaScriptableObject MyGorillaScriptableObject;
    public GorillaStateMachine MyStateMachine;

    // constructor
    public GorillaContext(GameObject me, GorillaStateMachine stateMachine, GorillaScriptableObject scriptableObject)
    {
        MyObject = me;
        MyMaterial = MyObject.GetComponent<SpriteRenderer>().material;
        MyStateMachine = stateMachine;
        MyGorillaScriptableObject = scriptableObject;

        Debug.Log(MyMaterial);
    }

    // Read-Only properties. " => " means they only can only be get, cannot be set?
    //public GameObject MyObject => myObject;
}
