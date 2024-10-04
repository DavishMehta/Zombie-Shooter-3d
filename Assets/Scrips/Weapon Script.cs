using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] ParticleSystem bullets_particle_flash;
    [SerializeField] GameObject Hiteffect;
    [SerializeField] int ammo_reduction_ammount = 1;
    [SerializeField] float range = 100f;
    [SerializeField] AmmoHandler ammohandler;
    [SerializeField] float timeBetweenShoots = 1f;
    [SerializeField] float damage = 1f;
    bool is_shooting = true;
    [SerializeField] Ammotype ammotype;

    public Ammotype ammogetter
    {
        get
        {
            return ammotype;
        }
    } 

    private void OnEnable()
    {
        is_shooting = true;
    }
 
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammohandler.GetAmmo(ammotype) > 0 && is_shooting == true)
            {
                bullets_particle_flash.Play();
                ammohandler.UseAmmo(ammo_reduction_ammount, ammotype);
                StartCoroutine(ShootEnemy());
            }
        } 
    }

    IEnumerator ShootEnemy()
    {
        is_shooting = false;
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            PlayHitEffect(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                target.Decrease_health(damage);
            }
        }
        yield return new WaitForSecondsRealtime(timeBetweenShoots);
        is_shooting = true;
    }

    private void PlayHitEffect(RaycastHit hit)
    {
        GameObject Impact = Instantiate(Hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(Impact, 1f);
    }
}
