using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform ToFollow;
    public Transform FireWall;
    private Transform _transform;
    // Use this for initialization
	void Start () {
	    _transform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        _transform.position = new Vector3(Mathf.Max(ToFollow.position.x, FireWall.position.x+.8f), _transform.position.y, _transform.position.z);
	}
}
