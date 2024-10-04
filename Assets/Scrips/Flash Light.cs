using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light My_light;
    [SerializeField] float flash_decay = 0.1f;
    [SerializeField] float angle_decay = 0.1f;
    [SerializeField] float minimum_angle = 40f;

    void Start()
    {
        My_light = GetComponent<Light>();
    }

    void Update()
    {
        My_light.intensity -= flash_decay * Time.deltaTime;
        if (My_light.spotAngle >= minimum_angle)
        {
            My_light.spotAngle -= angle_decay;
        } 
    }


    public void AddIntensity(float IntensityAmmount)
    {
        My_light.intensity += IntensityAmmount;
    }

    public void ExpandAngle(float MaxAngle)
    {
        My_light.spotAngle = MaxAngle;
    }
}
