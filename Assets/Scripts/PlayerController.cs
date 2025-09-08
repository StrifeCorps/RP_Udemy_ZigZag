using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Collider collider;
    [SerializeField] int speed;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		collider = GetComponent<Collider>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.W))
		{
			rb.AddForce(Vector3.forward * speed);
		}
		if (Input.GetKey(KeyCode.S))
		{
			rb.AddForce(Vector3.back * speed);
		}
		if (Input.GetKey(KeyCode.A))
		{
			rb.AddForce(Vector3.left * speed);
		}
		if (Input.GetKey(KeyCode.D))
		{
			rb.AddForce(Vector3.right * speed);
		}
	}a
}
