using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDrop : MonoBehaviour {

	public int amountDroppedWhenTagged = 10;
	public int amountDroppedOnTime = 10;
	[Range(0,30)]
	public int dropEverySeconds = 2;

	public ForceMode forceMode;

	public GameObject ballDropPrefab;

	BallDrop ballDrop;
	CharacterInfo characterInfo;

	private void Start() {
		characterInfo = GetComponentInParent<CharacterInfo>();
		ballDrop = ballDropPrefab.GetComponent<BallDrop>();
	}

	public void OnTagEvent(bool tagged){
		if(tagged){
			DropScoreWhenTagged();
		}else{
			StopCoroutine(DropScoreOnTime());
		}
	}

	void DropScoreWhenTagged(){
		for(int i=0;i<amountDroppedWhenTagged;i++){
			GameObject obj = GameObject.Instantiate(ballDropPrefab,transform.position,transform.rotation);
			//obj.GetComponent<Rigidbody>().AddExplosionForce(100f,obj.transform.position,2f);
			obj.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * 5f, forceMode);
		}

		characterInfo.playerScore -= ballDrop.ballScore * amountDroppedWhenTagged;
		Debug.Log("U DROP "+amountDroppedWhenTagged+" COINS. CURRENT SCORE: "+ characterInfo.playerScore);

		StartCoroutine(DropScoreOnTime());
	}

	IEnumerator DropScoreOnTime(){
		while(true){
			yield return new WaitForSeconds(dropEverySeconds);

			for(int i=0;i<amountDroppedOnTime;i++){
				GameObject obj = GameObject.Instantiate(ballDropPrefab,transform.position,transform.rotation);
				obj.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere.normalized * 5f, forceMode);
			}
			characterInfo.playerScore -= ballDrop.ballScore * amountDroppedOnTime;
			Debug.Log("DOT MADE U LOSE "+amountDroppedOnTime+" COINS");
		}
	}
}
