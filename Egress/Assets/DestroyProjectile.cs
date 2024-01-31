
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);
    }
   
}
