using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float speed = 5;
	public float jumpHeight = 500;
	public bool isJumping = false;
	public static bool facingRight;


	// Use this for initialization
	void Start () {
		facingRight = true;

	}
	void FixedUpdate(){
		//Moving
		float move = Input.GetAxis ("Horizontal");
		if (move != 0) {
			rigidbody2D.velocity = new Vector2 (move * speed, rigidbody2D.velocity.y);
		}
		var mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);

		if (( mousePos.x > transform.localPosition.x) && !facingRight){
			Flip ();
		}
		else if (( mousePos.x < transform.localPosition.x) && facingRight)
		{
			Flip();
		}

	}
	
	// Update is called once per frame
	void Update () {
		//Jumping
		if (Input.GetKeyDown (KeyCode.Space)){
			if(isJumping == false){
				rigidbody2D.AddForce(Vector2.up * jumpHeight);
				isJumping = true;
			}
		}

	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Platform") {
			isJumping = false;
		}
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
