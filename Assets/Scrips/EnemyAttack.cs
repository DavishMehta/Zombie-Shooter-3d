using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float Damage = 1f;
    PlayerHealth playerhealth;
    DeathHandler deathHandler;
    [SerializeField] AttackCanvas attackCanvas;

    void Start()
    {
        playerhealth = FindObjectOfType<PlayerHealth>();
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    public void Attack_player()
    {
        playerhealth.DecreaseHealth(Damage);
        attackCanvas.OnAttack();
        if (playerhealth.GetHealth() <= 0)
        {
            deathHandler.ShowGameoverCanvas();
        }
    }
}
