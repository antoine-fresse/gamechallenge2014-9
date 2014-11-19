using UnityEngine;
using System.Collections;

public class Papy : MonoBehaviour {
	
	public bool holdHand; // On appuie sur l'ecran
	public bool filleTouche; // On est collé la la fille;

    private Animator _animator;
	// Use this for initialization
	void Start () {
		holdHand = false;
		filleTouche = false;
	    _animator = GetComponent<Animator>();
	}

    [RPC]
    public void Hide() {
        _animator.SetBool("hidden", true);
        collider.enabled = false;
        
    }

    [RPC]
    public void Show(Transform t) {
        _animator.SetBool("hidden", false);
        collider.enabled = true;
        transform.position = t.position + new Vector3(-0.215f, 0f,0f);
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
