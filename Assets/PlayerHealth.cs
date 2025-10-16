using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    // A health bar that shows how much health the player has 
    public Image healthBarFill; // If using Image as a fillable health
    // public Slider healthSlider; // If using a slider as a health bar


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI(); // Initialize health bar
        
    }

    public void TakeDamage(float damageAmount )
    
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0 or above maxHealth
        UpdateHealthUI();

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
         if(healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
        //{   // else if (healthSlider != null)
        //{

        //      healthSlider.value = currentHealth / maxHealth;
        //}
    }
    

   


    void Die()
    {
        Debug.Log("You died!");
        // restart level
        Destroy(gameObject);
    }
}