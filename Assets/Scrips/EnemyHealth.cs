using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health_value = 5f;
    bool is_dead = false;
    public bool Dead()
    {
        return is_dead;
    }
    public float GetHealth() {
        return health_value;
    }

    public void Decrease_health(float damage) {
        health_value-=damage;
        BroadcastMessage("OnDamageTaken");
        if (health_value <= 0)
        {
            if (is_dead) return;
            GetComponent<Animator>().SetTrigger("is_dead");
            is_dead = true;
        }
    }   
}
