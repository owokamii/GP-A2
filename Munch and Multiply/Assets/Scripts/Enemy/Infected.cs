using UnityEngine;

public class Infected : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform spawnPoint;

    private bool isTriggered;

    public void Infection()
    {
        if (!isTriggered)
        {
            ScoreManager.Instance.AddScore();
            InfectedCountManager.Instance.AddInfected();

            GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
            zombie.GetComponent<Rigidbody2D>();
            Destroy(gameObject);
        }
    }
}