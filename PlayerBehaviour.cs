using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    public Image healthBar;
    float lerpSpeed;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            GameManager.gameManager.PlayerTakeDmg(1);
            Debug.Log("You have been damaged to " + GameManager.gameManager._playerHealth.Health);

        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            GameManager.gameManager.PlayerHeal(10);
            Debug.Log("You have been healed to " + GameManager.gameManager._playerHealth.Health);
        }

        HealthBarFiller();
        lerpSpeed = 3f * Time.deltaTime;
    }
    void HealthBarFiller()
    {
        float currentHealth = GameManager.gameManager._playerHealth.Health;
        float maxHealth = GameManager.gameManager._playerHealth.MaxHealth;

        if (maxHealth > 0)
        {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (currentHealth / maxHealth), lerpSpeed);
        }
        else
        {
            healthBar.fillAmount = 0f;
        }

    }

    public void Damage(int damagePoints)
    {
        if (GameManager.gameManager._playerHealth.Health > 0)
            GameManager.gameManager._playerHealth.Health -= damagePoints;
    }

    public void Heal(int healingPoints)
    {
        if (GameManager.gameManager._playerHealth.Health < GameManager.gameManager._playerHealth.MaxHealth)
            GameManager.gameManager._playerHealth.Health += healingPoints;
    }


}
