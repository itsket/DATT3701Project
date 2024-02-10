
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Turret : MonoBehaviour
{
  public float lifeSpan = 2f;
    public bool isFiring = true;
    public float fireRate = 5f;
    public GameObject projectile;
    private float nextFire = 0f;
    public float shootForce = 200f;
         public float upwardForce;
    public bool noWaypoint = true;
    public float nozzleLength = 10f;
    public GameObject respawnPoint;
    public bool randomiseSpeed = false;
    public bool randomiseStart = false;
    void Update()
    {
        if (randomiseStart && !isFiring)
        {
            int rando = Random.Range(-1000,1000);
            if (rando > 980 ) {
                isFiring = true;
            }
        }
        if (isFiring && Time.time >= nextFire) {
            nextFire = Time.time + 10f/fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Vector3 targetPoint;
        Vector3 origin = transform.position + transform.forward;
      
       

      
            targetPoint = transform.position + transform.forward * 10f;
    

     Vector3 direction = targetPoint - origin;
        GameObject currentProj = Instantiate(projectile, origin, Quaternion.identity);

        if (noWaypoint)
        {
            if (randomiseSpeed)
            {
                
                currentProj.GetComponent<Rigidbody>().AddForce(direction.normalized * Random.Range(shootForce, shootForce*1.5f) , ForceMode.Impulse);
            }
            else
            {
                currentProj.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
            }
        }
        if (currentProj.GetComponent<DestroyProjectile>() != null)
            currentProj.GetComponent<DestroyProjectile>().projectileLifeSpan = lifeSpan;

        if (respawnPoint != null)
        currentProj.GetComponent<slowLevel_1>().respawnPoint = respawnPoint;
     }

    }
