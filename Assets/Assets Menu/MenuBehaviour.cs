using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuBehaviour : MonoBehaviour
{
    public string IP;
    public int Port = 25001;
    public List<GameObject> menuPrincipal;
    public GameObject messageAttenteServeur;
    public GameObject messageAttenteClient;

    public Image EcranTitre;

    public Image EcranJoin;
    public Image EcranHost;

    // Deux variables dégeulasses néccessaires :
    private bool attServeur = false;
    private bool attClient = false;


    void Start() {
        StartCoroutine(Menus());
    }


    void Setup()
    {
        for (int i = 0; i < this.menuPrincipal.Count; i++)
            this.menuPrincipal[i].gameObject.SetActive(true);
        this.messageAttenteServeur.gameObject.SetActive(false);
        this.messageAttenteClient.gameObject.SetActive(false);
    }

    void Update()
    {
        this.messageAttenteServeur.gameObject.SetActive(attServeur);
        this.messageAttenteClient.gameObject.SetActive(attClient);
        if (attServeur || attClient)
            for (int i = 0; i < this.menuPrincipal.Count; i++)
                this.menuPrincipal[i].gameObject.SetActive(false);

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

        EcranJoin.gameObject.SetActive(true);

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
        EcranHost.gameObject.SetActive(true);
        bool useNat = !Network.HavePublicAddress();
        if (Network.InitializeServer(2, Port, useNat) == NetworkConnectionError.NoError)
            this.attServeur = true; // Serveur créé !
        else
            Debug.LogError("Echec de la création du serveur !!!");
    }

    [RPC]
    public void launchGame()
    {
        //Network.SetLevelPrefix(1);
        Application.LoadLevel(1);
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






    IEnumerator Menus() {
        yield return new WaitForSeconds(3f);
        EcranTitre.enabled = false;
    }




}
