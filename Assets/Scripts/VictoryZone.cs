using UnityEngine;
using System.Collections;

public class VictoryZone : MonoBehaviour
{
    public World refWorld;

    private bool papyIn;
    private bool lenkaIn;

	// Use this for initialization
	void Start () {
        papyIn = false;
        lenkaIn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lenkaIn = true;
        }
        else if (other.tag == "Papy")
        {
            papyIn = true;
        }
        if (papyIn && lenkaIn)
            this.refWorld.declareVictory();
    }
}
