using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleHead : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "NeedleHead")
        {
            GameManager.Instance.EndGame();
        }
    }
}
