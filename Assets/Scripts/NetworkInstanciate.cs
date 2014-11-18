using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkInstanciate : MonoBehaviour
{
    public GameObject prefabPapy;
    public GameObject prefabFille;

	// Use this for initialization
	void Start ()
    {
        if (prefabPapy != null)
            Network.Instantiate(this.prefabPapy, this.prefabPapy.transform.position, this.prefabPapy.transform.rotation, 0);
        if (prefabFille != null)
            Network.Instantiate(this.prefabFille, this.prefabFille.transform.position, this.prefabFille.transform.rotation, 0);
	}
}
