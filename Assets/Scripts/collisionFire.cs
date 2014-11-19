using UnityEngine;
using System.Collections;

public class collisionFire : MonoBehaviour
{
    public World refWorld;

    void Update() {
        var w = GameObject.Find("World");
        if (w)
            refWorld.GetComponent<World>();
    }

	void OnTriggerEnter(Collider other){
		if (other.tag == "Eau") {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
		if(other.tag == "Player" || other.tag == "Papy")
		{
            // Il faut déclarer défaite
            if(refWorld)
                refWorld.declareDefeat();
		}
	}
}