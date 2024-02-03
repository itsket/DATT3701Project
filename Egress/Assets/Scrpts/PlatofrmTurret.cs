using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatofrmTurret : MonoBehaviour
{
    public float range = 100f;
    public bool isFiring = true;
    public float fireRate = 5f;
    public GameObject projectile;
    private float nextFire = 0f;
    public float shootForce = 200f;
    public float upwardForce;
    public GameObject[] waypoints;
    public GameObject player;
    public TimeManager timeManager;
    public float speed;
    void Update()
    {
        if (isFiring && Time.time >= nextFire)
        {
            nextFire = Time.time + 10f / fireRate;
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
        currentProj.GetComponent<Walkable>().player = player;
        currentProj.GetComponent<Walkable>().waypoints = waypoints;
          currentProj.GetComponent<Walkable>().timeManager = timeManager;
        currentProj.GetComponent<Walkable>().speed = speed;

        // currentProj.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);

    }
}
