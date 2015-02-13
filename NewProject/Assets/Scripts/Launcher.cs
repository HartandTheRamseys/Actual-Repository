using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {
	public Rigidbody2D grenadePrefab;
	public Transform grenadeLaunch;
	public Rigidbody2D bulletPrefab;
	public Transform bulletLaunch;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			var mousePos =  Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			Debug.Log(mousePos);

			Rigidbody2D minion = Instantiate(bulletPrefab, bulletLaunch.position, bulletLaunch.rotation) as Rigidbody2D;
			
			minion.transform.LookAt(mousePos);
			minion.AddForce(minion.transform.forward * 10000f);
		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			var mousePos =  Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			Debug.Log(mousePos);
			
			Rigidbody2D minion = Instantiate(grenadePrefab, grenadeLaunch.position, grenadeLaunch.rotation) as Rigidbody2D;
			
			minion.transform.LookAt(mousePos);
			minion.AddForce(minion.transform.forward * 1500f);
		}
	}
}
