using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_toggler : MonoBehaviour
{
    int current_weapon = 0;

    void Start()
    {
        SetActiveWeapons();
    }

    private void Update()
    {
        int previousWeapon = current_weapon;
        GetInput();
        MouseScroll();
        if (previousWeapon != current_weapon)
        {
            SetActiveWeapons();
        }
    }

    void MouseScroll() {
        if (Input.GetAxis("Mouse ScrollWheel")>0) {
            if (current_weapon > transform.childCount - 2)
            {
                current_weapon = 0;
            }
            else
            {
                current_weapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (current_weapon <= 0)
            {
                current_weapon = transform.childCount-1;
            }
            else
            {
                current_weapon--;
            }
        }
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            current_weapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            current_weapon = 1;
        }
    }

    private void SetActiveWeapons()
    {
        int weapon_index = 0;
        foreach (Transform weapon in transform){

            if(weapon_index==current_weapon) {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weapon_index++;
        }
    }
}
