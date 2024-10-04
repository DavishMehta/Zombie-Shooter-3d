using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float players_health = 5f;

    public void DecreaseHealth(float damage)
    {
        this.players_health -= damage;
    }

    public float GetHealth()
    {
        return players_health;
    }
}
