using UnityEngine;
using System.Collections;



public class Controller : MonoBehaviour {

	public World w;
	public GameObject soundManager;
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
	private soundManager sManager;
	
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

	//private float last_y;

	// Use this for initialization
	void Start () {
		xInit = (int)(Input.acceleration.x*100);
		yInit = (int)(Input.acceleration.y*100);
		zInit = (int)(Input.acceleration.z*100);
		//last_y = yInit;
		Gauche = new Rect(0, 0 , Screen.width / 3, Screen.height);
		Droite = new Rect(Screen.width - Screen.width / 3, 0 , Screen.width / 3, Screen.height);
		Bas = new Rect(Screen.width / 3, 0, Screen.width - (Screen.width/3)*2, Screen.height/3);
		soundManager.GetComponent<soundManager> ();
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
		if (!World.instance.Ready)
			return;

		

		//récupération des données
		x = (int)(Input.acceleration.x*100 - xInit);
		y = (int)(Input.acceleration.y*100 - yInit);
		z = (int)(Input.acceleration.z*100 - zInit); 
		ix = Input.acceleration.x + Input.GetAxis("Horizontal");
		iy = Input.acceleration.y + Input.GetAxis("Vertical");
		iz = Input.acceleration.z;

		_x = 0.0f;
		_y = 0.0f;
		_z = 0.0f;
		if (Mathf.Abs(x) >= borneX) {_x = Input.acceleration.x;}
		if (Mathf.Abs(y) >= borneY) {_y = Input.acceleration.y;}
		if (Mathf.Abs(z) >= borneZ) {_z = Input.acceleration.z;}


		if (!w.isPapy) {

			Fille = w.fille;
			Extincteur = w.extincteur;

			//Fille
			if (AfraidOfTheDark.instance.CanMove){
				if (Mathf.Abs(ix) > 0 || Mathf.Abs(iy) > 0 ){
                    Fille.GetComponent<FilleAnimation>().SetWalking(true);
					//Fille.transform.Translate (_x/30, 0, _y/30);
					Fille.rigidbody.velocity = Fille.rigidbody.velocity + new Vector3(ix, 0f, iy)*Time.deltaTime*3f;
				} else { Fille.GetComponent<FilleAnimation>().SetWalking(false); }
			}
			else{
                Fille.GetComponent<FilleAnimation>().SetWalking(false);
			}
			/** Touches **/
			var dir = new Vector3(Input.GetAxis("HorizontalRight"),0,0);
			if (Input.touchCount > 0) {
				if (Gauche.Contains (Input.GetTouch (0).position)) {
					dir.x = dir.x - 1f;
				}
				if (Droite.Contains (Input.GetTouch (0).position)) {
					dir.x = dir.x + 1f;
				}
				if (Bas.Contains (Input.GetTouch (0).position)) {
					Extincteur.GetComponent<UseIt>().shoot();
				}
				
			}
			Extincteur.transform.Translate(dir * Time.deltaTime);
			if(Input.GetButton("Fire1"))
				Extincteur.GetComponent<UseIt>().shoot();

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
			
			lumiere.transform.position = new Vector3(lumiere.transform.position.x+(ix)*Time.deltaTime,lumiere.transform.position.y,lumiere.transform.position.z);

			/** Touches **/
			if (Input.touchCount > 0) {
				for (int i = 0; i < Input.touchCount; i++) {
					if (Droite.Contains(Input.GetTouch(i).position)) {
						Papy.GetComponent<Papy>().holdHand = AfraidOfTheDark.instance.CanMove;
					}
					else {
						Papy.GetComponent<Papy>().holdHand = false;
					}
					if (Bas.Contains(Input.GetTouch(i).position)) {
						
					}
				}
			}
			else {
				Papy.GetComponent<Papy>().holdHand = Input.GetButton("Fire1") && AfraidOfTheDark.instance.CanMove;
			}

			}
            //Papy.GetComponent<Papy>().holdHand = !Input.GetKey(KeyCode.A);
		}

}

