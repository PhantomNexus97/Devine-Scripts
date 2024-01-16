using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeilArea : MonoBehaviour
{
    // Speed of the cube along the Y-axis
    public float _speed = 5f;

    // Flags indicating whether the player is in the veil area and if the relic is collected
    public bool _playerInVeil = false;
    public bool _relicCollected = false;

    // Update is called once per frame
    private void Update()
    {
        // Check if the player is in the veil area
        if (_playerInVeil == true)
        {
            // Inflict damage on the player using GameManager when in the veil
            GameManager.gameManager.PlayerTakeDmg(100);
        }

        // Check if the relic is collected
        if (_relicCollected == true)
        {
            // Move the cube along the Y-axis using the MoveCube method
            MoveCube();
        }
    }

    // Called when a collider enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the "Veil" tag
        if (other.CompareTag("Player"))
        {
            // Log a message indicating the player is in the veil
            Debug.Log("Player in veil");

            // Set the playerInVeil flag to true
            _playerInVeil = true;
        }
    }

    // Function to move the cube along the Y-axis
    private void MoveCube()
    {
        // Translate the cube along the right direction using the specified speed and frame time
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}

