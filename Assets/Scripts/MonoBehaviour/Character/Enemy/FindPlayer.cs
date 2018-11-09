using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindPlayer : MonoBehaviour {

	public float fleeMultiplier = 1;
	public float minFleeDistance = 10f;

	Transform player;
	NavMeshAgent navMeshAgent;

	TaggingParent taggingScript;
	TagScript tagScript;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
		
		navMeshAgent = GetComponent<NavMeshAgent>();

		taggingScript = GetComponent<TaggingParent>();
		tagScript = GetComponent<TagScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(tagScript.IsTag()){
			navMeshAgent.SetDestination(player.position);
			if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance){
				taggingScript.Tag();
			}
		}else{
			float offset = (player.position-transform.position).magnitude;
			if(offset < minFleeDistance){				
				//1.5f is hardcoded as the distance between bounding boxes (player & IA)
				if(navMeshAgent.remainingDistance < 1.5f || navMeshAgent.isStopped){
					Debug.Log("Running away at speed:"+navMeshAgent.speed);
					Vector3 runAway = transform.position + (transform.position-player.position).normalized*navMeshAgent.speed * fleeMultiplier;
					navMeshAgent.SetDestination(runAway);
					navMeshAgent.isStopped = false;
				}
			}else{
				navMeshAgent.isStopped = true;
			}
		}
	}
}
