using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public World w;
    private Transform ToFollow;
    public Transform FireWall;
    private Transform _transform;
    // Use this for initialization
	void Start () {
	    _transform = transform;
		//ToFollow = w.l.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Network.peerType == NetworkPeerType.Server)
        {
            ToFollow = w.l.transform;
            _transform.position = new Vector3(Mathf.Max(ToFollow.position.x, FireWall.position.x + .8f), _transform.position.y, _transform.position.z);
        }
	}   
}
