using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lick : MonoBehaviour {

	public DropCollider drops;
	public float cooldown;
	private float maxCD;

	// Use this for initialization
	void Start () {
		//Cursor.lockState = CursorLockMode.Locked;
		maxCD = cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse X")) * Time.deltaTime * -100);
		// cooldown -= Time.deltaTime;
		// if (Input.GetMouseButtonDown(0) && cooldown < 0 && !GameController.instance.gameOver) {
		// 	drops.DeleteDrops();
		// 	cooldown = maxCD;
		// }
	}
}
