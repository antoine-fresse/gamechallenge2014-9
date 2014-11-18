using UnityEngine;
using System.Collections;

public class LightGenerator : MonoBehaviour {


    public Color LightColor = Color.white;
    

	// Use this for initialization
	void Start () {
        Destroy(this);
	    var lightMask = (GameObject)Instantiate(this.gameObject);
        
	    lightMask.transform.parent = transform;
	    lightMask.transform.localPosition = Vector3.zero;
        lightMask.layer = LayerMask.NameToLayer("LightMask");
	    var rend = lightMask.GetComponent<SpriteRenderer>();

	    if (rend) {
	        rend.material.shader = Shader.Find("GUI/Text Shader");
	        rend.material.color = LightColor;
	    }
	    else {
	        var meshRend = lightMask.GetComponent<MeshRenderer>();
	        if (!meshRend) return;
	        meshRend.material.shader = Shader.Find("GUI/Text Shader");
	        rend.material.color = LightColor;
	    }
	}
	
}
