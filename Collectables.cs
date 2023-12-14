using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public VeilArea _area;
    public GameObject _endZone;
    void OnTriggerEnter(Collider Col)
    {

        if (gameObject.tag == "HealthPotion")
        {
            GameManager.gameManager.PlayerHeal(10);
            Debug.Log("You have been healed to " + GameManager.gameManager._playerHealth.Health);
            Destroy(gameObject);
        }

        if (gameObject.tag == "Relic")
        {
            _area._relicCollected = true;
            Debug.Log("You have picked up the reclic");
            Destroy(gameObject);
            _endZone.SetActive(true);
        }

    }
}
