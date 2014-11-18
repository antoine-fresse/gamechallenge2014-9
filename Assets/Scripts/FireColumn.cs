using UnityEngine;
using System.Collections;

public class FireColumn : MonoBehaviour {

    public float Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    transform.Translate(new Vector3(Speed*Time.deltaTime/128f,0f,0f));
	}

    void OnTriggerEnter2D(Collider other) {
        


    }
}
