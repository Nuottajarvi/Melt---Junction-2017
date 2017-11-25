using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melt : MonoBehaviour {

	public GameObject drop;
	public float cooldown;
	private float timer;
	public GameObject center;
	public float startingHeight;

	System.Random random;

	void Start () {
		timer = cooldown;
		random = new System.Random();
	}
	
	void Update () {
		timer -= Time.deltaTime;

		if(timer < 0) {
			GameObject newdrop = Instantiate(drop, transform);

			System.Random random = new System.Random();
			int angle = random.Next (360);

			var x = Mathf.Cos(angle);
			var y = Mathf.Sin(angle);

			newdrop.transform.localPosition = new Vector3(x,y,startingHeight);
			newdrop.transform.localPosition = new Vector3(x,y,startingHeight);
			newdrop.transform.LookAt(center.transform);

			newdrop.GetComponent<Fall>().angle = angle;

			timer = cooldown * 2 * (float)random.NextDouble();
		}
	}
}
