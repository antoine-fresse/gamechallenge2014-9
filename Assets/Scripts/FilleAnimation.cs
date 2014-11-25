using UnityEngine;
using System.Collections;

public class FilleAnimation : MonoBehaviour {

    private Papy _papy;
    private Animator _animator;

    private bool _holdHands;
    private bool _filleTouch;
    public bool Attached;

    private Vector3 _lastPosition;

	private PhotonView _photonView;

	private Vector3 _latestCorrectPos;
	private Vector3 _onUpdatePos;
	private float _fraction;

	// Use this for initialization
	void Start () {
		_photonView = GetComponent<PhotonView>();
	    _animator = GetComponent<Animator>();
		var papy = World.instance.papy;
	    if (papy)
	        _papy = papy.GetComponent<Papy>();
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
		if (!World.instance.Ready)
			return;

		if (!_papy) {
			if (World.instance.papy)
				_papy = World.instance.papy.GetComponent<Papy>();
		}
		if (!_papy)
			return;

		if ((_holdHands != _papy.holdHand) || (_filleTouch != _papy.filleTouche)) {
            
	        if (_papy.holdHand && _papy.filleTouche) {
				_photonView.RPC("HoldHands", PhotonTargets.AllBuffered);
	            _papy.callHide();
	            Attached = true;
	        }
            else if ((_holdHands != _papy.holdHand) && !_papy.holdHand && Attached) {
                Attached = false;
				_photonView.RPC("LetGo", PhotonTargets.AllBuffered);
                _papy.callShow(transform);
	        }
            _holdHands = _papy.holdHand;
	        _filleTouch = _papy.filleTouche;
	    }

		if (!_photonView.isMine) {
			_fraction = _fraction + Time.deltaTime*9;
			transform.localPosition = Vector3.Lerp(_onUpdatePos, _latestCorrectPos, _fraction); // set our pos between A and B
		}
	}

	public void SetAfraid(bool b) {
		_photonView.RPC("ChangeAfraid", PhotonTargets.AllBuffered, b);
	}


    public void SetWalking(bool b) {
		_photonView.RPC("ChangeWalking", PhotonTargets.AllBuffered, b);
    }

    [RPC]
    void HoldHands() {
        _animator.SetTrigger("holdHands");
    }

    [RPC]
    void LetGo() {
        _animator.SetTrigger("letGo");
    }

    [RPC]
    void ChangeWalking(bool b) {
        _animator.SetBool("walking", b);
    }

	[RPC]
	void ChangeAfraid(bool b) {
		_animator.SetBool("afraid", b);
	}


}
