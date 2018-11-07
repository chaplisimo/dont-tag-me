using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindPlayer : MonoBehaviour {

	[SerializeField]
	float fleeMultiplier = 3;

	Transform player;
	NavMeshAgent navMeshAgent;

	Tagging taggingScript;
	TagScript tagScript;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
		navMeshAgent = GetComponent<NavMeshAgent>();
		taggingScript = GetComponentInChildren<Tagging>();
		tagScript = GetComponentInChildren<TagScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(tagScript.IsTag()){
			navMeshAgent.SetDestination(player.position);
			if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance){
				taggingScript.Tag();
			}
		}else{
			//Debug.Log((player.position-transform.position).magnitude);
			if((player.position-transform.position).magnitude < 10f){
				//Debug.Log("Im CLOSE");
				if(navMeshAgent.remainingDistance < 0.5f || navMeshAgent.isStopped){
					//Debug.Log("Running away at speed:"+navMeshAgent.speed);
					Vector3 runAway = transform.position + (transform.position-player.position).normalized*navMeshAgent.speed * fleeMultiplier;
					navMeshAgent.SetDestination(runAway);
					navMeshAgent.isStopped = false;
				}
			}else{
				navMeshAgent.isStopped = true;
				//Debug.Log("Stopped");
			}
		}
	}
}
