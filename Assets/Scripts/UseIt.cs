using UnityEngine;
using System.Collections;

public class UseIt : MonoBehaviour {
	public GameObject water;
	public float fireRate;
	private float nextFire;
	private PhotonView _photonView ;


	void Awake() {
		_photonView = GetComponent<PhotonView>();
	}

    public void shoot() {
		_photonView.RPC("shootRPC", PhotonTargets.AllBuffered, transform.position);
    }
	// Update is called once per frame
	[RPC]
    void shootRPC (Vector3 pos) {
		if (Time.time > nextFire)
		{
				nextFire = Time.time + fireRate;
				Instantiate(water, pos + new Vector3(0, 0.2f, 0), water.transform.rotation);
		}
	}
}
