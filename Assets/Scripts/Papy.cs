using UnityEngine;
using System.Collections;

public class Papy : MonoBehaviour {

    private bool _holdHand;
    public bool holdHand {
        get { return _holdHand; }
        set {
            if(value != _holdHand && networkView.isMine)
                networkView.RPC("HasChanged", RPCMode.OthersBuffered, value);
            _holdHand = value;
        }
    }
    
    public bool filleTouche; // On est collé la la fille;

    private Animator _animator;
	// Use this for initialization
	void Start () {
        _holdHand = false;
		filleTouche = false;
	    _animator = GetComponent<Animator>();
	}

    public void callHide() {
        networkView.RPC("Hide", RPCMode.All);
    }

    public void callShow(Transform t)
    {
        networkView.RPC("Show", RPCMode.All, t.position);
    }

    [RPC]
    void HasChanged(bool b) {
        _holdHand = b;
    }

    [RPC]
    void Hide() {
        _animator.SetBool("hidden", true);
        collider.enabled = false;
        
    }

    [RPC]
    void Show(Vector3 t) {
        _animator.SetBool("hidden", false);
        collider.enabled = true;
        transform.position = t + new Vector3(-0.215f, 0f,0f);
    }


	// Update is called once per frame
	void Update () {
		_animator.SetBool("holdHand", holdHand);
	}
	
	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player"){
			//filleTouche = true;

		}
	}
	
	void OnTriggerStay(Collider c){
		if (c.gameObject.tag == "Player"){
			if (TouchOnRight(c)){
				filleTouche = true;
			}
		} 
	}
	
	void OnTriggerExit(Collider c){
		if (c.gameObject.tag == "Player") {
		    filleTouche = false;
		} 
	}
	
	public bool TouchOnRight(Collider c) {
	    float dist = Mathf.Abs(c.gameObject.transform.position.x - transform.position.x - 0.2f);

        //Debug.Log(dist);
	    return dist <= 0.2f;
	}
	
	
}
