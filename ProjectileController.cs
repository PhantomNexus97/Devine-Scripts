using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Initiate the self-destruct coroutine when the projectile is spawned
        StartCoroutine(SelfDestruct());
    }

    // Coroutine for self-destruction after a certain duration
    IEnumerator SelfDestruct()
    {
        // Wait for 1.5 seconds before destroying the projectile
        yield return new WaitForSeconds(1.5f);

        // Destroy the projectile game object
        Destroy(gameObject);
    }

    // Called when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Shell" tag
        if (collision.gameObject.tag == "Shell")
        {
            // Do nothing if the collision is with a "Shell"
            return;
        }
        else
        {
            // Destroy the projectile for all other collisions
            Destroy(gameObject);
        }
    }
}

