using UnityEngine;
using System.Collections;

public class AfraidOfTheDark : MonoBehaviour {

    public static AfraidOfTheDark instance;
    public RenderTexture LightMap;
    private GameObject Fille;
    private GameObject LightRail;
    public Camera GameCamera;

    public bool CanMove { get; private set; }

    // Use this for initialization
	void Start () {
	    CanMove = true;
	    instance = this;
	}

	
	// Update is called once per frame
	void Update() {
	    if (!Fille || !LightRail) {
	        Fille = GameObject.Find("Fille(Clone)");
	        LightRail = GameObject.Find("Light(Clone)");
	    }
	    if (!Fille || !LightRail) return;

        
	    var screenPositionLenka = GameCamera.WorldToScreenPoint(Fille.transform.position + new Vector3(0f,0.33f,0f));
	    var screenPositionLight = GameCamera.WorldToScreenPoint(LightRail.transform.position);

        var p1 = new Vector2(screenPositionLenka.x, screenPositionLenka.y);
        var p2 = new Vector2(screenPositionLight.x, screenPositionLight.y);

	    var v1 = p1 - p2;

	    var ang = Vector2.Angle(v1, new Vector2(0f,-1f));

        

	    CanMove = ang < 25f;

        

	    /*
	    if (screenPosition.x > 256f || screenPosition.x < 0f || screenPosition.y < 0f || screenPosition.y > 240f) {
	        CanMove = false;
	        return;
	    }

        var tex = new Texture2D(LightMap.width, LightMap.height);
	    RenderTexture.active = LightMap;
        tex.ReadPixels(new Rect(0,0, LightMap.width, LightMap.height), 0,0);
        tex.Apply();
	    var lightIntensity = tex.GetPixel((int) screenPosition.x, (int) screenPosition.y).r;
        CanMove = (lightIntensity > 0.1f);
        */


	}


}
