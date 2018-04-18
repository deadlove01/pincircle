using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 55f;

    [SerializeField]
    private float minSpeed = 45f;
    [SerializeField]
    private float maxSpeed = 100f;

    private bool canRotate;
    private float angle;

	// Use this for initialization
	void Start ()
	{
	    canRotate = true;
	    StartCoroutine(ChangeRotation());
	}


 
	
	// Update is called once per frame
	void Update () {
	    if (canRotate)
	    {
	        RotateMySelf();
	    }
	}

    IEnumerator ChangeRotation()
    {
        yield return new WaitForSeconds(Random.Range(2,5));

        var percent = Random.Range(0, 2);
        if (percent > 0)
        {
            rotateSpeed = -Random.Range(minSpeed, maxSpeed);
        }
        else
        {
            rotateSpeed = Random.Range(minSpeed, maxSpeed);
        }

        StartCoroutine(ChangeRotation());
    }
    void RotateMySelf()
    {
        angle = transform.eulerAngles.z;
        angle += rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }


    public void StopRotateMySelf()
    {
        canRotate = false;
    }
}
