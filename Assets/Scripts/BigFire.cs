using UnityEngine;
using System.Collections;

public class BigFire : MonoBehaviour {

	public Transform smallFire;

	void OnDestroy() {
		Instantiate(smallFire, transform.position, Quaternion.identity);
	}
}
