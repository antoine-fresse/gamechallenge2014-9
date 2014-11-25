using UnityEngine;


[AddComponentMenu("Image Effects/Color Adjustments/Grayscale")]
public class GrayscaleEffect : ImageEffectBase {
	public Texture  textureRamp;
	public float    rampOffset;

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		
		if (true) {
			material.SetTexture ("_RampTex", textureRamp);
			material.SetFloat ("_RampOffset", rampOffset);
			Graphics.Blit (source, destination, material);
		}
	}
}