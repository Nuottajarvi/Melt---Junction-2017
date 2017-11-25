using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lick : MonoBehaviour {

	public DropCollider drops;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse X")) * Time.deltaTime * -100);

		if (Input.GetMouseButtonDown(0) && !GameController.instance.gameOver) {
			drops.DeleteDrops();
		}
	}
}
