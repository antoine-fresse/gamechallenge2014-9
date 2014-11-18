using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {


    public float ScaleMin = 0.7f;
    public float ScaleMax = 0.8f;

    public float AlphaMin = 0.62f;
    public float AlphaMax = 0.82f;

    public float Interval = 1.0f;
    public bool Instant = false;

    public bool AnimateScale = true;

    private SpriteRenderer _rend;
	// Use this for initialization
	void Start () {
	    _rend = GetComponent<SpriteRenderer>();
	    StartCoroutine(Flicker());

	}

    IEnumerator Flicker() {
        while (true) {
            if (AnimateScale) {
                var scale = Random.Range(ScaleMin, ScaleMax);
                LeanTween.scale(this.gameObject, new Vector3(scale, scale, scale), !Instant ? Interval : 0.01f);
            }

            var alpha = Random.Range(AlphaMin, AlphaMax);
            LeanTween.value(gameObject, 
                (float f) => {
                    var c = _rend.color;
                    c.a = f;
                    _rend.color = c;
                }, _rend.color.a, alpha, !Instant ? Interval : 0.01f);
            yield return new WaitForSeconds(Interval);
        }
    }
}
