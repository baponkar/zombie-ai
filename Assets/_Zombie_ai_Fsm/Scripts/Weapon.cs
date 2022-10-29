using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using baponkar.npc.zombie;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public float range = Mathf.Infinity;
    
    public ParticleSystem muzzleFlash;
    public ParticleSystem hitEffect;
    public Transform bulletSpawn;

    Ray ray;
    RaycastHit hit;
    Camera mainCamera;
    

    // Start is called before the first frame update
    void Start()
    {
       mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Emit(1);
        ray.origin = bulletSpawn.position;
        ray.direction = mainCamera.transform.forward;

        if(Physics.Raycast(ray, out hit, range))
        {
            hitEffect.transform.position = hit.point;
            hitEffect.Emit(1);
            

            Health health = hit.transform.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(damage, hit.point);
            }
        }
    }
}
