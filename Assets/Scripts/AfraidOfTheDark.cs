using UnityEngine;
using System.Collections;

public class AfraidOfTheDark : MonoBehaviour {


    public RenderTexture LightMap;
    public Transform Fille;
    public Camera GameCamera;

    public bool CanMove { get; private set; }

    // Use this for initialization
	void Start () {
	    CanMove = true;
	}
	
	// Update is called once per frame
	void Render () {
	    var screenPosition = GameCamera.WorldToScreenPoint(Fille.position);
        var tex = new Texture2D(LightMap.width, LightMap.height);
	    RenderTexture.active = LightMap;
        tex.ReadPixels(new Rect(0,0, LightMap.width, LightMap.height), 0,0);
        tex.Apply();
	    var lightIntensity = tex.GetPixel((int) screenPosition.x, (int) screenPosition.y).r;
        CanMove = (lightIntensity > 0.1f);
	}


}
