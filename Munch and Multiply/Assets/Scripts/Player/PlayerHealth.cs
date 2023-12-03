using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public ParticleSystem blood;
    public HealthBar healthBar;

    public int sceneID;

    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        else if(currentHealth < 0)
            currentHealth = 0;

        if (currentHealth <= 0)
            SceneManager.LoadScene(sceneID);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            CreateBlood();
            FindObjectOfType<AudioManager>().Play("ZombieHurt");
        }
        else if(collision.gameObject.CompareTag("Knife"))
        {
            TakeDamage(30);
            CreateBlood();
            FindObjectOfType<AudioManager>().Play("ZombieHurt");
        }
        else if (collision.gameObject.CompareTag("Meds"))
        {
            ScoreManager.Instance.AddScore();
            Heal(20);
            FindObjectOfType<AudioManager>().Play("Pickup");
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(float value)
    {
        currentHealth -= value;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(float value)
    {
        currentHealth += value;
        healthBar.SetHealth(currentHealth);
    }

    void CreateBlood()
    {
        blood.Play();
    }
}
