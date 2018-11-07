using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAndFollowPlayer : MonoBehaviour {
	[SerializeField]
	Transform player;
	[SerializeField]
	float smoothSpeed = 3;
	
	Vector3 offset;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
		offset = player.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position,player.position - offset, smoothSpeed * Time.deltaTime);
	}
}
