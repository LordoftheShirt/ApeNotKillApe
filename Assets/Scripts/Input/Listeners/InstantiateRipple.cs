using UnityEngine;

public class InstantiateRipple : MonoBehaviour
{
    [SerializeField] private GameObject ripplePrefab;

    private void OnEnable()
    {
        InputManager.Instance.onLeftClick += SpawnRipple;
    }

    void SpawnRipple(Vector3 position)
    {
        //ripplePrefab.transform.position = position;
        Instantiate(ripplePrefab, position, Quaternion.identity);
    }
}
