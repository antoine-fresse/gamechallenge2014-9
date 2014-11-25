using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
    public float Duration = 12f;
    void Start() {
        StartCoroutine(goBackToMainMenu());
    }
	public IEnumerator goBackToMainMenu() {
	    yield return new WaitForSeconds(Duration);
        Application.LoadLevel("Menu");
    }
}
