using UnityEngine;
using System.Collections;

public class FireExtinguisher : MonoBehaviour {

    public float Cooldown;

    public bool Activated { get; private set; }
	// Use this for initialization
	void Start () {
	    Activated = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other) {
        
    }

}
