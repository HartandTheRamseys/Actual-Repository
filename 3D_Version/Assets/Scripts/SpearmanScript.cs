using UnityEngine;
using System.Collections;

public class SpearmanScript : MonoBehaviour {
	public float hp = 3;
	public float dmg = 1;
	public float attackdistance = 2;
	// Use this for initialization
	void Start () {
		renderer.material.color = Color.red;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void ApplyDamage(float damage) {
		hp -= damage;
		Debug.Log ("spearman damage applied");
		if (hp <= 0) {
			Destroy (this.gameObject);
		}
	}
	void Attack() {
		gameObject.SendMessage("ApplyDamage", dmg);
	}
//	void OnMouseDown(){
//		if (Vector2.Distance (this, GameObject.Find ("Character").transform.position) <= attackdistance) {
//			Attack();
//		}
//	}
}
