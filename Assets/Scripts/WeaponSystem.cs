using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
	[Header("生成間隔"), Range(0, 10)]
	public float interval = 3.5f;

	[Header("生成武器預置物")]
	public GameObject prefabRock;

	private void SpawnRock()
	{
		Instantiate(prefabRock, transform.position, transform.rotation);
	}

	private void Awake()
	{
		InvokeRepeating("SpawnRock", 0, interval);
	}
}
