using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb2d;
	private Vector2 movement; 
	private float lastDirection;
	public Animator animator; 
	public float speed;
	
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	void update(){
		
		
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");
		
		movement = new Vector2(moveHorizontal, moveVertical);
	
		if (movement.x < 0.1 && movement.x > -0.1  && movement.y > 0.1){ // north 
			lastDirection = 90;
		}
		else if (movement.x < 0.1 && movement.x > -0.1  && movement.y < -0.1){ // south
			lastDirection = 270;
		}
		else if (movement.x > 0.1 && movement.y < 0.1 && movement.y > -0.1){ // east
			lastDirection = 0;
		}
		else if (movement.x < -0.1 && movement.y < 0.1 && movement.y > -0.1){ // west
			lastDirection = 180;
		}
		else if (movement.x > 0.1 && movement.y > 0.1){ // north east
			lastDirection = 45;
		}
		else if (movement.x > 0.1 && movement.y < -0.1){ // south east
			lastDirection = 315;
		}
		else if (movement.x < -0.1 && movement.y > 0.1){ //  north west
			lastDirection = 135;
		}
		else if (movement.x < -0.1 && movement.y < -0.1){ // south west
			lastDirection = 225;
		}
		
	
		animator.SetFloat(name: "speed", value: Mathf.Max(Mathf.Abs(movement.x), Mathf.Abs(movement.y)));
		transform.rotation = Quaternion.Euler(0,0,lastDirection);
		rb2d.AddForce(movement * speed);		
	}
}






