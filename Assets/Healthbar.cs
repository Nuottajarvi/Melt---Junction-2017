using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

	public Image[] cones;
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < cones.Length; i++) {
			if (i >= GameController.instance.health) {
				cones[i].CrossFadeAlpha(0, 0.25f, false);
			}
		}
	}
}
