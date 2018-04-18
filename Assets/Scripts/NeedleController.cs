using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private GameObject needleBody;

    private bool isFired = false;
    private bool hitCircle = false;

    private Rigidbody2D rg;

    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.isKinematic = true;
        needleBody.SetActive(false);
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (isFired)
	    {
	        rg.velocity = new Vector2(0, moveSpeed);
	    }
	}

    public void Fire()
    {
        needleBody.SetActive(true);
        rg.isKinematic = false;
        isFired = true;

    }


    void OnTriggerEnter2D(Collider2D collider)
    {
       
        if (hitCircle)
            return;

      
        if (collider.tag == "Circle")
        {
            hitCircle = true;
            rg.isKinematic = true;
            rg.velocity = new Vector2(0, 0);
            isFired = false;
            gameObject.transform.SetParent(collider.gameObject.transform);
            GameManager.Instance.CreateNeedle();
            ScoreManager.Instance.AddScore();
        }
      
    }
}
