using UnityEngine;
using System.Collections;

public class collisionFire : MonoBehaviour {
	public bool bigFire = false;
	public Transform SmallFire;
	void OnTriggerEnter(Collider other){
		if (other.tag == "Eau") {

			if(bigFire)
				Instantiate(SmallFire, transform.position, Quaternion.identity);

			Destroy (gameObject);
			Destroy (other.gameObject);
		}
		if(other.tag == "Player" || other.tag == "Papy")
		{
			World.instance.declareDefeat();
		}
	}
}