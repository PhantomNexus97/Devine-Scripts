using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Health system for the enemy
    public UnitHealthSystem _enemyHealth = new UnitHealthSystem(100, 100);

    // Called when a collision occurs
    void OnCollisionEnter(Collision other)
    {
        // Check if the collision is with a "Shell" gameObject
        if (other.gameObject.tag == "Shell")
        {
            // Inflict damage on the enemy
            EnemyTakeDmg(25);
        }
    }

    // Called when a trigger collider is entered
    private void OnTriggerEnter(Collider collision)
    {
        // Check if the collision is with a "MeleeWeapon" gameObject
        if (collision.gameObject.tag == "MeleeWeapon")
        {
            // Inflict damage on the enemy and log the hit
            EnemyTakeDmg(20);
            Debug.Log("Hit");
        }
    }

    // Function to handle enemy taking damage
    private void EnemyTakeDmg(int dmg)
    {
        // Inflict damage on the enemy using the UnitHealthSystem
        _enemyHealth.DmgUnit(dmg);
        
        // Log the enemy's updated health to the console
        Debug.Log("Damaged to " + _enemyHealth.Health);
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the enemy's health has reached or fallen below zero
        if (_enemyHealth.Health <= 0)
        {
            // Destroy the enemy gameObject
            Destroy(this.gameObject);
        }
    }
}
