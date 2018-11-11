using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBallDrop : MonoBehaviour {

	CharacterInfo characterInfo;

	private void Start() {
		characterInfo = GetComponent<CharacterInfo>();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer.Equals(LayerMask.NameToLayer("BallDrop"))){
			BallDrop ballDrop = other.GetComponent<BallDrop>();
			characterInfo.playerScore += ballDrop.ballScore;
			Destroy(ballDrop.gameObject);
		}
	}
}
