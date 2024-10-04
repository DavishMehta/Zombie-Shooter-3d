using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float Max_angle = 70f;
    [SerializeField] float IntensityAmmount = 5f;
    [SerializeField] FlashLight Mylight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Mylight.AddIntensity(IntensityAmmount);
            //Mylight.ExpandAngle(Max_angle);
            Destroy(gameObject);
        }
    }
}
