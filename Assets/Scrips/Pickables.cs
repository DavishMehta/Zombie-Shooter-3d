using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickables : MonoBehaviour
{
    [SerializeField] Ammotype ammotype;
    [SerializeField] AmmoHandler ammoHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ammoHandler.Increase_ammo(5, ammotype);
            Destroy(gameObject);
        }
    }
}