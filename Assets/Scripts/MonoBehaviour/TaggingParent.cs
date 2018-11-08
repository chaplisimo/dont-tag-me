using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaggingParent : MonoBehaviour {
	
	TagScript tagScript;
	HandController handController;

	[SerializeField]
	float tagForce = 5;
	
	[SerializeField]
	float tagCooldown = 1f;
	float cooldownControl = 0;

	void Start(){
		tagScript = GetComponent<TagScript>();
		handController = GetComponentInChildren<HandController>();
	}

	void Update () {
		if(cooldownControl > 0f){
			cooldownControl -= Time.deltaTime;
		}
	}
	
	void OnCollisionEnter(Collision collision){
		foreach (ContactPoint contact in collision.contacts){
			//Debug.Log(LayerMask.LayerToName(contact.thisCollider.gameObject.layer) + " hit " + contact.otherCollider.gameObject);

			//If hand hit something
			if(contact.thisCollider.gameObject.layer.Equals(LayerMask.NameToLayer("Attack"))){

				GameObject other = contact.otherCollider.gameObject;
				//Debug.Log(other);
				other.GetComponent<Rigidbody>().AddForce(tagForce * -contact.normal, ForceMode.VelocityChange);
				if(tagScript.IsTag()){
					TagScript otherTag = other.GetComponentInParent<TagScript>();
					if(otherTag != null){
						Debug.Log("TAGGED");
						otherTag.SetTag(true);
						this.tagScript.SetTag(false);
					}
				}
				//Avoid Colliding many times
				handController.ToggleHandCollider(0);
				break;
			}
		}
	}

	public void Tag(){
		if(cooldownControl <= 0f){
			handController.Slap();
			cooldownControl = tagCooldown;
		}
	}

}