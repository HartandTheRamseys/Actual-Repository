using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float speed = 5;
	public static bool facingRight;
	private bool take_damage = true;
	public float dodge_speed = 10;
	
	// Use this for initialization
	void Start () {
		facingRight = true;
		
	}
	void dodge(bool stationary)
	{
		take_damage = false;
		if (!stationary) {
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x * dodge_speed, rigidbody2D.velocity.y * dodge_speed);
				} else {


				}
		take_damage = true;
		}
		
	void FixedUpdate(){
		//Moving
		//TODO add direction via mouse
		float move = Input.GetAxis ("Horizontal");
		float move_y = Input.GetAxis("Vertical");
		bool stationary = false;


			rigidbody2D.velocity = new Vector2 (move * speed, rigidbody2D.velocity.y);

			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move_y * speed);

		if (move == move_y == 0)
						stationary = true;


		/*
		var mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);

		if (( mousePos.x > transform.localPosition.x) && !facingRight){
			Flip ();
		}
		else if (( mousePos.x < transform.localPosition.x) && facingRight)
		{
			Flip();
		}*/
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		/*
		//Jumping
		if (Input.GetKeyDown (KeyCode.Space)){
			if(isJumping == false){
				rigidbody2D.AddForce(Vector2.up * jumpHeight);
				isJumping = true;
			}
	}*/
		
	}
	void OnCollisionEnter2D(Collision2D col){
		
	}
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void Death(){
		Application.LoadLevel(Application.loadedLevel);
		
	}
}


