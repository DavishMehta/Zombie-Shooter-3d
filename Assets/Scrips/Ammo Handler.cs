using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHandler : MonoBehaviour
{
    [SerializeField] AmmoSlots[] ammoslots;
    [System.Serializable]
    private class AmmoSlots {
        public Ammotype Ammos;
        public float AmmoAmount;
    }
    //[SerializeField] float ammoAmount = 5f;

    public float GetAmmo(Ammotype ammotype) {
        return GetAmmoSlot(ammotype).AmmoAmount;
    }

    AmmoSlots GetAmmoSlot(Ammotype ammotype)
    {
        foreach(AmmoSlots temp in ammoslots)
        {
            if(temp.Ammos == ammotype)
            {
                return temp;
            }
        }
        return null;
       
    }

    public void UseAmmo(int damage, Ammotype ammotype)
    {
        GetAmmoSlot(ammotype).AmmoAmount -= damage;
    }

    public void Increase_ammo(float ammo, Ammotype ammotype) {
        GetAmmoSlot(ammotype).AmmoAmount += ammo;
    }

}
