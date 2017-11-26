using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {

	public float speed;
	public int angle;

	// Use this for initialization
	void Start () {
		System.Random random = new System.Random();
		speed *= ((float)random.NextDouble() + 0.5f);
		speed += GameController.instance.gameTime / 100;
	}
	
	// Update is called once per frame
	void Update () {

		//Cone is 4 high
		transform.position += Vector3.down * Time.deltaTime * speed;

		float distance = 2 - transform.localPosition.z;

		var x = Mathf.Cos(angle) / 4 * (4 - distance);
		var y = Mathf.Sin(angle) / 4 * (4 - distance);

		if (transform.localPosition.z > -2) {
			transform.localPosition = new Vector3(x, y, transform.localPosition.z);
			transform.localPosition = new Vector3(x, y, transform.localPosition.z);

		} else {
			transform.rotation = Quaternion.identity;
			speed += Time.deltaTime * 3;
		}

		if(transform.position.y < -6) {
			GameController.instance.health--;
			Destroy(gameObject);
		}
	}
}
