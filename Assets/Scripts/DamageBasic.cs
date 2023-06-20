using UnityEngine;

public class DamageBasic : MonoBehaviour
{
	[Header("資料")]
	public DataBasic data;

	private float hp;

	private void Awake()
	{
		hp = data.hp;
	}

	public void Damage(float damage)
	{
		hp -= damage;
		print($"<color=#fe6>{gameObject.name} 血量剩下:{hp}</color>");

		if (hp <= 0) Dead();
	}
	private void Dead()
	{
		print($"<color=#f96>{gameObject.name} 死亡</color>");
	}
}
