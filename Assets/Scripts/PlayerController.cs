using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    Collider collider;
    [SerializeField] int speed;
	[SerializeField] int jumpForce;
	bool isJumping;

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		collider = GetComponent<Collider>();
		isJumping = false;
	}

    void FixedUpdate()
	{
		if (GameManager.instance.gamestate == GameManager.GameState.PAUSE )
		{
			if(!rigidbody.isKinematic) { rigidbody.isKinematic = true; }
			return;
		}
		else if (GameManager.instance.gamestate == GameManager.GameState.PLAYING && rigidbody.isKinematic)
		{
			rigidbody.isKinematic = false;
		}

		if (Input.GetKey(KeyCode.W))
		{
			rigidbody.AddForce(Vector3.forward * speed);
		}
		if (Input.GetKey(KeyCode.S))
		{
			rigidbody.AddForce(Vector3.back * speed);
		}
		if (Input.GetKey(KeyCode.A))
		{
			rigidbody.AddForce(Vector3.left * speed);
		}
		if (Input.GetKey(KeyCode.D))
		{
			rigidbody.AddForce(Vector3.right * speed);
		}

		if (Input.GetKey(KeyCode.Space) && !isJumping)
		{
			rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			isJumping = true;
		}

		if(transform.position.y < -20)
		{
			GameManager.instance.StartGame();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<RoadController>())
		{
			isJumping = false;
		}
	}
}
