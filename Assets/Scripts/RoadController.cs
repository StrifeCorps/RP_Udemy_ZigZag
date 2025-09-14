using System.Collections;
using UnityEngine;

public class RoadController : MonoBehaviour
{
	[SerializeField] GameObject collectItemPrefab;
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

		int random2 = Random.Range(0, 2);
		if (random2 == 0)
		{
			Instantiate(collectItemPrefab, transform.position + new Vector3(0, .7f, 0), Quaternion.identity);
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
		yield return new WaitForSeconds(1.5f);
		if (!isDropping)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
			isDropping = true;
		}
		yield return new WaitForSeconds(1.5f);
		rigidbody.isKinematic = false;
	}
}
