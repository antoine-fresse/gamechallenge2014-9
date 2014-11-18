using UnityEngine;
using System.Collections;

public class SpriteOrderer : MonoBehaviour {
    private SpriteRenderer _renderer;
    private Transform _transform;

    // Use this for initialization
	void Start () {
	    _renderer = GetComponent<SpriteRenderer>();
	    _transform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        _renderer.sortingOrder = (int)(_transform.position.z * -100f);
	}
}
