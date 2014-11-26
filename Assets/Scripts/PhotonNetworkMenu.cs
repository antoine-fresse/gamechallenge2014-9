using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhotonNetworkMenu : MonoBehaviour {

	public GameObject EcranTitre;
	public GameObject EcranMenu;
	public GameObject EcranHost;
	public GameObject EcranJoin;

	public Text roomNameText;
	private string _roomName = "room name";

	private TouchScreenKeyboard _keyboard;

	private bool _ready = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(Menus());
		PhotonNetwork.logLevel = PhotonLogLevel.ErrorsOnly;
		PhotonNetwork.Disconnect();
		PhotonNetwork.ConnectUsingSettings("v1.0");
		PhotonNetwork.automaticallySyncScene = true;

	}

	
	// Update is called once per frame
	void Update () {


		if (_keyboard != null)
			if(_keyboard.active)
				_roomName = _keyboard.text;

	    if (PhotonNetwork.connecting)
	        roomNameText.text = "Connecting...";
        else if(!PhotonNetwork.connected)
            PhotonNetwork.ConnectUsingSettings("v1.0");
        else
            roomNameText.text = _roomName;

		if (!_ready)
			return;

		var room = PhotonNetwork.room;
		if (room != null) {
			if (room.playerCount == 2 && PhotonNetwork.isMasterClient) {
				PhotonNetwork.LoadLevel(1);
			}
		}

	}


	IEnumerator Menus() {
		yield return new WaitForSeconds(3f);
		EcranTitre.SetActive(false);
		EcranMenu.SetActive(true);
	}

	public void HideTitleScreen() {
		EcranTitre.SetActive(false);
		EcranMenu.SetActive(true);
	}

	public void EditRoomName() {
		_keyboard = TouchScreenKeyboard.Open(_roomName, TouchScreenKeyboardType.Default, false, false);
	}

	public void JoinRoom() {
		if (!_ready)
			return;
		var rooms = PhotonNetwork.GetRoomList();

		foreach (var room in rooms) {
			if (room.name == _roomName && room.open) {
				EcranJoin.SetActive(true);
				EcranMenu.SetActive(false);
				PhotonNetwork.JoinRoom(room.name);
				return;
			}
		}
	
		var options = new RoomOptions {maxPlayers = 2, isOpen = true, isVisible = true};
		PhotonNetwork.CreateRoom(_roomName, options, TypedLobby.Default);

	}

	void OnJoinedRoom() {
		if (PhotonNetwork.room.playerCount < 2) {
			EcranHost.SetActive(true);
			EcranMenu.SetActive(false);
		}
	}

	void OnPhotonJoinRoomFailed() {
		EcranJoin.SetActive(false);
		EcranMenu.SetActive(true);
	}

	void OnJoinedLobby() {
		roomNameText.color = Color.green;
		_ready = true;
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void Credits() {
		Application.LoadLevel("Credits");
	}

	public void HowToPlay() {
		Application.LoadLevel("HTP");
	}
}
