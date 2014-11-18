using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{
	public void goBackToMainMenu()
    {
        Application.LoadLevel("Menu");
    }
}
