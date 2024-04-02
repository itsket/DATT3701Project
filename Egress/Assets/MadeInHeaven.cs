using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MadeInHeaven : MonoBehaviour
{
    public SceneLoader sceneLoader;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            sceneLoader.Sceneloader(1);
        }
      
    }
}
