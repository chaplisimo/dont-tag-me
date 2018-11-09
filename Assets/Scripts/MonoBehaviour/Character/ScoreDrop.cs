using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDrop : MonoBehaviour {

	public int amountDroppedWhenTagged = 10;
	public int amountDroppedOnTime = 10;
	[Range(0,30)]
	public int dropEverySeconds = 2;

	public void OnTagEvent(bool tagged){
		if(tagged){
			DropScoreWhenTagged();
		}else{
			StopCoroutine(DropScoreOnTime());
		}
	}

	void DropScoreWhenTagged(){
		Debug.Log("U DROP "+amountDroppedWhenTagged+" COINS");
		StartCoroutine(DropScoreOnTime());
	}

	IEnumerator DropScoreOnTime(){
		while(true){
			yield return new WaitForSeconds(dropEverySeconds);
			Debug.Log("DOT MADE U LOSE "+amountDroppedOnTime+" COINS");
		}
	}
}
