using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    

    [Header ("Player Stats")]
    public bool _skillPointLock = false;
    public int _playerLevel = 1;
    public int _experincePoints = 0;
    public int _skillPoints = 2;
    public UnitHealthSystem _playerHealth = new UnitHealthSystem(100, 100);

    [Header ("Player Skills")]
    public int _ssSkillPoints = 0;
    public int _ffSkillPoints = 0;
    public int _gdSkillPoints = 0;
    public int _cpSkillPoints = 0;

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
        Application.targetFrameRate = 60;
    }

    public void PlayerTakeDmg(int dmg)
    {
        _playerHealth.DmgUnit(dmg);
    }
    public void PlayerHeal(int healing)
    {
        _playerHealth.HealUnit(healing);
    }
}
