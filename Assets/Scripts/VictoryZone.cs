using UnityEngine;
using System.Collections;

public class VictoryZone : MonoBehaviour
{

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<FilleAnimation>().Attached) {
                World.instance.declareVictory();
            }
        }

    }
}
