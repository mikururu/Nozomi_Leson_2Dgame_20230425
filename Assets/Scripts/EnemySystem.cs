using System.Globalization;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
	[Header("敵人資料")]
	public DataEnemy data;
	
	private Transform player;
	private float timer;

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1, 0, 0.3f, 0.5f);

		Gizmos.DrawSphere(transform.position, 2);
	}

	private void Awake()
	{
		player = GameObject.Find("爆走企鵝").transform;
	}
	private void Update()
	{
		float distance = Vector3.Distance(transform.position, player.position);
		print(distance);

		if(distance > data.attackRange)
		{
			transform.position = Vector3.MoveTowards(transform.position, player.position, data.moveSpeed * Time.deltaTime);
		}
		else
		{
			print("<color=#f96>進入攻擊範圍</color>");

			timer += Time.deltaTime;
			print($"<color=#9f4>計時器 : {timer}</color>");
		}
	}
}
