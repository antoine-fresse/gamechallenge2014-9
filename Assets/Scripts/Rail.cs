using UnityEngine;
using System.Collections;

public class Rail : MonoBehaviour {

    public Transform PrefabRail;
    public float Width = 1.21f;
    public int Count = 20;

	void Start () {
	    for (var i = 0; i < Count; i++) {
	        var rail = (Transform) Instantiate(PrefabRail);
	        rail.parent = transform;
	        rail.localPosition = new Vector3(i*Width,0f,0f);
	    }
	}
}
