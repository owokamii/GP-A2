using TMPro;
using UnityEngine;

public class HealthBarText : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TMP_Text healthBarText;
    
    void Update()
    {
        healthBarText.text = playerHealth.currentHealth + " / " + playerHealth.maxHealth;
    }
}
