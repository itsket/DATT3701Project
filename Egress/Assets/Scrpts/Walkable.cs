
using UnityEngine;

public class Walkable : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject player;
    int current = 0;
    public float speed;
    float WPradius = 1;
    public TimeManager timeManager;
    public bool onplat = false;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                if (onplat) {
                    player.transform.parent = null;
                    Destroy(gameObject);
                }
                Destroy(gameObject);

            }
        }
        if (current < waypoints.Length)
        {
            if (Time.timeScale == .03f)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
            }
            else if (Time.timeScale == 0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.gameObject.name+ "triggered" + "slowmo " + timeManager.slowmo);
        Debug.Log(timeManager.slowmo);
        if (other.gameObject == player && timeManager.slowmo)
        {
            Debug.Log(other.gameObject.name + "triggered");
            player = other.gameObject;
            other.transform.SetParent(transform);
            onplat = true;
            // Debug.Log("Entered " + other.name + " parent is " + other.transform.parent.name);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            other.transform.parent = null;
            Debug.Log("Left");
            onplat = false;
        }


    }

}
