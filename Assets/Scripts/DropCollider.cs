using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollider : MonoBehaviour {

	List<GameObject> drops;

	// Use this for initialization
	void Start () {
		drops = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, Input.GetAxis("Mouse Y") * 0.1f, 0));
	}

	void OnTriggerEnter(Collider other) {
		drops.Add(other.gameObject);
	}

	void OnTriggerExit(Collider other) {
		drops.Remove(other.gameObject);
	}

	public void DeleteDrops() {

		GetComponent<Animator>().SetTrigger("Lick");

		Debug.Log(drops.Count);
		for(int i = drops.Count - 1; i >= 0; i--) {
			Destroy(drops[i]);
			drops.RemoveAt(i);
			GameController.instance.score++;
		}
	}
}
