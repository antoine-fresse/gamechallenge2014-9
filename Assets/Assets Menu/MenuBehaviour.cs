using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuBehaviour : MonoBehaviour
{
    public string IP;
    public int Port = 25001;
    public List<GameObject> menuPrincipal;
    public GameObject messageAttenteServeur;
    public GameObject messageAttenteClient;
    // Deux variables dégeulasses néccessaires :
    private bool attServeur = false;
    private bool attClient = false;

    void Setup()
    {
        for (int i = 0; i < this.menuPrincipal.Count; i++)
            this.menuPrincipal[i].gameObject.SetActive(true);
        /*this.menuPrincipal[1].gameObject.SetActive(true);
        this.menuPrincipal[2].gameObject.SetActive(true);
        this.menuPrincipal[3].gameObject.SetActive(true);*/
        this.messageAttenteServeur.gameObject.SetActive(false);
        this.messageAttenteClient.gameObject.SetActive(false);
    }

    void Update()
    {
        this.messageAttenteServeur.gameObject.SetActive(attServeur);
        this.messageAttenteClient.gameObject.SetActive(attClient);
        if (attServeur || attClient)
        {

            for (int i = 0; i < this.menuPrincipal.Count; i++)
                this.menuPrincipal[i].gameObject.SetActive(false);
            /*this.menuPrincipal[0].gameObject.SetActive(false);
            this.menuPrincipal[1].gameObject.SetActive(false);
            this.menuPrincipal[2].gameObject.SetActive(false);
            this.menuPrincipal[3].gameObject.SetActive(true);*/
        }

        // Si on est un serveur, on attend des connexions :
        if (Network.peerType == NetworkPeerType.Server)
        {
            if (Network.connections.Length > 0)
            {
                // On a un connecté : on lance la partie !
                this.networkView.RPC("launchGame", RPCMode.OthersBuffered);
                this.launchGame();
            }
        }
    }

    public void launchGameClient()
    {
        this.attClient = true;

        // On tente de se connecter en tant que client
        if (Network.Connect(IP, Port) != NetworkConnectionError.NoError)
        {
            // Echec de la connexion !
            Debug.LogError("Echec de la connexion au serveur !!!!!");
            this.quitGame();
        }
    }

    public void launchGameServer()
    {
        bool useNat = !Network.HavePublicAddress();
        if (Network.InitializeServer(2, Port, useNat) == NetworkConnectionError.NoError)
            this.attServeur = true; // Serveur créé !
        else
            Debug.LogError("Echec de la création du serveur !!!");
    }

    [RPC]
    public void launchGame()
    {
        Network.SetLevelPrefix(1);
        Application.LoadLevel("main");
    }

    public void quitGame()
    {
        Network.Disconnect();
        Application.Quit();
    }

    void OnFailedToConnect(NetworkConnectionError error)
    {
        Application.LoadLevel("Menu");
    }

    public void credits()
    {
        Application.LoadLevel("Credits");
    }
}
