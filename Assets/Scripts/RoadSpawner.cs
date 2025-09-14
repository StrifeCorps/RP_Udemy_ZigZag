using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] GameObject roadPrefab;
	float offset = .707f;

	public void SpawnStart()
	{
		InvokeRepeating("SpawnRoad", .2f, .3f);
	}

	public void SpawnRoad()
	{
		int random = Random.Range(0, 2);

		if (random == 0)
		{
			Instantiate(roadPrefab, transform.position + new Vector3(offset, 0, offset), Quaternion.Euler(0, 45, 0));
			transform.position += new Vector3(offset, 0, offset);
		}
		else
		{
			Instantiate(roadPrefab, transform.position + new Vector3(-offset, 0, offset), Quaternion.Euler(0, 45, 0));
			transform.position += new Vector3(-offset, 0, offset);
		}
	}
}
