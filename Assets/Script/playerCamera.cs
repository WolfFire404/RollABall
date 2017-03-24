using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class playerCamera : MonoBehaviour
{

    public float offset;
    public Vector3 rotation;
    public Transform target;
    public Rigidbody rb;

    void Start()
    {
        rotation = transform.eulerAngles;

        if (!rb)
            rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    void Update()
	{
		rotation.x -= Input.GetAxis ("Mouse Y") * 100 * Time.deltaTime;
		rotation.y += Input.GetAxis ("Mouse X") * 100 * Time.deltaTime;
		transform.eulerAngles = rotation;
		transform.position = target.position + (offset * -transform.forward);	
	}
}