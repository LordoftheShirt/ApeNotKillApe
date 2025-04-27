using UnityEngine;

public class GorillaContext
{
    // For an easier to read list, check the constructor.
    private Sprite neutralSprite, sereneSprite, sadSprite, mouthfulSprite, distressedSprite, ragefulSprite, restingSprite, dyingSprite, deadSprite;

    private GameObject myObject;

    // constructor
    public GorillaContext(Sprite neutral, Sprite serene, Sprite sad, Sprite mouthful, Sprite distressed, Sprite rageful, Sprite resting, Sprite dying, Sprite dead, GameObject me)
    {
        // Sprites.
        neutralSprite = neutral;
        sereneSprite = serene;
        sadSprite = sad;
        mouthfulSprite = mouthful;
        distressedSprite = distressed;
        ragefulSprite = rageful;
        restingSprite = resting;
        dyingSprite = dying;
        deadSprite = dead;

        myObject = me;
    }

    // Read-Only properties. " => " means they only can only be get, cannot be set?
    public Sprite NeutralSprite => neutralSprite;
    public Sprite SereneSprite => sereneSprite;
    public Sprite SadSprite => sadSprite;

    public Sprite MouthfulSprite => mouthfulSprite;
    public Sprite DistressedSprite => distressedSprite;
    public Sprite RagefulSprite => ragefulSprite;

    public Sprite RestingSprite => restingSprite;
    public Sprite DyingSprite => dyingSprite;
    public Sprite DeadSprite => deadSprite;

    public GameObject MyObject => myObject;
}
