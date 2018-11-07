using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaggingParent : MonoBehaviour {
	
	TagScript tagScript;
	Animator handAnimator;
	Collider handCollider;

	[SerializeField]
	float tagForce = 5;
	
	[SerializeField]
	float tagCooldown = 1f;
	float cooldownControl = 0;

	void Start(){
		tagScript = GetComponent<TagScript>();
		handAnimator = GetComponentInChildren<Animator>();
		handCollider = GetComponentInChildren<BoxCollider>();
	}

	void Update () {
		if(cooldownControl > 0f){
			cooldownControl -= Time.deltaTime;
		}
	}
	
	void OnCollisionEnter(Collision collision){
		Debug.Log(gameObject.name + " hit "+collision.collider.gameObject.name);
		GameObject other = collision.collider.gameObject;
		if(!other.CompareTag(gameObject.tag)){
			other.GetComponent<Rigidbody>().AddForce(tagForce * collision.contacts[0].normal, ForceMode.Impulse);
			if(tagScript.IsTag()){
				Debug.Log("TAGGED");
				
				
				TagScript otherTag = other.GetComponentInParent<TagScript>();
				if(otherTag != null){
					otherTag.SetTag(true);
					this.tagScript.SetTag(false);
				}
			}
		}
	}

	public void Tag(){
		if(cooldownControl <= 0f){
			Debug.Log("Slapping");
			handAnimator.SetTrigger("Slap");
			cooldownControl = tagCooldown;
		}
	}
}