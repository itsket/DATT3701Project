using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Stars : MonoBehaviour
{
    
    public GameObject intializedMesh;
    public int numPoints = 100;
    public Material invicible;
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = invicible;
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;
        Bounds bounds = mesh.bounds;

        int pointsGenerated = 0;
        Vector3[] points = new Vector3[numPoints];

        while (pointsGenerated < numPoints)
        {
            Vector3 randomPoint = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
          
                randomPoint = gameObject.transform.TransformPoint(randomPoint);
                points[pointsGenerated] = randomPoint;
                pointsGenerated++;

               
                GameObject currentStar = Instantiate(intializedMesh, randomPoint, Quaternion.identity);
          //  currentStar.transform.SetParent(transform); 
            currentStar.transform.localScale = currentStar.transform.localScale * Random.Range(.1f,1f);

            
        }

       
        
    }
  

}
