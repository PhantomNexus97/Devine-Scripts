using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public UnitHealthSystem _enemyHealth = new UnitHealthSystem(100, 100);

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Shell")
        {
            EnemyTakeDmg(25);
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "MeleeWeapon")
        {
            EnemyTakeDmg(20);
            Debug.Log("Hit");
        }
    }
    private void EnemyTakeDmg(int dmg)
    {
        _enemyHealth.DmgUnit(dmg);
        Debug.Log("Damaged to " + _enemyHealth.Health);
    }

    private void Update()
    {
        if (_enemyHealth.Health <= 0)
        {
            Destroy(this.gameObject);

        }
    }
}
