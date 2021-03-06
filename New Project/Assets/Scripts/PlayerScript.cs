using UnityEngine;
using System.Collections;


public class PlayerScript : MonoBehaviour {
	public float speed = 5;
	public static bool facingRight;
	private bool take_damage = true;
	public float dodge_speed = 2;
	private bool isDodging = false;
	private float step;
	public float hp = 10;
	public float dmg = 2;
	public float attackdistance = 2;

	// Use this for initialization
	void Start () {
		facingRight = true;
		
	}
	void dodge(bool stationary)
	{
		take_damage = false;
		isDodging = true;
		if (!stationary) {
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x * dodge_speed, rigidbody2D.velocity.y * dodge_speed);
				}
		else {	

//			Debug.Log ("deltatime "+Time.deltaTime+ "step " +step);
			Transform child = transform.FindChild("BackDodge");
			this.transform.position = Vector2.MoveTowards(this.transform.position,child.transform.position,dodge_speed);
//			var mouse_vec = Input.mousePosition;
//			float dx = mouse_vec.x-transform.position.x;
//			float dy = mouse_vec.y- transform.position.y;
//			float rangle = Mathf.Atan(dx/dy);
//			Debug.Log("rangle "+rangle);
//			float reverse_speed_x=Mathf.Cos(rangle)*speed;
//			float reverse_speed_y=Mathf.Sin(rangle)*speed;
//			rigidbody2D.velocity = new Vector2 (reverse_speed_x * dodge_speed, reverse_speed_y * dodge_speed);
				}
		isDodging = false;
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

		if (move == 0 && move_y == 0)
						stationary = true;

		if (Input.GetKeyDown (KeyCode.Space)) {
			if(isDodging == false){
				dodge(stationary);
			}
		}
	
		if (Input.GetMouseButtonDown (0)) {
			float dis = Vector2.Distance (this.gameObject.transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position);
			Debug.Log("clicked" + dis);
			if (dis <= attackdistance){
				Attack();
			}
		}

		var mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);



		
	}
	
	// Update is called once per frame
	void Update () {

		//TODO add direction via mouse
		var mousepos = Input.mousePosition;
		var objectPos = Camera.main.WorldToScreenPoint (transform.position);
	
		Vector3 relativepos = mousepos - objectPos;
		Quaternion rot = Quaternion.LookRotation (relativepos);

		transform.rotation = rot*Quaternion.Euler (0,90,0);

		step = dodge_speed * Time.deltaTime;



		
	}
	void OnCollisionEnter2D(Collision2D col){
		
	}

	void Death(){
		Application.LoadLevel(Application.loadedLevel);		
	}

	void ApplyDamage(float damage) {
		hp -= damage;
		if (hp <= 0) {
			Destroy (this.gameObject);
		}
	}
	void Attack() {
		Debug.Log ("sent damage");

		GameObject.FindGameObjectWithTag("Enemy").SendMessage("ApplyDamage", dmg,SendMessageOptions.DontRequireReceiver);
	}
}


