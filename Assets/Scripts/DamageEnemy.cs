﻿using UnityEngine;
using UnityEngine.Events;

public class DamageEnemy : DamageBasic 
{
	[Header("死亡事件")]
	public UnityEvent onDead;

	private DataEnemy dataEnemy;
	private DamagePlayer damagePlayer;

	private void Start()
	{
		dataEnemy = (DataEnemy)data;
		//print(dataEnemy.expProbability);

		damagePlayer = GameObject.Find("爆走企鵝").GetComponent<DamagePlayer>();

		if(name.Contains("boss"))onDead.AddListener(() => damagePlayer.Win());
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Contains("武器"))
		{
			float damage = collision.gameObject.GetComponent<Weapon>().attack;
			Damage(damage);
			
		}
	}

	protected override void Dead()
	{
		base.Dead();
		onDead.Invoke();
		Destroy(gameObject);

		//print("隨機值:" + Random.value);

		if (Random.value < dataEnemy.expProbability)
		{
			Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
		}
	}
}

