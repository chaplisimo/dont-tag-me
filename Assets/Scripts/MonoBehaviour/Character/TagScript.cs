using UnityEngine;
using UnityEngine.Events;

public class TagScript : MonoBehaviour { 

    [SerializeField]
	bool _ImTag = false;

    public GameObject tagDisplay;
	public UnityEvent OnPlayerTagged;
	public UnityEvent OnPlayerUntagged;
	
    void Start () {
		//_ImTag = false;
		tagDisplay.SetActive(_ImTag);
	}

    public bool IsTag(){
		return _ImTag;
	}

	public void SetTag(bool isTag){
		this._ImTag = isTag;

        if(this.tagDisplay!=null){
            this.tagDisplay.SetActive(isTag);
        };

		if(isTag && OnPlayerTagged!=null){
			OnPlayerTagged.Invoke();
		}else if(!isTag && OnPlayerUntagged!=null){
			OnPlayerUntagged.Invoke();
		}
	}

}