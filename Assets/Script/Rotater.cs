using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
	float Speed;
	public float rotationSpeed;

	void Start ()
	{
		Speed = rotationSpeed;
	}

	void Update () 
	{
		transform.Rotate (new Vector3 (0, 90, 0) * Time.deltaTime * Speed);
	}
}
