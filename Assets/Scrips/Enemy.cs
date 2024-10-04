using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] float Enemy_spawn_distance = 2f;
    [SerializeField] Transform player;
    [SerializeField] float rotation_speed = 5f;
    NavMeshAgent navmeshagent;
    EnemyHealth enemyHealth;
    bool is_provoked = true;

    //Code Written For Debuging Purpose

    //public bool Is_provoked { get { return is_provoked; } set { is_provoked = value; } }

    //public void set_value(bool value)
    //{
    //    is_provoked = value;
    //}

    public float distance = Mathf.Infinity;

    private void Start()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        is_provoked = false;
    }

    void Update()
    {
        if (enemyHealth.Dead())
        {
            this.enabled = false;
            navmeshagent.enabled = false;
            var colliders = GetComponentsInChildren<Collider>();
            foreach (var collider in colliders)
            {
                collider.enabled = false;
            }
            return;
        }
        //if (enemyHealth.Dead())
        //{
        //    enabled = false;
        //    //navmeshagent.enabled = false;
        //}

        distance = Vector3.Distance(transform.position, player.position);
        

        if (distance > Enemy_spawn_distance)
        {
            is_provoked = false;  
        }
        else
        {
            is_provoked = true;
            Engage_target();
        }
    }

    private void Engage_target()
    {
        if (distance <= navmeshagent.stoppingDistance) {
            AttackPlayer();
            Facetarget();
        }

        else {
            ChaseTarget();
        }
    }

    private void ChaseTarget()
    {
        navmeshagent.SetDestination(player.position);
        GetComponent<Animator>().SetTrigger("Walk");
        GetComponent<Animator>().SetBool("Attack", false);   
    }

    private void AttackPlayer()
    {
        GetComponent<Animator>().SetBool("Attack",true);
        //Debug.Log("Attack"); 
    }

    void Facetarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x,0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * rotation_speed);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Enemy_spawn_distance);
    }

    public void OnDamageTaken()
    {
        is_provoked = true;
        Engage_target();
    }
}
