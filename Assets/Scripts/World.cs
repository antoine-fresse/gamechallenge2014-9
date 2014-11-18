using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    public GameObject prefabPapy;
    public GameObject prefabFille;
	public bool isPapy;
	
	// Use this for initialization
	void Start ()
    {
        Network.Instantiate(this.prefabPapy, this.prefabPapy.transform.position, this.prefabPapy.transform.rotation, 0);
        Network.Instantiate(this.prefabFille, this.prefabFille.transform.position, this.prefabFille.transform.rotation, 0);

        // Papy : Serveur
        // Lenka : Client
        this.isPapy = !(Network.peerType == NetworkPeerType.Client);
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        Application.LoadLevel("Menu");
    }
}