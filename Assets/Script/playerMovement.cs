using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerMovement : MonoBehaviour {

	public float normalSpeed = 10;
	public float quickSpeed = 100;
	public float thrust;
	private int count;
	public Text countText;
	public AudioClip collectSound;

	Rigidbody rb;
	float currentSpeed;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		currentSpeed = normalSpeed;
		rb.maxAngularVelocity = 200;
		count = 0;
		SetCountText ();
		Cursor.visible = false;
	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.LeftShift))
			currentSpeed = quickSpeed;
		else currentSpeed = normalSpeed;

		if (Input.GetKeyDown (KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, 0.5f))
			rb.AddForce (0, thrust, 0);

		if (Input.GetKey(KeyCode.W))
			Roll(true);
		else if (Input.GetKey(KeyCode.S))
			Roll(false);

		if (Input.GetKey(KeyCode.A))
			RollSideways(true);
		else if (Input.GetKey(KeyCode.D))
			RollSideways(false);
	}

	void RollSideways(bool left)
	{
		Vector3 direction = Camera.main.transform.forward;
		direction = left ? direction : direction * -1;
		rb.AddTorque(direction * currentSpeed, ForceMode.Force);
		Debug.Log(currentSpeed);
	}

	void Roll(bool forward)
	{
		Vector3 direction = Camera.main.transform.right;
		direction = forward ? direction : direction * -1;
		rb.AddTorque(direction * currentSpeed, ForceMode.Force);
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			AudioSource.PlayClipAtPoint (collectSound, transform.position);
			other.gameObject.SetActive (false);	
			count = count + 1;
			SetCountText ();	
		}
	}

	void SetCountText ()
	{
		countText.text = "Score: " + count.ToString ();
		if (count == 7) 
		{
			SceneManager.LoadScene ("winScene");
		}
	}

	void Update ()
	{
	if (transform.position.y < -5) 
		{
			SceneManager.LoadScene ("deathScene");	
		}
	}
}
