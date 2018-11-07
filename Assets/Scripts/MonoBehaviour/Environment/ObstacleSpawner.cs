using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public float spawnRadius = 5f;
	public float spawnRate = 2f;

	public GameObject[] obstacles;

	float rateController = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(rateController > 0){
			rateController -= Time.deltaTime;
		}
		if(rateController <= 0){
			Vector3 randPos = new Vector3(Random.Range(-spawnRadius,spawnRadius),5f,Random.Range(-spawnRadius,spawnRadius));
			GameObject obstacle = GameObject.Instantiate(obstacles[0],randPos,Quaternion.identity);
			obstacle.transform.SetParent(transform);

			rateController = spawnRate;
		}
	}
}
