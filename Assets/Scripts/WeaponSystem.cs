using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
	[Header("�ͦ����j"), Range(0, 10)]
	public float interval = 3.5f;

	[Header("�ͦ��Z���w�m��")]
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
