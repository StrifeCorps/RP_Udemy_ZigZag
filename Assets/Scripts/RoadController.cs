using System.Collections;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    Rigidbody rigidbody;
	bool isDropping = false;

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		
		int random = Random.Range(0, 2);
		if (random == 0)
		{
			transform.Rotate(Vector3.up*90);
		}
		else
		{
			transform.Rotate(Vector3.right*90);
		}
	}

	private void FixedUpdate()
	{
		if (transform.position.y < -20)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<PlayerController>())
		{
			StartCoroutine(DropBlock());
		}
	}

	IEnumerator DropBlock()
	{
		yield return new WaitForSeconds(1f);
		if (!isDropping)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
			isDropping = true;
		}
		yield return new WaitForSeconds(1.5f);
		rigidbody.isKinematic = false;
	}
}
