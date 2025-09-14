using UnityEngine;

public class CollectItem : MonoBehaviour
{

	private void FixedUpdate()
	{
		transform.Rotate(Vector3.up * 2);
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.GetComponent<PlayerController>())
		{
			GameManager.instance.AddScore();
			Destroy(gameObject);
		}
	}
}
