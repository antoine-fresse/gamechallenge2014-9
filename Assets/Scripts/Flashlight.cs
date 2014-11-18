using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

    private float _velocityX;
    private float _velocityY;
    private float _velocityZ;

	// Update is called once per frame
	void Update () {
	    _velocityX += (Input.acceleration.x * 300f - _velocityX * 0.95f)*Time.deltaTime;
        _velocityY += (Input.acceleration.y * 300f - _velocityY * 0.95f) * Time.deltaTime;
        _velocityZ += (Input.acceleration.z * 30f - _velocityZ * 0.95f) * Time.deltaTime;


	    transform.localEulerAngles = transform.localEulerAngles + new Vector3(0f,0f, _velocityX*Time.deltaTime);
        var x = Mathf.Clamp(transform.position.x + _velocityZ * Time.deltaTime, -2.5f, 2.5f);
	    transform.position = new Vector3(x, transform.position.y, 0.0f);
	}

    
}
