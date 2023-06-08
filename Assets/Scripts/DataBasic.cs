using UnityEngine;

[CreateAssetMenu(menuName = "Nozomi/Data Basic")]
public class DataBasic : ScriptableObject
{
	[Header("血量"), Range(0, 10000)]
	public float hp;
	[Header("攻擊力"), Range(0, 1000)]
	public float attack;
	[Header("移動速度"), Range(0, 100)]
	public float moveSpeed;

}