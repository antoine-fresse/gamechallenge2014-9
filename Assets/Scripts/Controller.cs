using UnityEngine;
using System.Collections;



public class Controller : MonoBehaviour {

	public World w;
	private GameObject Papy;
	private GameObject lumiere;
	private GameObject Fille;
	private GameObject Extincteur;
	public int borneX;
	public int borneY;
	public int borneZ;
	public int borneGX;
	public int borneGY;
	public int borneGZ;
	
	public float xInit;
	public float yInit;
	public float zInit;
	private Rect Gauche;
	private Rect Droite;
	private Rect Bas;
	private Rect Haut;

	public int x;
	public int y;
	public int z;
	public float ix;
	public float iy;
	public float iz;

	public float gx;
	public float gy;
	public float gz;

	public float anglex;
	public float angley;
	public float anglez;

	public float _x = 0.0f;
	public float _y = 0.0f;
	public float _z = 0.0f;

	private float last_y;

	// Use this for initialization
	void Start () {
		xInit = (int)(Input.acceleration.x*100);
		yInit = (int)(Input.acceleration.y*100);
		zInit = (int)(Input.acceleration.z*100);
		last_y = yInit;
		Gauche = new Rect(0, 0 , Screen.width / 3, Screen.height);
		Droite = new Rect(Screen.width - Screen.width / 3, 0 , Screen.width / 3, Screen.height);
		Bas = new Rect(Screen.width / 3, 0, Screen.width - (Screen.width/3)*2, Screen.height/3);
		if (w.testLocal) {
			//Instanciations
			Papy = w.papy;
			lumiere = w.l;
			Fille = w.fille;
			Extincteur = w.extincteur;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//récupération des données
		x = (int)(Input.acceleration.x*100 - xInit);
		y = (int)(Input.acceleration.y*100 - yInit);
		z = (int)(Input.acceleration.z*100 - zInit); 
		ix = Input.acceleration.x;
		iy = Input.acceleration.y;
		iz = Input.acceleration.z;

		if (Mathf.Abs(x) >= borneX) {_x = Input.acceleration.x/10;}
		if (Mathf.Abs(y) >= borneY) {_y = Input.acceleration.y/30;}
		//if (Mathf.Abs(y) >= borneY) {_y = (y-last_y)/10;last_y = y;}
		if (Mathf.Abs(z) >= borneZ) {_z = Input.acceleration.z;}


		if (!w.isPapy) {

			Fille = w.fille;
			Extincteur = w.extincteur;

			//Fille
			Fille.transform.Translate (_x, 0, _y);

			/** Touches **/
			if (Input.touchCount > 0) {
				if (Gauche.Contains (Input.GetTouch (0).position)) {
						Extincteur.transform.Translate (-0.01f, 0, 0);
				}
				if (Droite.Contains (Input.GetTouch (0).position)) {
						Extincteur.transform.Translate (0.01f, 0, 0);
				}
				if (Bas.Contains (Input.GetTouch (0).position)) {
					Extincteur.GetComponent<UseIt>().shoot();
				}
			}
			
		}

		//Papy
		else {
			//Instanciations
			Papy = w.papy;
			lumiere = w.l;
			
			// **** Recup données *****
			if (Mathf.Abs(x) >= borneX) {_x = Input.acceleration.x/10;}
			if (Mathf.Abs(y) >= borneY) {_y = -Input.acceleration.y/2;}
			if (Mathf.Abs(z) >= borneZ) {_z = Input.acceleration.z;}
			Input.gyro.enabled = true;
			gx = Input.gyro.rotationRateUnbiased.x/***10**/;
			gy = Input.gyro.rotationRateUnbiased.y/***10**/;
			gz = Input.gyro.rotationRateUnbiased.z/10;
			float vx = 0.0f;
			float vy = 0.0f;
			float vz = 0.0f;
			if (Mathf.Abs(gz) >= borneGY){vz = 1.0f;}
			Vector3 v =  new Vector3(0.0f,0.0f,vz*gz*10);

			lumiere.transform.rotation =  Quaternion.Euler(0.0f,0.0f,v.z);
			lumiere.transform.position = new Vector3(lumiere.transform.position.x+(_x),lumiere.transform.position.y,lumiere.transform.position.z);

			/** Touches **/
			if (Input.touchCount > 0) {
				for (int i = 0; i < Input.touchCount; i++){
					if (Droite.Contains (Input.GetTouch (i).position)) {Papy.GetComponent<Papy>().holdHand = true;}
					else {Papy.GetComponent<Papy>().holdHand = false;}
					if (Bas.Contains (Input.GetTouch (i).position)) {/**TODO **//**Debug.Log("EN BAS");**/}
				}
			}
			else {Papy.GetComponent<Papy>().holdHand = false;}

		    Papy.GetComponent<Papy>().holdHand = Input.GetMouseButton(0);
		    /** TODO Papy.GetComponent<Animator>().SetBool("holdHand",Papy.GetComponent<Papy>().holdHand);**/

		}
		}

}

