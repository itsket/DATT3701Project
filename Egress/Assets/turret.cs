
using System;
using UnityEngine;

public class turret : MonoBehaviour
{
  public float range = 100f;
    public bool isFiring = true;
    public float fireRate = 5f;
    public GameObject projectile;
    private float nextFire = 0f;
    public float shootForce = 200f;
         public float upwardForce;
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
        currentProj.GetComponent<Rigidbody>().AddForce(direction.normalized*shootForce, ForceMode.Impulse);
     }

    }
