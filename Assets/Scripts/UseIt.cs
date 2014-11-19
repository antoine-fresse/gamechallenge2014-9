using UnityEngine;
using System.Collections;

public class UseIt : MonoBehaviour {
	public GameObject water;
	public float fireRate;
	private float nextFire;

    void Update() {
        if (Input.GetKeyUp(KeyCode.Space))
            shoot();
    }


    public void shoot() {
        networkView.RPC("shootRPC", RPCMode.All);
    }
	// Update is called once per frame
	[RPC]
    void shootRPC () {
		if (Time.time > nextFire)
		{
				nextFire = Time.time + fireRate;
				Instantiate(water, this.transform.position, water.transform.rotation);
		}
	}
}
