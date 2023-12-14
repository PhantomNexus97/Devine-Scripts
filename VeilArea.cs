using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeilArea : MonoBehaviour
{
    public float _speed = 5f; // Speed of the cube along the Y-axis

    public bool _playerInVeil = false;
    public bool _relicCollected = false;

    private void Update()
    {


       if(_playerInVeil == true)
       {
            GameManager.gameManager.PlayerTakeDmg(100);
       }

        if(_relicCollected == true)
        {
            MoveCube();
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (gameObject.tag == "Veil")
        {
            Debug.Log("player in veil");
            _playerInVeil = true;
        }
    }

    private void MoveCube()
    {
        // Move the cube along the Y-axis
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}

