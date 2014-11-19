using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{
	public void goBackToMainMenu()
    {
        Network.Disconnect();
        Application.LoadLevel("Menu");
    }
}
