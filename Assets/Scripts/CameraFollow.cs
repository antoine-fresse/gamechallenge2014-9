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
<<<<<<< HEAD
		ToFollow = GameObject.FindGameObjectWithTag ("MainCamera").transform;
=======
	    var l = GameObject.Find("Light(Clone)");
	    if (l) 
	        ToFollow = l.transform;
	    
>>>>>>> 1295691f31ffc51c61d2b0c763ec66e86d8b6dcf
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
            _transform.position = new Vector3(Mathf.Max(ToFollow.position.x, FireWall.position.x + .8f), _transform.position.y, _transform.position.z);   
=======
	    if (!ToFollow) {
            var l = GameObject.Find("Light(Clone)");
            if (l)
                ToFollow = l.transform;
	    }

	    if (!ToFollow) return;

        _transform.position = new Vector3(Mathf.Max(ToFollow.position.x, FireWall.position.x+0.4f), _transform.position.y, _transform.position.z);
        
>>>>>>> 1295691f31ffc51c61d2b0c763ec66e86d8b6dcf
	}   
}
