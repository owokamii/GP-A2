using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bullet : MonoBehaviour
{
    public ParticleSystem blood;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D capsuleCollider;
    public TrailRenderer trailRenderer;
    public new Light2D light;

    void Awake()
    {
        Destroy(gameObject, 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Zombie"))
        {
            CreateBlood();
            FindObjectOfType<AudioManager>().Play("ZombieHurt");
            spriteRenderer.enabled = false;
            capsuleCollider.enabled = false;
            trailRenderer.enabled = false;
            light.enabled = false;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void CreateBlood()
    {
        blood.Play();
    }
}
