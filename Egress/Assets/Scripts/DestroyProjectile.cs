
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public float projectileLifeSpan = 2f;
    private void Start()
    {
        Destroy(gameObject, projectileLifeSpan);
    }

  
   
}
