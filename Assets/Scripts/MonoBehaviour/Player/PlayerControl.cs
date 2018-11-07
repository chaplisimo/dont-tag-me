using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
	//, IGameEventListener
	 {

	public float movementSpeed = 5;
	public float rotationSpeed = 180;

	//TAGGING
	[SerializeField]
	KeyCode tagKey = KeyCode.F;
	TaggingParent taggingScript;
	//Tagging taggingScript;

	bool isPlayerAlive = true;

	new Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		//taggingScript = GetComponentInChildren<Tagging>();
		taggingScript = GetComponent<TaggingParent>();
	}
	
	void Update(){
		if(Input.GetKey(tagKey)){
			taggingScript.Tag();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		float hMove = Input.GetAxisRaw("Horizontal");
		float vMove = Input.GetAxisRaw("Vertical");
		// Simple movement
		if((hMove != 0 || vMove != 0) && isPlayerAlive){
			Vector3 newPosition = rigidbody.position + new Vector3(hMove,0,vMove) * movementSpeed * Time.fixedDeltaTime;
			rigidbody.MovePosition(newPosition);
			//rigidbody.MoveRotation(Quaternion.LookRotation(newPosition,transform.up));
			rigidbody.rotation = Quaternion.Lerp(rigidbody.rotation,
												Quaternion.LookRotation(new Vector3(hMove,0,vMove)),
												rotationSpeed * Time.fixedDeltaTime);
		}
	}

	public void OnEnable(){
		//OnPlayerDied.RegisterListener(this);
	}

	public void OnDisable(){
		//OnPlayerDied.UnregisterListener(this);
	}

	/*public void OnEventRaised(GameEvent evnt){
		isPlayerAlive = false;
	}*/
}
