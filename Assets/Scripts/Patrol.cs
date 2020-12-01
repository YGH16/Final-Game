using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{   
    public float speed; 
    private float waitTime;
    public float startWaitTime; 


    public Animator animator; 
    public Transform[] patrolPoints; 
    private int nextPoint; 

    private Vector3 direction; 

    [SerializeField] private Transform pffieldOfView; 
    [SerializeField] private float fov;
    [SerializeField] private float viewDistance;
    private FieldOfView fieldOfView;

    // Start is called before the first frame update
    void Start()
    {
        nextPoint = 0;
        direction = (patrolPoints[nextPoint].position - transform.position).normalized;
        fieldOfView = Instantiate(pffieldOfView, null).GetComponent<FieldOfView>();

        fieldOfView.SetFoV(fov); 
        fieldOfView.SetViewDistance(viewDistance);
    }   

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[nextPoint].position, speed * UnityEngine.Time.deltaTime);
        if(Vector2.Distance(transform.position, patrolPoints[nextPoint].position) < 0.2f){
            animator.SetFloat(name:"speed",value:0);
            if(waitTime <= 0){
                nextPoint = ((nextPoint+1) % patrolPoints.Length);
                waitTime = startWaitTime;
                direction = (patrolPoints[nextPoint].position - transform.position).normalized;  
                float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0,0,n);
            }
            else{
                waitTime -= UnityEngine.Time.deltaTime; 

            }  
        
        }
        else{
            animator.SetFloat(name:"speed",value:speed);
        }
        fieldOfView.SetOrigin(this.transform.position);
        fieldOfView.SetAimDirection(direction);
		
        
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		SceneManager.LoadScene("Wasted");
		print("oww");

	}
}
