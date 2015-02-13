using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour {
	public float spawntime = 5;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, spawntime);
	}


}
