using UnityEngine;
using System.Collections;

public class VictoryZone : MonoBehaviour
{
    public World refWorld;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (!refWorld) {
	        var world = GameObject.Find("World");
	        if (world)
	            refWorld = world.GetComponent<World>();
	    }

	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
            if (other.gameObject.GetComponent<FilleAnimation>().Attached) {

                refWorld.declareVictory();

            }
        }

    }
}
