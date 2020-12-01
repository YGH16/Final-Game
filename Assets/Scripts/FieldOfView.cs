using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldOfView : MonoBehaviour
{
    // Start is called before the first frame update
    private Mesh mesh;
    private float fov;
    private Vector3 origin; 
    private float startingAngle; 
    private float viewDistance;
    [SerializeField] private LayerMask layerMask;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
    }

    private void LateUpdate(){

        
        int rayCount = 45;
        float angle = startingAngle;
        float angleInc = fov/rayCount;
        

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount*3];

        vertices[0] = origin;
        int triangleIndex = 0;
        int vertexIndex = 1;
        for (int i = 0; i <= rayCount; i++){
            float angleRad = angle * (Mathf.PI/180f);
            Vector3 vectorAngle = new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad)); 
            Vector3 vertex;

            RaycastHit2D raycastHit = Physics2D.Raycast(origin, vectorAngle, viewDistance, layerMask);
            
            if(raycastHit.collider == null){
                vertex = origin + vectorAngle*viewDistance;}
            else{
                //Debug.Log("hello");
                if (raycastHit.collider.tag == "Player"){
                    SceneManager.LoadScene("Wasted");
                    break;
                }
                vertex = raycastHit.point;

            } 
            //Debug.DrawRay(origin, vertex, Color.blue, 10);

            vertices[vertexIndex]  = vertex;
            if (i>0){
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex ++; 
            angle -= angleInc;
            


        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        
    }
    public void SetOrigin(Vector3 origin){
        this.origin = origin; 
    }
  
    public void SetAimDirection(Vector3 aimDir){
        Vector3 dir = aimDir.normalized; 
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n<0){n+=360;}
        startingAngle = n + fov/2f;
    }

    public void SetFoV(float fov){
        this.fov = fov; 
    }

    public void SetViewDistance(float vd){
        this.viewDistance = vd;  
    }
}
