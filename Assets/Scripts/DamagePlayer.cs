﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageBasic
{
	[Header("血條")]
	public Image imgHp;
	[Header("控制系統")]
	public ControlSystam controlSystam;
	[Header("武器石頭生成點")]
	public WeaponSystem weaponSystem;
	[Header("結束畫面")]
	public GameObject goFinal;
	[Header("結束標題")]
	public TextMeshProUGUI textFinal;

	public override void Damage(float damage)
	{
		base.Damage(damage);

		AudioClip sound = SoundManager.instance.soundPlayerHurt;
		SoundManager.instance.PlaySound(sound, 0.8f, 1.5f);

		imgHp.fillAmount = hp / hpMax;
	}

	protected override void Dead()
	{
		base.Dead();

		if (goFinal.activeInHierarchy) return;

		AudioClip sound = SoundManager.instance.soundPlayerDead;
		SoundManager.instance.PlaySound(sound, 0.8f, 1.5f);

		controlSystam.enabled = false;
		weaponSystem.Stop();
		textFinal.text = "你已經死了...";
		goFinal.SetActive(true);
	}

	public void Win()
	{
		if (goFinal.activeInHierarchy) return;
		textFinal.text = "恭喜過關";
		goFinal.SetActive(true);
	}
}
