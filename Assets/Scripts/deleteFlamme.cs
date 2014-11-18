using UnityEngine;
using System.Collections;

public class deleteFlamme : MonoBehaviour {
	public float speed;
	public float distance;

	void Start(){
		Destroy (gameObject, distance/(speed/128));
	}

	void Update()
	{
		transform.rigidbody.velocity = new Vector3(0.0f,0.0f,speed/128);
	}
}
