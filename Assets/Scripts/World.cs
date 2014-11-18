﻿using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    public GameObject prefabPapy;
    public GameObject prefabFille;
	public GameObject prefabLight;
	public GameObject prefabExtincteur;
	public bool isPapy;
    public bool testLocal;
	public GameObject papy;
	public GameObject fille;
	public GameObject light;
	public GameObject extincteur;

    public Transform StartPosition;
	// Use this for initialization
	void Start ()
    {
        // Papy : Serveur
        // Lenka : Client
        if (testLocal)
        {
            papy = Instantiate(this.prefabPapy, StartPosition.position, Quaternion.identity) as GameObject;
            fille = Instantiate(this.prefabFille, StartPosition.position + new Vector3(0.25f,0f,0f), Quaternion.identity) as GameObject;
			light = Instantiate(this.prefabLight, this.prefabLight.transform.position, this.prefabLight.transform.rotation) as GameObject;
			extincteur = Instantiate(this.prefabExtincteur, this.prefabExtincteur.transform.position, this.prefabExtincteur.transform.rotation)as GameObject;
        }
        else
        {
            if (Network.peerType == NetworkPeerType.Client)
            {
                this.isPapy = false;
                fille = Network.Instantiate(this.prefabFille, this.prefabFille.transform.position, this.prefabFille.transform.rotation, 0) as GameObject;
				extincteur = Network.Instantiate(this.prefabExtincteur, this.prefabExtincteur.transform.position, this.prefabExtincteur.transform.rotation,0)as GameObject;

			}
            else
            {
                this.isPapy = true;
				papy = Network.Instantiate(this.prefabPapy, this.prefabPapy.transform.position, this.prefabPapy.transform.rotation, 0) as GameObject;
				light = Network.Instantiate(this.prefabLight, this.prefabLight.transform.position, this.prefabLight.transform.rotation,0) as GameObject;
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