using UnityEngine;

public class TagScript : MonoBehaviour { 

    public GameObject tagDisplay;

    [SerializeField]
	bool _ImTag = false;

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
	}

}