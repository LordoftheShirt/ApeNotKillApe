using System.Collections;
using UnityEngine;
using static GorillaStateMachine;


// Inherits StateManager who has Monobehaviour, and passes EGorillaState along as required generic parameter.

// It is GorillaStateMachine who keeps track of everything Gorilla.
// All the Serialized private variables get sent to "GorillaContext" within Awake, where they come to exist as public read-only variables. I don't why I do this. Why have separate class storing them?

//

public class GorillaStateMachine : StateManager<GorillaStateMachine.EGorillaState>, ISelectable
{
    public enum EGorillaState {
        NeutralGorilla,
        DestinedGorilla
        /*SereneGorilla,
        SadGorilla,

        MouthfulGorilla,
        DistressedGorilla,
        RagefulGorilla,

        RestingGorilla,
        DyingGorilla,
        DeadGorilla,*/
    }

    // sends these to context.
    [SerializeField] private GorillaScriptableObject gorillaScriptableObject;
    private GorillaContext gorillaContext;
    private GameObject me;

    private bool outlinePulse;

    void Awake()
    {
        me = gameObject;
        gorillaContext = new GorillaContext(me, this, gorillaScriptableObject);
        InitializeState();
    }

    // Creates an instance of all the different states and adds them to the dictionary inherited by State Machine. Each Enum correlates to a *concrete* GorillaState script.
    private void InitializeState()
    {
        States.Add(EGorillaState.NeutralGorilla, new NeutralGorillaState(gorillaContext, EGorillaState.NeutralGorilla));

        CurrentState = States[EGorillaState.NeutralGorilla];
    }

    
    //------------------------------------------------
    // From the ISelectable interface:
    public void OnHighlight(bool isOn)
    {
        if (isOn)
        {
            gorillaContext.MyMaterial.SetFloat(gorillaContext.MyGorillaScriptableObject.ShaderHighlightWhitener, 0.1f);
        }
        else
        {
            gorillaContext.MyMaterial.SetFloat(gorillaContext.MyGorillaScriptableObject.ShaderHighlightWhitener, 0f);
        }
    }

    public void OnSelect(bool isOn)
    {
        if (isOn)
        {
            outlinePulse = true;
            StartCoroutine(OutlinePulse());
        }
        else
        {
            outlinePulse = false;
        }
    }
    //--------------------------------------------
    private IEnumerator OutlinePulse()
    {
        gorillaContext.MyMaterial.SetFloat(gorillaContext.MyGorillaScriptableObject.ShaderOutlinePulseThickness, -0.1f);
        while (outlinePulse)
        {
            gorillaContext.MyMaterial.SetFloat(gorillaContext.MyGorillaScriptableObject.ShaderPulseTime, Time.timeSinceLevelLoad);
            yield return null;
        }
        gorillaContext.MyMaterial.SetFloat(gorillaContext.MyGorillaScriptableObject.ShaderOutlinePulseThickness, 0);
    }
}
