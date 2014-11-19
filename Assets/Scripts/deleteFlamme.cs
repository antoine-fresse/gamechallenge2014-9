using UnityEngine;
using System.Collections;

public class deleteFlamme : MonoBehaviour {
	public float speed;
	public float duree = 1.0f;

	void Start(){
		Destroy (gameObject, duree);
	}

	void Update()
	{
		transform.rigidbody.velocity = new Vector3(0.0f,0.0f,speed/128);
	}
}
