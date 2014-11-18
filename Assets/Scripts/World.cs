using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    public GameObject prefabPapy;
    public GameObject prefabFille;
	public bool isPapy;
    public bool testLocal;
	
	// Use this for initialization
	void Start ()
    {
        // Papy : Serveur
        // Lenka : Client
        if (testLocal)
        {
            Instantiate(this.prefabPapy, this.prefabPapy.transform.position, this.prefabPapy.transform.rotation);
            Instantiate(this.prefabFille, this.prefabFille.transform.position, this.prefabFille.transform.rotation);
        }
        else
        {
            if (Network.peerType == NetworkPeerType.Client)
            {
                this.isPapy = false;
                Network.Instantiate(this.prefabFille, this.prefabFille.transform.position, this.prefabFille.transform.rotation, 0);
            }
            else
            {
                this.isPapy = true;
                Network.Instantiate(this.prefabPapy, this.prefabPapy.transform.position, this.prefabPapy.transform.rotation, 0);
            }
        }
       
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