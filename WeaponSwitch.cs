using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public WeaponCollect weaponCollect; // Reference to the Weaponcollect script

    private int currentWeapon = -1; // Start with no weapon selected

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        // ... (unchanged my code)

        // Switch weapons using the mouse scroll wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            SwitchWeapon(1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            SwitchWeapon(-1);
        }

        // Switch weapons using number keys (1, 2, 3, ...)
        for (int i = 0; i < transform.childCount; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SwitchToWeapon(i);
            }
        }
    }

    void SwitchWeapon(int direction)
    {
        int newWeapon = currentWeapon + direction;

        // Ensure the new weapon is within valid bounds
        if (newWeapon < 0)
            newWeapon = transform.childCount - 1;
        else if (newWeapon >= transform.childCount)
            newWeapon = 0;

        // Check the collect script's boolean condition before switching
        if (weaponCollect.CanActivateWeapon(newWeapon))
        {
            currentWeapon = newWeapon;
            SelectWeapon();
        }
    }

    void SwitchToWeapon(int weaponIndex)
    {
        // Check the collect script's boolean condition before switching
        if (weaponCollect.CanActivateWeapon(weaponIndex))
        {
            currentWeapon = weaponIndex;
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        // Deactivate all weapons
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // Activate the current weapon if it's valid
        if (currentWeapon >= 0 && currentWeapon < transform.childCount)
        {
            transform.GetChild(currentWeapon).gameObject.SetActive(true);
        }
    }
}
