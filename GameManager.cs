using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance of the GameManager
    public static GameManager gameManager { get; private set; }
    
    [Header("Player Stats")]
    public bool _skillPointLock = false;   // Flag indicating whether skill points are locked
    public int _playerLevel = 1;           // Current level of the player
    public int _experiencePoints = 0;      // Accumulated experience points
    public int _skillPoints = 2;           // Available skill points for the player
    public UnitHealthSystem _playerHealth = new UnitHealthSystem(100, 100);  // Player health system

    [Header("Player Skills")]
    public int _ssSkillPoints = 0;  // Skill points for a specific skill
    public int _ffSkillPoints = 0;  // Skill points for another specific skill
    public int _gdSkillPoints = 0;  // Skill points for yet another specific skill
    public int _cpSkillPoints = 0;  // Skill points for one more specific skill

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Singleton pattern implementation to ensure there is only one instance of GameManager
        if (gameManager != null && gameManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gameManager = this;
        }

        // Set the target frame rate to 60 frames per second
        Application.targetFrameRate = 60;
    }

    // Method to apply damage to the player
    public void PlayerTakeDmg(int dmg)
    {
        _playerHealth.DmgUnit(dmg);
    }

    // Method to heal the player
    public void PlayerHeal(int healing)
    {
        _playerHealth.HealUnit(healing);
    }
}
