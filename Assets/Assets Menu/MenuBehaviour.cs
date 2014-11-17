using UnityEngine;
using System.Collections;

public class MenuBehaviour : MonoBehaviour
{
    public string IP = "127.0.0.1";
    public int Port = 25001;
    public Canvas menuPrincipal;
    public Canvas messageAttente;

    void Setup()
    {
        this.menuPrincipal.gameObject.SetActive(true);
        this.messageAttente.gameObject.SetActive(false);
    }

    void Update()
    {
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
        {
            // Serveur créé !
            this.menuPrincipal.gameObject.SetActive(false);
            this.messageAttente.gameObject.SetActive(true);
        }
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
}
