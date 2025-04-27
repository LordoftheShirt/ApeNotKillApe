using UnityEngine;
using static GorillaStateMachine;


// Inherits StateManager who has Monobehaviour, and passes EGorillaState along as required generic parameter.

// It is GorillaStateMachine who keeps track of everything Gorilla.
// All the Serialized private variables get sent to "GorillaContext" within Awake, where they come to exist as public read-only variables. I don't why I do this. Why have separate class storing them?

//

public class GorillaStateMachine : StateManager<GorillaStateMachine.EGorillaState>
{
    public enum EGorillaState {
        NeutralGorilla,
        SereneGorilla,
        SadGorilla,

        MouthfulGorilla,
        DistressedGorilla,
        RagefulGorilla,

        RestingGorilla,
        DyingGorilla,
        DeadGorilla,
    }

    private GorillaContext gorillaContext;

    [SerializeField] private Sprite neutralSprite;
    [SerializeField] private Sprite sereneSprite;
    [SerializeField] private Sprite sadSprite;

    [SerializeField] private Sprite mouthfulSprite;
    [SerializeField] private Sprite distressedSprite;
    [SerializeField] private Sprite ragefulSprite;

    [SerializeField] private Sprite restingSprite;
    [SerializeField] private Sprite dyingSprite;
    [SerializeField] private Sprite deadSprite;

    private GameObject me;

    void Awake()
    {
        me = gameObject;
        gorillaContext = new GorillaContext(neutralSprite, sereneSprite, sadSprite, mouthfulSprite, distressedSprite, ragefulSprite, restingSprite, dyingSprite, deadSprite, me);
        InitializeState();
    }

    // Creates an instance of all the different states and adds them to the dictionary inherited by State Machine. Each Enum correlates to a *concrete* GorillaState script.
    private void InitializeState()
    {
        States.Add(EGorillaState.NeutralGorilla, new NeutralGorillaState(gorillaContext, EGorillaState.NeutralGorilla));

        CurrentState = States[EGorillaState.NeutralGorilla];
    }
}
