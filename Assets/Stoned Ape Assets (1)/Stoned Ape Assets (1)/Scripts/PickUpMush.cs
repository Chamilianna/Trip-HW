using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PickUpMush : MonoBehaviour
{
    public int healthIncrease;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerManager.health += healthIncrease;
            Destroy(this.gameObject);
        }
    }
}
