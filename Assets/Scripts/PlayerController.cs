using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb2d;
	private Vector2 movement; 
	private float angle;
	public Animator animator; 
	public float speed;
	
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	void Update(){
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");
		
		movement = new Vector2(moveHorizontal, moveVertical).normalized;
		Debug.Log(movement);
	
		if (movement.x < 0.1 && movement.x > -0.1  && movement.y > 0.1){ // north 
			angle = 90;
		}
		else if (movement.x < 0.1 && movement.x > -0.1  && movement.y < -0.1){ // south
			angle = 270;
		}
		else if (movement.x > 0.1 && movement.y < 0.1 && movement.y > -0.1){ // east
			angle = 0;
		}
		else if (movement.x < -0.1 && movement.y < 0.1 && movement.y > -0.1){ // west
			angle = 180;
		}
		else if (movement.x > 0.1 && movement.y > 0.1){ // north east
			angle = 45;
		}
		else if (movement.x > 0.1 && movement.y < -0.1){ // south east
			angle = 315;
		}
		else if (movement.x < -0.1 && movement.y > 0.1){ //  north west
			angle = 135;
		}
		else if (movement.x < -0.1 && movement.y < -0.1){ // south west
			angle = 225;
		}
		
	
		animator.SetFloat(name: "speed", value: Mathf.Max(Mathf.Abs(movement.x), Mathf.Abs(movement.y)));
	}

	void FixedUpdate()
	{
		transform.rotation = Quaternion.Euler(0,0,angle);
		//rb2d.AddForce(movement.normalized * speed);		
		rb2d.velocity = new Vector2(movement.x*speed, movement.y*speed);
	}
}






