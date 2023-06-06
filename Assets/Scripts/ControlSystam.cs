using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class ControlSystam : MonoBehaviour
{
	[Header("移動速度")]
	[Range(0, 100)]
	public float moveSpeed = 3.5f;
	[Header("鋼體")]
	public Rigidbody2D rig;
	[Header("動畫控制器")]
	public Animator ani;
	[Header("跑步參數")]
	public string parRun = "開關走路";

	private void Awake()
	{
		print("123");
	}
	private void Start()
	{
		print("<color=#f00>開始事件</color>");
	}
	private void Update()
	{
		print("<color=yellow>更新事件</color>");

		Move();
	}

	private void Move()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		rig.velocity = new Vector2(h, v) * moveSpeed;

		ani.SetBool(parRun, h != 0 || v != 0);

		print(Input.GetKeyDown(KeyCode.A));

		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			print("玩家按下A");
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			print("玩家按下D");
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}

}
