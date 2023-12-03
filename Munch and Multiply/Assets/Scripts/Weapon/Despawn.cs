using UnityEngine;

public class Despawn : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 10);
    }
}
