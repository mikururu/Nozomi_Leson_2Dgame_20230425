using TMPro;
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

	//private void Start()
	//{
	//	Damage(50);
	//}

	public override void Damage(float damage)
	{
		base.Damage(damage);
		imgHp.fillAmount = hp / hpMax;
	}

	protected override void Dead()
	{
		base.Dead();
		controlSystam.enabled = false;
		weaponSystem.Stop();
		textFinal.text = "你已經死了...";
		goFinal.SetActive(true);
	}

	public void Win()
	{
		textFinal.text = "恭喜過關";
		goFinal.SetActive(true);
	}
}
