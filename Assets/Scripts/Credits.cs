using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour {


    public Sprite[] A;
    public Image im;
    void Start() {
        StartCoroutine(CreditRoll());
    }

    IEnumerator CreditRoll() {
        int x = 0;
        while (true) {
            yield return new WaitForSeconds(5f);
            im.sprite = A[x%A.Length];
            x++;
        }


    }
    public void retour()
    {
        Application.LoadLevel("Menu");
    }
}
