using UnityEngine;

public class CameraControl : MonoBehaviour
{
    PlayerController playerController;

    void Start()
	{
		playerController = FindFirstObjectByType<PlayerController>();
	}

	void Update()
	{
		transform.position = new Vector3(playerController.transform.position.x, transform.position.y, playerController.transform.position.z -6);
	}
}
