using UnityEngine;
using System.Collections;

public class FireColumn : MonoBehaviour {

    public float Speed;
    public World refWorld;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    transform.Translate(new Vector3(Speed*Time.deltaTime/128f,0f,0f));
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" || other.tag == "Papy")
        {
            // Il faut déclarer défaite
            this.refWorld.declareDefeat();
        }
    }
}
