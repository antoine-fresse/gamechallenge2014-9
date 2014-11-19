using UnityEngine;
using System.Collections;

public class AfraidOfTheDark : MonoBehaviour {

    public static AfraidOfTheDark instance;
    public RenderTexture LightMap;
    private GameObject Fille;
    public Camera GameCamera;

    public bool CanMove { get; private set; }

    // Use this for initialization
	void Start () {
	    CanMove = true;
	    instance = this;
	}

    void Update() {
        Fille = GameObject.Find("Fille(Clone)");
    }
	
	// Update is called once per frame
	void OnPostRender () {
	    if (!Fille) return;

        
	    var screenPosition = GameCamera.WorldToScreenPoint(Fille.transform.position + new Vector3(0f,0.33f,0f));
        

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

        
        
	}


}
