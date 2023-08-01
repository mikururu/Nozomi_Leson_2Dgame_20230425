﻿using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageBasic
{
	[Header("血條")]
	public Image imgHp;

	//private void Start()
	//{
	//	Damage(50);
	//}

	public override void Damage(float damage)
	{
		base.Damage(damage);
		imgHp.fillAmount = hp / hpMax;
	}
}
