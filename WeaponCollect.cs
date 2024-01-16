using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollect : MonoBehaviour
{
    //Weapon Bools
    public bool hasCollectedShotgun = false;
    public bool hasCollectedPistol = false;

    public static object weaponCollect { get; internal set; }

    public bool CanActivateWeapon(int weaponIndex)
    {
        // Check if any weapon has been collected
        if (hasCollectedShotgun || hasCollectedPistol)
        {
            // Add our conditions here based on the weapon index
            switch (weaponIndex)
            {
                case 0:
                    return hasCollectedShotgun;
                case 1:
                    return hasCollectedPistol;
                default:
                    return false;
            }
        }
        else
        {
            // No weapon has been collected, so none can be activated
            return false;
        }
    }
}
