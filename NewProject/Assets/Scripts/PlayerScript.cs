using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float speed = 5;
	public float jumpHeight = 500;
	public bool isJumping = false;
	// Use this for initialization
	void Start () {
	
	}
	void FixedUpdate(){
		float move = Input.GetAxis ("Horizontal");
		if (move != 0) {
			rigidbody2D.velocity = new Vector2 (move * speed, rigidbody2D.velocity.y);
		}
	}
	
	// Update is called once per frame
	void Update () {
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
}
