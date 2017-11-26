using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform follow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float rot = (Mathf.Abs(follow.rotation.z) - 0.25f) * 2;
		float minx = 0f;
		float maxx = 0.48f;
		transform.localPosition = new Vector3(minx + (maxx - minx) * rot, transform.localPosition.y, transform.localPosition.z);
	}
}
