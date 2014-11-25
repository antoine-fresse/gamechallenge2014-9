using UnityEngine;
using System.Collections;

public class LerpMovement : MonoBehaviour {

	private Vector3 _latestCorrectPos;
	private Vector3 _onUpdatePos;
	private float _fraction;
	private PhotonView _photonView;

	// Use this for initialization
	void Start () {
		_photonView = GetComponent<PhotonView>();
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			var pos = transform.localPosition;
			stream.Serialize(ref pos);
		} else {
			// Receive latest state information
			var pos = Vector3.zero;

			stream.Serialize(ref pos);

			_latestCorrectPos = pos;                 // save this to move towards it in FixedUpdate()
			_onUpdatePos = transform.localPosition;  // we interpolate from here to latestCorrectPos
			_fraction = 0;                           // reset the fraction we alreay moved. see Update()
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!_photonView.isMine) {
			_fraction = _fraction + Time.deltaTime * 9;
			transform.localPosition = Vector3.Lerp(_onUpdatePos, _latestCorrectPos, _fraction); // set our pos between A and B
		}
	}
}
