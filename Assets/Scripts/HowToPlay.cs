using UnityEngine;
using System.Collections;

public class HowToPlay : MonoBehaviour {
	public GameObject eau;
	public GameObject lenka;
	public GameObject papy;
	public GameObject lumiere;

	public void afficherLenka(){
		eau.SetActive (false);
		lenka.SetActive(true);
	}

	public void afficherPapy(){
		lenka.SetActive (false);
		papy.SetActive(true);
	}

	public void afficherLumiere(){
		papy.SetActive (false);
		lumiere.SetActive(true);
	}

	public void afficherEau()
	{
		lenka.SetActive (false);
		eau.SetActive(true);
	}

	public void retourMenu(){
		Application.LoadLevel ("Menu");
	}
}
