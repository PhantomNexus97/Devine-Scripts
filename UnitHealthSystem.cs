using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealthSystem 
{
    // Fields for current health and maximum health
    int _currentHealth;
    int _currentMaxHealth;

    // Properties to access current health and maximum health
    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }
    public int MaxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }

    // Constructor to initialize the health system with specified initial health and maximum health
    public UnitHealthSystem(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    // Method to apply damage to the unit
    public void DmgUnit(int dmgAmount)
    {
        // Ensure health doesn't go below zero
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }
    }

    // Method to heal the unit
    public void HealUnit(int healAmount)
    {
        // Ensure health doesn't exceed the maximum
        if (_currentHealth > 0)
        {
            _currentHealth += healAmount;
        }
        
        // Cap the health to the maximum
        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
}
