using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melt : MonoBehaviour {

	public GameObject drop;
	public float cooldown;
	private float timer;

	void Start () {
		timer = cooldown;
	}
	
	void Update () {
		timer -= Time.deltaTime;

		if(timer < 0) {
			GameObject newdrop = Instantiate(drop, transform);

			System.Random random = new System.Random();
			int angle = random.Next (360);

			var x = Mathf.Cos(angle) * 1.5f;
			var z = Mathf.Sin(angle) * 1.5f;

			newdrop.transform.position = new Vector3(x,0,z);
			newdrop.transform.position = new Vector3(x,0,z);
			newdrop.transform.LookAt(transform);

			timer = cooldown;
		}
	}
}
