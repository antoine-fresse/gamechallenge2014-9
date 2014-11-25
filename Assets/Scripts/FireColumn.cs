using UnityEngine;
using System.Collections;

public class FireColumn : MonoBehaviour {

    public float Speed;
	private PhotonView _photonView;

	void Start() {
		_photonView = GetComponent<PhotonView>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(PhotonNetwork.isMasterClient)
			transform.Translate(new Vector3(Speed*Time.deltaTime/128f,0f,0f));
	}

	void OnTriggerStay(Collider other) {
        if (other.tag == "Player" || other.tag == "Papy")
        {
            World.instance.declareDefeat();
        }
    }
}
