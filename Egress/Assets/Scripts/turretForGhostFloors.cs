
using System;
using UnityEngine;

public class TurretForGhostFloors : MonoBehaviour
{
  public float range = 100f;
    public bool isFiring = true;
    public float fireRate = 5f;
    public GameObject projectile;
    private float nextFire = 0f;
    public GameObject[] waypoints;
    public float shootForce = 200f;
         public float upwardForce;
    public bool noWaypoint = true;
    void Update()
    {
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
        currentProj.GetComponent<Waypoints1>().enabled = true;

        if(noWaypoint)
        currentProj.GetComponent<Rigidbody>().AddForce(direction.normalized*shootForce, ForceMode.Impulse);
       
     }

    }
