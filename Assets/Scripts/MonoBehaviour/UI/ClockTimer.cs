using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClockTimer : MonoBehaviour {

	Text clockText;
	
	//TimeSpan timer = new TimeSpan(0,2,0)
	TimeSpan timer = TimeSpan.FromMinutes(2);

	// Use this for initialization
	void Start () {
		clockText = GetComponentInChildren<Text>();
		clockText.text = string.Format("{0:00}:{1:00}",timer.Minutes,timer.Seconds);;
		
		StartCoroutine(ClockTick());
	}
	
	IEnumerator ClockTick(){
		while(timer.CompareTo(TimeSpan.FromMinutes(0)) != 0){
			//Debug.Log("Ticking");
			yield return new WaitForSeconds(1);
			timer = timer.Subtract(TimeSpan.FromSeconds(1));
			clockText.text = string.Format("{0:00}:{1:00}",timer.Minutes,timer.Seconds);
		}
		Debug.Log("End of Match");
	}
}
