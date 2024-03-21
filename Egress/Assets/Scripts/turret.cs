
using System;
using System.Collections;
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
    public float nozzleLength = 1.3f;
   
    public bool randomiseSpeed = false;
    public bool randomiseStart = false;
    public bool delayed = false;
    public int delayInSeconds;
    private float timer;
    private bool canShoot;
    private float currentDelay;

    private void Start()
    {
      
    }
    void Update()
    {
        if (delayed) {
            if (canShoot)
            {
                Shoot(); // Call your shoot function here
                canShoot = false;
                currentDelay = Random.Range(delayInSeconds-2, delayInSeconds+2);
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= currentDelay)
                {
                    canShoot = true;
                    timer = 0f;
                }
            }
        }
       
        else
        {
         
            if (isFiring && Time.time >= nextFire)
            {
                nextFire = Time.time + 10f / fireRate;
                Shoot();
            }
        }
    }


    void Shoot()
    {
        RaycastHit hit;
        Vector3 targetPoint;
        Vector3 origin = transform.position + (transform.forward* nozzleLength);
      
       

      
            targetPoint = transform.position + transform.forward * 10f;
    

     Vector3 direction = targetPoint - origin;
        GameObject currentProj = Instantiate(projectile, origin, Quaternion.identity);

        if (noWaypoint)
        {
           
            
                currentProj.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
            
        }
        if (currentProj.GetComponent<DestroyProjectile>() != null)
            currentProj.GetComponent<DestroyProjectile>().projectileLifeSpan = lifeSpan;

   
     }

    }
