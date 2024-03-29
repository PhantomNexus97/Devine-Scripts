using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Reference to the VeilArea
    public VeilArea _area;

    // Reference to the end zone GameObject
    public GameObject _endZone;

    public WeaponCollect weaponCollect;

    // Called when another collider enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the collected object is a HealthPotion
        if (gameObject.tag == "HealthPotion" && other.CompareTag("Player"))
        {
            // Heal the player using the GameManager
            GameManager.gameManager.PlayerHeal(10);

            // Log the player's updated health to the console
            Debug.Log("You have been healed to " + GameManager.gameManager._playerHealth.Health);

            // Destroy the HealthPotion object
            Destroy(gameObject);
        }

        // Check if the collected object is a Relic
        if (gameObject.tag == "Relic" && other.CompareTag("Player"))
        {
            // Set the relicCollected flag in the VeilArea to true
            _area._relicCollected = true;

            // Log a message indicating the relic has been picked up
            Debug.Log("You have picked up the relic");

            // Destroy the Relic object
            Destroy(gameObject);

            // Activate the end zone GameObject
            _endZone.SetActive(true);
        }

        // Weapon pickups

        if (gameObject.tag == "shotgun" && other.CompareTag("Player"))
        {
            // Activate the shotgun GameObject
            weaponCollect.hasCollectedShotgun = true;

            // Destroy the shotgun pickup object
            Destroy(gameObject);
        }

        if (gameObject.tag == "pistol" && other.CompareTag("Player"))
        {
            // Activate the pistol GameObject
            weaponCollect.hasCollectedPistol = true;

            // Destroy the pistol pickup object
            Destroy(gameObject);
        }
    }

}
