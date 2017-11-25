using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController: MonoBehaviour {
	public static GameController instance;

	public float gameTime;
	public float health;
	public int score;

	public GameObject gameOverObj;

	public bool gameOver = false;

	// Use this for initialization
	void Awake () {
		if (instance) {
			Destroy(gameObject);
		} else {
			instance = this;
		}
		gameOverObj.GetComponent<Text>().CrossFadeAlpha(0, 0f, false);
	}
	
	// Update is called once per frame
	void Update () {
		gameTime += Time.deltaTime;

		if(health <= 0) {
			gameOverObj.GetComponent<Text>().CrossFadeAlpha(1, 0.25f, false);
			gameOver = true;
		}
	}
}
