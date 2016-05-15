using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;

	public Text countText;
	public Text debugText;
	public Text winText;

	// Use this for initialization
	void Start() 
	{
		Screen.orientation = ScreenOrientation.Landscape;
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0,moveVertical);

		if (SystemInfo.supportsGyroscope) {
			movement = new Vector3 (Input.acceleration.x, 0, Input.acceleration.y);
			movement *= 4;
			debugText.text = Input.acceleration.ToString ();
		}
		rb.AddForce (movement*speed);
		SetCountText ();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pickup"))
		{
			other.gameObject.SetActive (false);
			count++;
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12)
		{
			winText.text = "You Win!";
		}
	}
}
