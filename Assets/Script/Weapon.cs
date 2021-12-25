using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   [SerializeField] Camera FPCamera;
   [SerializeField] float range= 100f;
   [SerializeField] float damage=30f;
   [SerializeField] ParticleSystem muzzleflash ;
  
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {

            Shoot();
        }
    }

     void Shoot()
    {
        PlayMuzzleFlash();
        Processraycast();

    }

    private void PlayMuzzleFlash()
    {
        muzzleflash.Play();
    }

    private void Processraycast()
    {
        RaycastHit hit;


        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("ı hit this thing " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) return;
            target.TakeDamage(damage);


        }
        else
        {
            return;
        }
    }
}
