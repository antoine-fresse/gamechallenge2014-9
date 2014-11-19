using UnityEngine;
using System.Collections;

public class TestMovement : MonoBehaviour {

    public Transform LightT;
    public float Speed = 10f;
    private Transform _transform;
    private SpriteRenderer _renderer;
    private Animator _animator;
	// Use this for initialization
	void Start () {
	    _transform = transform;
	    _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
	}

    void Update() {
        //Camera.transform.position = new Vector3(_transform.position.x, 0f, -10f);

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.Log(Input.GetAxis("Horizontal"));
        if(networkView.isMine)
            _transform.position = new Vector3(_transform.position.x + Input.GetAxis("Horizontal") * Speed * Time.deltaTime / 128f, _transform.position.y, _transform.position.z + Input.GetAxis("Vertical") * Speed * Time.deltaTime * 1.6f / 128f);
        //LightT.position = new Vector3(LightT.position.x + Input.GetAxis("Mouse X") * Speed * 10f * Time.deltaTime / 128f, LightT.position.y, LightT.position.z);		  
	}
}
