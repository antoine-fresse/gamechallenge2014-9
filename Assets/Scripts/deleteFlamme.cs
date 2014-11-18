using UnityEngine;
using System.Collections;

public class deleteFlamme : MonoBehaviour {

	void Start(){
		//Destroy (gameObject, 2f);
	}

	void FixedUpdate()
	{
		Vector3 v = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.1f);
		//transform.position = v;
	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("b");
		if (other.tag == "Fire")
			Destroy (other.gameObject);
	}
}
