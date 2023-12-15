using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    // Reference to the health bar image
    public Image healthBar;

    // Speed for lerping the health bar fill amount
    float lerpSpeed;

    // Update is called once per frame
    void Update()
    {
        // Check for input to simulate damage and healing
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            // Inflict damage on the player through the GameManager
            GameManager.gameManager.PlayerTakeDmg(1);
            Debug.Log("You have been damaged to " + GameManager.gameManager._playerHealth.Health);
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            // Heal the player through the GameManager
            GameManager.gameManager.PlayerHeal(10);
            Debug.Log("You have been healed to " + GameManager.gameManager._playerHealth.Health);
        }

        // Update the health bar fill amount
        HealthBarFiller();

        // Set the lerping speed
        lerpSpeed = 3f * Time.deltaTime;
    }

    // Function to fill the health bar based on the player's health
    void HealthBarFiller()
    {
        float currentHealth = GameManager.gameManager._playerHealth.Health;
        float maxHealth = GameManager.gameManager._playerHealth.MaxHealth;

        // Ensure maxHealth is greater than zero to avoid division by zero
        if (maxHealth > 0)
        {
            // Lerp the health bar fill amount to the current health percentage
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (currentHealth / maxHealth), lerpSpeed);
        }
        else
        {
            // If maxHealth is zero, set the health bar fill amount to zero
            healthBar.fillAmount = 0f;
        }
    }

    // Function to simulate damage to the player
    public void Damage(int damagePoints)
    {
        // Inflict damage only if the player's health is above zero
        if (GameManager.gameManager._playerHealth.Health > 0)
            GameManager.gameManager._playerHealth.Health -= damagePoints;
    }

    // Function to simulate healing for the player
    public void Heal(int healingPoints)
    {
        // Heal the player only if their health is less than the maximum health
        if (GameManager.gameManager._playerHealth.Health < GameManager.gameManager._playerHealth.MaxHealth)
            GameManager.gameManager._playerHealth.Health += healingPoints;
    }
}

