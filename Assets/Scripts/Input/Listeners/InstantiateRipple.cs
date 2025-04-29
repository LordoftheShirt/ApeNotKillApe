using UnityEngine;

public class InstantiateRipple : MonoBehaviour
{
    [SerializeField] private GameObject ripplePrefab;
    void Start()
    {
        
    }


    private void OnEnable()
    {
        InputManager.Instance.onLeftClick += SpawnRipple;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRipple(Vector3 position)
    {
        //ripplePrefab.transform.position = position;
        Instantiate(ripplePrefab, position, Quaternion.identity);
    }
}
