using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill_Tree : MonoBehaviour
{
    public TextMeshProUGUI _SkillPointDisplay;

    // Enum to represent the state of a skill point
    public enum SkillPoint
    {
        Empty,
        Spent
    }

    [Header("Sharpshooter")]
    public GameObject[] _ssEmptySkillPoints; // Array of empty skill point GameObjects
    public GameObject[] _ssSpentSkillPoints; // Array of spent skill point GameObjects

    [Header("Fleet Footed")]
    public GameObject[] _ffEmptySkillPoints;
    public GameObject[] _ffSpentSkillPoints;

    [Header("Gravity Defiance")]
    public GameObject[] _gdEmptySkillPoints;
    public GameObject[] _gdSpentSkillPoints;

    [Header("Combat Prowess")]
    public GameObject[] _cpEmptySkillPoints;
    public GameObject[] _cpSpentSkillPoints;
    // Start is called before the first frame update
    void Start()
    {
        // TODO: Initialize skill points / load from saved data
    }

    // Update is called once per frame
    void Update()
    {
        // Update the skill point display UI with the current skill points
        _SkillPointDisplay.text = GameManager.gameManager._skillPoints.ToString();
    }

    // Method to update the display when a skill point is spent
    private void SSUpdateSkillPointDisplay(int index, GameObject spentPoint, GameObject emptyPoint)
    {
        spentPoint.SetActive(true);    // Set the spent skill point GameObject to active
        emptyPoint.SetActive(false);   // Set the empty skill point GameObject to inactive
        GameManager.gameManager._ssSkillPoints += 1; // Increment the sharsphooter skill points
        GameManager.gameManager._skillPoints -= 1;   // Decrement the total skill points
    }

    private void FFUpdateSkillPointDisplay(int index, GameObject spentPoint, GameObject emptyPoint)
    {
        spentPoint.SetActive(true);    // Set the spent skill point GameObject to active
        emptyPoint.SetActive(false);   // Set the empty skill point GameObject to inactive
        GameManager.gameManager._ffSkillPoints += 1; // Increment the Fleet Foot skill points
        GameManager.gameManager._skillPoints -= 1;   // Decrement the total skill points
    }

    private void GDUpdateSkillPointDisplay(int index, GameObject spentPoint, GameObject emptyPoint)
    {
        spentPoint.SetActive(true);    // Set the spent skill point GameObject to active
        emptyPoint.SetActive(false);   // Set the empty skill point GameObject to inactive
        GameManager.gameManager._gdSkillPoints += 1; // Increment the Fleet Foot skill points
        GameManager.gameManager._skillPoints -= 1;   // Decrement the total skill points
    }

    private void CPUpdateSkillPointDisplay(int index, GameObject spentPoint, GameObject emptyPoint)
    {
        spentPoint.SetActive(true);    // Set the spent skill point GameObject to active
        emptyPoint.SetActive(false);   // Set the empty skill point GameObject to inactive
        GameManager.gameManager._cpSkillPoints += 1; // Increment the Fleet Foot skill points
        GameManager.gameManager._skillPoints -= 1;   // Decrement the total skill points
    }

    // Method to add a sharpshooter skill point
    public void AddSharpShooterSkillPoint()
    {
        // Check conditions before adding a skill point
        if (GameManager.gameManager._skillPointLock == false &&
            GameManager.gameManager._skillPoints > 0 &&
            GameManager.gameManager._ssSkillPoints < _ssEmptySkillPoints.Length)
        {
            // Update the display for the next available skill point
            SSUpdateSkillPointDisplay(GameManager.gameManager._ssSkillPoints,
                                    _ssSpentSkillPoints[GameManager.gameManager._ssSkillPoints],
                                    _ssEmptySkillPoints[GameManager.gameManager._ssSkillPoints]);
        }
    }

    // Method to subtract a sharpshooter skill point
    public void SubtractSharpShooterSkillPoint()
    {
        // Check conditions before subtracting a skill point
        if (GameManager.gameManager._skillPointLock == false &&
            GameManager.gameManager._ssSkillPoints > 0)
        {
            int index = GameManager.gameManager._ssSkillPoints - 1;

            // Set the spent skill point to inactive and the empty skill point to active
            _ssSpentSkillPoints[index].SetActive(false);
            _ssEmptySkillPoints[index].SetActive(true);

            // Decrement the sharpshooter skill points and increment the total skill points
            GameManager.gameManager._ssSkillPoints -= 1;
            GameManager.gameManager._skillPoints += 1;
        }
    }

    public void AddFleetFootSkillPoint()
    {
        // Check conditions before adding a skill point
        if (GameManager.gameManager._skillPointLock == false &&
            GameManager.gameManager._skillPoints > 0 &&
            GameManager.gameManager._ffSkillPoints < _ffEmptySkillPoints.Length)
        {
            // Update the display for the next available skill point
            FFUpdateSkillPointDisplay(GameManager.gameManager._ssSkillPoints,
                                    _ffSpentSkillPoints[GameManager.gameManager._ffSkillPoints],
                                    _ffEmptySkillPoints[GameManager.gameManager._ffSkillPoints]);
        }
    }

    // Method to subtract a sharpshooter skill point
    public void SubtractFleetFootSkillPoint()
    {
        // Check conditions before subtracting a skill point
        if (GameManager.gameManager._skillPointLock == false &&
            GameManager.gameManager._ffSkillPoints > 0)
        {
            int index = GameManager.gameManager._ffSkillPoints - 1;

            // Set the spent skill point to inactive and the empty skill point to active
            _ffSpentSkillPoints[index].SetActive(false);
            _ffEmptySkillPoints[index].SetActive(true);

            // Decrement the sharpshooter skill points and increment the total skill points
            GameManager.gameManager._ffSkillPoints -= 1;
            GameManager.gameManager._skillPoints += 1;
        }
    }

    public void AddGravityDefianceSkillPoint()
    {
        // Check conditions before adding a skill point
        if (GameManager.gameManager._skillPointLock == false &&
            GameManager.gameManager._skillPoints > 0 &&
            GameManager.gameManager._gdSkillPoints < _gdEmptySkillPoints.Length)
        {
            // Update the display for the next available skill point
            GDUpdateSkillPointDisplay(GameManager.gameManager._gdSkillPoints,
                                    _gdSpentSkillPoints[GameManager.gameManager._gdSkillPoints],
                                    _gdEmptySkillPoints[GameManager.gameManager._gdSkillPoints]);
        }
    }

    // Method to subtract a sharpshooter skill point
    public void SubtractGravityDefianceSkillPoint()
    {
        // Check conditions before subtracting a skill point
        if (GameManager.gameManager._skillPointLock == false &&
            GameManager.gameManager._gdSkillPoints > 0)
        {
            int index = GameManager.gameManager._gdSkillPoints - 1;

            // Set the spent skill point to inactive and the empty skill point to active
            _gdSpentSkillPoints[index].SetActive(false);
            _gdEmptySkillPoints[index].SetActive(true);

            // Decrement the sharpshooter skill points and increment the total skill points
            GameManager.gameManager._gdSkillPoints -= 1;
            GameManager.gameManager._skillPoints += 1;
        }
    }

    public void AddCombatProwessSkillPoint()
    {
        // Check conditions before adding a skill point
        if (GameManager.gameManager._skillPointLock == false &&
            GameManager.gameManager._skillPoints > 0 &&
            GameManager.gameManager._cpSkillPoints < _cpEmptySkillPoints.Length)
        {
            // Update the display for the next available skill point
            CPUpdateSkillPointDisplay(GameManager.gameManager._cpSkillPoints,
                                    _cpSpentSkillPoints[GameManager.gameManager._cpSkillPoints],
                                    _cpEmptySkillPoints[GameManager.gameManager._cpSkillPoints]);
        }
    }

    // Method to subtract a sharpshooter skill point
    public void SubtractCombatProwessSkillPoint()
    {
        // Check conditions before subtracting a skill point
        if (GameManager.gameManager._skillPointLock == false &&
            GameManager.gameManager._cpSkillPoints > 0)
        {
            int index = GameManager.gameManager._cpSkillPoints - 1;

            // Set the spent skill point to inactive and the empty skill point to active
            _cpSpentSkillPoints[index].SetActive(false);
            _cpEmptySkillPoints[index].SetActive(true);

            // Decrement the sharpshooter skill points and increment the total skill points
            GameManager.gameManager._cpSkillPoints -= 1;
            GameManager.gameManager._skillPoints += 1;
        }
    }

    // Save & Load Data
    // TODO: Add serialization/deserialization logic here
}
