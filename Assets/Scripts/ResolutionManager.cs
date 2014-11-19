using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResolutionManager : MonoBehaviour {

    public Canvas canvas;

    void Start() {
        Screen.SetResolution(256,240,false);
    }
	// Update is called once per frame
	void FixedUpdate () {
        var size = canvas.pixelRect;

        var rect = GetComponent<RectTransform>();

        var height = size.height;
        var width = Mathf.Ceil(height * 1.0666f);

        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);

	}
}
