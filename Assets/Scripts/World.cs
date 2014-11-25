using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	public static World instance;
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

	public bool Ready;

	public bool gagne = false;
	public bool perdu = false;

	private bool _timingOut = false;

	private PhotonView _photonView;
	// Use this for initialization
	void Awake () {
		instance = this;
		_photonView = GetComponent<PhotonView>();

		PhotonNetwork.offlineMode = testLocal;
	}

	void Update() {
		if (!l)
			l = GameObject.Find("Light(Clone)");
		if (!fille)
			fille = GameObject.Find("Fille(Clone)");
		if (!papy)
			papy = GameObject.Find("Papy(Clone)");
		if (!extincteur)
			extincteur = GameObject.Find("Extincteur(Clone)");

		Ready = fille && l && extincteur && papy;

	}

	void Start() {
		if (PhotonNetwork.isMasterClient) {
			this.isPapy = false;
			fille = PhotonNetwork.Instantiate("Fille", StartPosition.position + new Vector3(0.25f, 0f, 0f), Quaternion.identity,0) as GameObject;
			var extPos = new Vector3(StartPosition.position.x, StartPosition.position.y, -0.75f);
			extincteur = PhotonNetwork.Instantiate("Extincteur", extPos, Quaternion.identity, 0) as GameObject;
		} else {
			this.isPapy = true;
			papy = PhotonNetwork.Instantiate("Papy", StartPosition.position, Quaternion.identity, 0) as GameObject;
			l = PhotonNetwork.Instantiate("Light", this.prefabLumiere.transform.position, this.prefabLumiere.transform.rotation, 0) as GameObject;
		}


		if (PhotonNetwork.inRoom) {
			if (PhotonNetwork.room.playerCount < 2 && !_timingOut)
				StartCoroutine(TimeOut());
		}
	}

	IEnumerator TimeOut() {
		_timingOut = true;
		yield return new WaitForSeconds(3f);

		if (PhotonNetwork.room.playerCount < 2) {
			PhotonNetwork.Disconnect();
		}
		_timingOut = false;
	}

	void OnDisconnectedFromPhoton()
    {
		if(gagne)
			Application.LoadLevel("Victoire");
		else if (perdu)
			Application.LoadLevel("Defaite");
		else 
			Application.LoadLevel("Menu");
    }

	void OnLeftRoom() {
		
	}

    public void declareDefeat()
    {
		_photonView.RPC("defeat", PhotonTargets.AllBuffered);
    }

    [RPC]
    private void defeat() {
	    perdu = true;
		PhotonNetwork.Disconnect();
    }

    public void declareVictory()
    {
		_photonView.RPC("victory", PhotonTargets.AllBuffered);
    }

    [RPC]
    private void victory() {
	    gagne = true;
		PhotonNetwork.Disconnect();
    }
}