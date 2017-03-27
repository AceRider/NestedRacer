using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
	private float maxSpeed = 2;

	[Header("Player states")]
	public bool isDead = false;


	void Start ()
	{

	}

	void FixedUpdate ()
	{
		var dirH = Input.GetAxis ("Horizontal") / 6;
		var dirV = 0.1f;//Input.GetAxis ("Vertical") / 6;
		var pos = transform.position;

		//print (dirV);

		transform.position = new Vector3 (dirH + pos.x, dirV + pos.y, -1);

	}

	void Update () {

	//	if (Input.GetMouseButtonDown(0)) {
			if (isDead) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			} 
		//}

		if (isDead)
			return;


	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.CompareTag ("Obstacle")) {
			// Mooorreu :(
			isDead = true;
			// Deixa de colidir
			GetComponent<Collider2D> ().isTrigger = true;


		}
	}
}