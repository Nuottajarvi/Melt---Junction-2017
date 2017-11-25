using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

	public Sprite[] Faces;

	public float surprisedTrigger;

	private void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		if(GameController.instance.health <= 0) {
			spriteRenderer.sprite = Faces[2];
		}else if(surprisedTrigger < 1f && surprisedTrigger > -0.5f) {
			spriteRenderer.sprite = Faces[1];
		} else {
			spriteRenderer.sprite = Faces[0];
		}
		surprisedTrigger -= Time.deltaTime;
	}
}
