using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NahIdWin : MonoBehaviour
{

    public GameObject player;
    public bool active = true;
    public float distanceBetween;
    public float a;
    // Update is called once per frame
    private void Start()
    {
        a = 20f;

    }
    void Update()
    {
       
            
            Infinity();
    }

    void Infinity()
    {
        distanceBetween = Vector3.Distance(transform.position, player.transform.position);
      
            if (distanceBetween <= a)
            {

                player.GetComponent<PlayerMotor>().playerSpeedSetter = player.GetComponent<PlayerMotor>().playerSpeedSetter / 1.2f;
                a -= 1f;
            Debug.Log("AAAAAAAAAA");
            }


            else if (distanceBetween >= a + 1f)
            {
                if (a >= 20f) { 
            
                } else
                {

                    player.GetComponent<PlayerMotor>().playerSpeedSetter = player.GetComponent<PlayerMotor>().playerSpeedSetter * 1.2f;
                    a += 1f;
                }
              
            }
        
        }

    
    
}
