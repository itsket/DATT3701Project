using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Stars : MonoBehaviour
{
    
    public GameObject intializedMesh;

    public int numPoints = 100;
    public Material invicible;
    [SerializeField] private int layer1 = 8;
    [SerializeField] private int layer2 = 0;
    private int layerAsLayerMask1;
    private int layerAsLayerMask2;
    public Material star1;
    public Material star2;
        public Material star3;
    public Material star4;
    public float maxSize = 1f;
    public float minSize = .1f;
    public Material material2;

    private void Awake()
    {
        layerAsLayerMask1 = (1 << layer1);
        layerAsLayerMask2 = (1 << layer2);
    }
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
            if (IsInMesh(randomPoint)) {

                GameObject currentStar = Instantiate(intializedMesh, randomPoint, Quaternion.identity);
                //  currentStar.transform.SetParent(transform); 
                float rando = Random.Range(minSize, maxSize);
                currentStar.transform.localScale = currentStar.transform.localScale * rando;

                if (rando < maxSize / 1.08f) {
                    currentStar.GetComponent<TrailRenderer>().startWidth = 2.5f;
                    currentStar.GetComponent<TrailRenderer>().endWidth = 0f;
                    currentStar.GetComponent<TrailRenderer>().time = .1f;
                    if(material2 != null)
                    currentStar.GetComponent<TrailRenderer>().material = material2;
                }
              /*  if (pointsGenerated > numPoints / 1.02f)
                {
                    int rando = Random.Range(1, 2);
                    switch (rando)
                    {
                        case 1:
                            currentStar.GetComponent<Renderer>().material = star2;
                            break;
                     
                        default:
                            currentStar.GetComponent<Renderer>().material = star3;
                            break;
                    }
                }
              */
                currentStar.transform.SetParent(transform.parent);
               
            }


            
        }

        bool IsInMesh(Vector3 givenPoint)
           
        {
          
            Collider[] hitColliders = Physics.OverlapSphere(givenPoint, 0f, layerAsLayerMask1);
            Collider[] hitColliders2 = Physics.OverlapSphere(givenPoint, 0f, layerAsLayerMask2);

          

            if (hitColliders.Length > 0 && hitColliders2.Length == 0)
            {
                return true;
            }
            else { 
            return false;
            }
        }
       
        
    }
  

}
