using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    public GameObject prefabPapy;
    public GameObject prefabFille;
	public GameObject prefabLumiere;
	public GameObject prefabExtincteur;
	public bool isPapy;
    public bool testLocal;
	public GameObject papy;
	public GameObject fille;
	public GameObject l;
	public GameObject extincteur;

    public Transform StartPosition;
	// Use this for initialization
	void Awake ()
    {
        // Papy : Serveur
        // Lenka : Client
        if (testLocal)
        {
            papy = Instantiate(this.prefabPapy, StartPosition.position, Quaternion.identity) as GameObject;
            fille = Instantiate(this.prefabFille, StartPosition.position + new Vector3(0.25f,0f,0f), Quaternion.identity) as GameObject;
            l = Instantiate(this.prefabLumiere, this.prefabLumiere.transform.position, this.prefabLumiere.transform.rotation) as GameObject;
			extincteur = Instantiate(this.prefabExtincteur, this.prefabExtincteur.transform.position, this.prefabExtincteur.transform.rotation)as GameObject;
        }
        else
        {
            if (Network.peerType == NetworkPeerType.Client)
            {
                this.isPapy = false;
                fille = Network.Instantiate(this.prefabFille, StartPosition.position + new Vector3(0.25f, 0f, 0f), Quaternion.identity, 0) as GameObject;
                var extPos = new Vector3(StartPosition.position.x, StartPosition.position.y, -0.75f);
                extincteur = Network.Instantiate(this.prefabExtincteur, extPos, Quaternion.identity, 0) as GameObject;
			}
            else
            {
                this.isPapy = true;
                papy = Network.Instantiate(this.prefabPapy, StartPosition.position, Quaternion.identity, 0) as GameObject;
                l = Network.Instantiate(this.prefabLumiere, this.prefabLumiere.transform.position, this.prefabLumiere.transform.rotation, 0) as GameObject;
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

    public void declareDefeat()
    {
        networkView.RPC("defeat", RPCMode.AllBuffered);
    }

    [RPC]
    private void defeat()
    {
        Application.LoadLevel("Defaite");
    }

    public void declareVictory()
    {
        networkView.RPC("victory", RPCMode.AllBuffered);
    }

    [RPC]
    private void victory()
    {
        Application.LoadLevel("Victoire");
    }
}