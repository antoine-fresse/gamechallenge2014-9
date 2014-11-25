using UnityEngine;
using System.Collections;

public class BigFire : MonoBehaviour {

	public Transform SmallFire;
	private bool _quitting = false;
	void OnApplicationQuit() {
		_quitting = true;
	}
	void OnDestroy() {
		if(!_quitting)
			Instantiate(SmallFire, transform.position, Quaternion.identity);
	}
}
