using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Bounds boundary;

	private Rigidbody rb;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		rb.velocity = speed * (new Vector3 (moveHorizontal, 0, moveVertical));

		Vector3 oldPos = rb.position;
		rb.position = new Vector3 (
			Mathf.Clamp (oldPos.x, boundary.min.x, boundary.max.x),
			0,
			Mathf.Clamp (oldPos.z, boundary.min.z, boundary.max.z)
		);

		rb.rotation = Quaternion.Euler (0, 0, -moveHorizontal * tilt);
	}
}
