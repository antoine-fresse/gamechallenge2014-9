using UnityEngine;
using System.Collections;



public class Controller : MonoBehaviour {

	public GameObject World;
	public GameObject Papy;
	public GameObject Light;
	public GameObject Fille;
	public GameObject Extincteur;
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
	
	// Use this for initialization
	void Start () {
		xInit = (int)(Input.acceleration.x*100);
		yInit = (int)(Input.acceleration.y*100);
		zInit = (int)(Input.acceleration.z*100);
		Gauche = new Rect(0, 0 , Screen.width / 3, Screen.height);
		Droite = new Rect(Screen.width - Screen.width / 3, 0 , Screen.width / 3, Screen.height);
		Bas = new Rect(Screen.width / 3, 0, Screen.width - (Screen.width/3)*2, Screen.height/3);


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

	

		if (Mathf.Abs(x) >= borneX) {_x = Input.acceleration.x;}
		if (Mathf.Abs(y) >= borneY) {_y = -Input.acceleration.y/2;}
		if (Mathf.Abs(z) >= borneZ) {_z = Input.acceleration.z;}

		if (!World.gameObject.GetComponent<World> ().isPapy) {
			//Fille
			Fille.transform.Translate (_x, 0, -_y);

			//Debug.Log (Papy.gameObject.GetComponent<Papy> ().touchPlayer);
			if (Papy.gameObject.GetComponent<Papy> ().holdHand && Papy.gameObject.GetComponent<Papy> ().filleTouche) {
					Papy.transform.Translate (_x, 0, -_y);
			}

			/** Touches **/
			if (Input.touchCount > 0) {
					if (Gauche.Contains (Input.GetTouch (0).position)) {
							Extincteur.transform.Translate (-0.05f, 0, 0);
					}
					if (Droite.Contains (Input.GetTouch (0).position)) {
							Extincteur.transform.Translate (0.05f, 0, 0);
					}
					if (Bas.Contains (Input.GetTouch (0).position)) {
							Extincteur.transform.Translate (0, -0.05f, 0);
					}
			}
		}

		//Papy
		else {
			if (Mathf.Abs(x) >= borneX) {_x = Input.acceleration.x/10;}
			if (Mathf.Abs(y) >= borneY) {_y = -Input.acceleration.y/2;}
			if (Mathf.Abs(z) >= borneZ) {_z = Input.acceleration.z;}

			Input.gyro.enabled = true;
			//Debug.Log(Input.gyro.enabled);
			gx = Input.gyro.rotationRateUnbiased.x/***10**/;
			gy = Input.gyro.rotationRateUnbiased.y/***10**/;
			gz = Input.gyro.rotationRateUnbiased.z/10;

			float vx = 0.0f;
			float vy = 0.0f;
			float vz = 0.0f;
			Quaternion q = Input.gyro.attitude;
			//transform.rotation = transform.rotation - transform.rotation;

			if (Mathf.Abs(gz) >= borneGY){vz = 1.0f;}
			Vector3 v =  new Vector3(0.0f,0.0f,vz*gz*10);
			//Light.transform.localRotation =  Quaternion.Euler(0.0f,0.0f,v.z);;
			//float angle = Light.transform.rotation.eulerAngles.z;
			/**anglex = q.eulerAngles.x;
			angley = q.eulerAngles.y;
			anglez = q.eulerAngles.z;
			Light.transform.rotation = Quaternion.Euler(0.0f,0.0f,anglez);**/


			Light.transform.rotation =  Quaternion.Euler(0.0f,0.0f,v.z);
			Light.transform.position = new Vector3(Light.transform.position.x+(_x),Light.transform.position.y,Light.transform.position.z);
			/**float lastgz = gz;
			Vector3 v =  new Vector3(0.0f,0.0f,vz*gz);
			gz = Input.gyro.rotationRateUnbiased.z*10;
			int i=0;
			while (lastgz*gz >0 && i != 100){
				lastgz = gz;
				v =  new Vector3(0.0f,0.0f,vz*gz);
				gz = Input.gyro.rotationRateUnbiased.z*10;
				if (Mathf.Abs(gz) >= borneGY){Light.transform.Rotate (v);}
				i++;
			}**/


			/** Touches **/
			if (Input.touchCount > 0) {
				if (Bas.Contains (Input.GetTouch (0).position)) {
					//Papy.transform.Translate (0, 0, -0.05f);
				}
			}
		}
	}
	
	
}



