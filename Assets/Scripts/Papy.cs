using UnityEngine;
using System.Collections;

public class Papy : MonoBehaviour {
	
	public bool holdHand;
	public bool filleTouche;
	public bool touchPlayer;
	
	// Use this for initialization
	void Start () {
		holdHand = false;
		filleTouche = false;
		touchPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player"){
			filleTouche = true;
			touchPlayer = true;
		}
	}
	
	void OnTriggerStay(Collider c){
		if (c.gameObject.tag == "Player"){
			if (touchOnRight(c)){
				holdHand = true;
				//touchPlayer = true;
			}
			
		} 
	}
	
	void OnTriggerExit(Collider c){
		if (c.gameObject.tag == "Player"){
			if (touchOnRight(c)){
				holdHand = false;
			}
			touchPlayer = false;
		} 
	}
	
	bool touchOnRight(Collider c) {
		/**Debug.Log (c.gameObject.GetComponent<BoxCollider> ().size.x);
		Debug.Log (GetComponent<BoxCollider>().size.x );**/
		/**Debug.Log (c.gameObject.transform.position.x );
		Debug.Log ("-");
		Debug.Log (c.gameObject.GetComponent<BoxCollider>().size.x/2 );
		Debug.Log ("==");
		Debug.Log (transform.position.x);
		Debug.Log ("+");
		Debug.Log ( GetComponent<BoxCollider>().size.x/2);
		Debug.Log (":");
		Debug.Log (c.gameObject.transform.position.x - c.gameObject.GetComponent<BoxCollider>().size.x/2 );
		Debug.Log ("=");
		Debug.Log (transform.position.x + GetComponent<BoxCollider>().size.x/2);**/
		return (/**c.gameObject.transform.position.x - transform.position.x == c.gameObject.transform.position.x -  transform.position.x  
		        && c.gameObject.transform.position.x > transform.position.x
		        && transform.**/
		        Mathf.Abs (c.gameObject.transform.position.x - c.gameObject.GetComponent<BoxCollider>().size.x/2 - transform.position.x - GetComponent<BoxCollider>().size.x/2) 	<= 0.1
		        /**&& c.gameObject.transform.position.y - c.gameObject.GetComponent<BoxCollider>().size.y/2 >= transform.position.y + GetComponent<BoxCollider>().size.y/2
		        && c.gameObject.transform.position.z - c.gameObject.GetComponent<BoxCollider>().size.z/2 >= transform.position.z + GetComponent<BoxCollider>().size.z/2**/);
	}
	
	
}
