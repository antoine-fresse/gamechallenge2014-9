using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	//public World w;
    private Transform ToFollow;
    public Transform FireWall;
    private Transform _transform;

    // Use this for initialization
	void Start () {
	    _transform = transform;
		

	    var l = GameObject.Find("Light(Clone)");
	    if (l) 
	        ToFollow = l.transform;
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (!ToFollow) {
            var l = GameObject.Find("Light(Clone)");
            if (l)
                ToFollow = l.transform;
	    }

	    if (!ToFollow) return;

        _transform.position = new Vector3(Mathf.Max(ToFollow.position.x, FireWall.position.x+0.4f), _transform.position.y, _transform.position.z);
        

	}   
}
