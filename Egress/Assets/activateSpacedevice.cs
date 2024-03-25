using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateSpacedevice : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spaceDevice;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        spaceDevice.SetActive(true);
        player.GetComponent<PlayerMotor>().canJump = false;
    }

    private void OnTriggerExit(Collider other)
    {
        spaceDevice.SetActive(false);
        player.GetComponent<PlayerMotor>().canJump = true;
    }
}
