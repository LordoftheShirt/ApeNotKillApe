using UnityEngine;

public class GorillaContext
{
    private GameObject myObject;

    // constructor
    public GorillaContext(GameObject me)
    {
        myObject = me;
    }

    // Read-Only properties. " => " means they only can only be get, cannot be set?

    public GameObject MyObject => myObject;
}
