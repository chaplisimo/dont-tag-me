using UnityEngine;

public class HandController : MonoBehaviour {
    
    Collider handCollider;
    Animator handAnimator;

    private void Start() {
        handCollider = GetComponent<BoxCollider>();   
        handAnimator = GetComponent<Animator>();
    }

    public void Slap(){
        //Debug.Log("Slapping");
        handAnimator.SetTrigger("Slap");
    }

	public void ToggleHandCollider(int active){
		//Debug.Log("Toggling Hand:"+ (active==1?"true":"false"));
		handCollider.enabled = active == 1 ? true : false;
	}
}