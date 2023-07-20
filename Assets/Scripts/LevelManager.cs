using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using JetBrains.Annotations;

public class LevelManager : MonoBehaviour
{
	[Header("經驗值")]
	public Image imgExp;
	[Header("文字等級")]
	public TextMeshProUGUI textLv;
	[Header("文字經驗值")]
	public TextMeshProUGUI textExp;
	[Header("升級面板")]
	public GameObject goLvUp;
	[Header("技能 1~3")]
	public GameObject[] goSkillUI;
	/// <summary>
	/// 0吸取經驗
	/// 1石頭攻擊
	/// 2石頭間隔
	/// 3玩家血量
	/// 4移動速度
	/// </summary>
	[Header("技能資料陣列")]
	public DataSkill[] dataSkills;

	public List<DataSkill> randomSkill = new List<DataSkill>();

	private int lv = 1;
	private float exp = 0;
	public float[] expNeeds = { 100, 200, 300, 400};

	private void Start()
	{
		for (int i = 0; i < 10; i++)
		{
			print($"<color=#ff6699>i 的值 : {i}</color>");
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//print($"<color=#69f>{collision.name}</color>");

		if (collision.name.Contains("經驗值"))
		{
			collision.GetComponent<ExpSyatem>().enabled = true;
		}
	}

	public void AddExp(float exp)
	{
		this.exp += exp;

		if (this.exp > expNeeds[lv - 1])
		{
			this.exp -= expNeeds[lv - 1];
			lv++;
			textLv.text = lv.ToString();
			LevelUp();
		}

		textExp.text = this.exp + " / " + expNeeds[lv - 1];
		imgExp.fillAmount = this.exp / expNeeds[lv - 1];
	}
	
	
	private void LevelUp()
	{
		goLvUp.SetActive(true);
		Time.timeScale = 0;

		randomSkill = dataSkills.Where(skill => skill.skillLv < 5).ToList();
		randomSkill = randomSkill.OrderBy(skill => Random.Range(0, 999)).ToList();

		for (int i = 0; i < 3; i++)
		{
			goSkillUI[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillName;
			goSkillUI[i].transform.Find("技能描述").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillDescription;
			goSkillUI[i].transform.Find("技能等級").GetComponent<TextMeshProUGUI>().text = "Lv" + randomSkill[i].skillLv;
			goSkillUI[i].transform.Find("技能圖片").GetComponent<Image>().sprite = randomSkill[i].skillPicture;
		}
	}

	[ContextMenu("產生經驗值需求資料")]
	private void ExpNedds()
	{
		expNeeds = new float[100];

		for (int i = 0; i < 100; i++)
		{
			expNeeds[i] = (i + 1) * 100;
		}
	}

	public void ClickSkillButton(int indexSkill)
	{
		//print($"<color=#6699ff>點擊技能編號:{indexSkill}</color>");
		randomSkill[indexSkill].skillLv++;
		goLvUp.SetActive(false);
		Time.timeScale = 1;

		if (randomSkill[indexSkill].skillName == "吸取經驗值範圍") UpdateExpRange();
		if (randomSkill[indexSkill].skillName == "武器石頭攻擊") UpdateRockAttak();
		if (randomSkill[indexSkill].skillName == "武器石頭生成間隔") UpdateRockInterval();
		if (randomSkill[indexSkill].skillName == "玩家血量") UpdatePlayerHp();
		if (randomSkill[indexSkill].skillName == "移動速度") UpdateMoveSpeed();

	}

	[Header("爆走企鵝:圓形碰撞")]
	public CircleCollider2D playerExpRange;

	private void UpdateExpRange()
	{
		int lv = dataSkills[0].skillLv - 1;
		playerExpRange.radius = dataSkills[0].skillValues[lv];
	}

	[Header("武器石頭生成點")]
	public WeaponSystem weaponSystemRock;

	private void UpdateRockAttak()
	{
		int lv = dataSkills[2].skillLv - 1;
		weaponSystemRock.interval = dataSkills[2].skillValues[lv];
	}

	private void UpdateRockInterval()
	{
		
	}

	[Header("玩家資料")]
	public DataBasic dataBasic;

	private void UpdatePlayerHp()
	{
		int lv = dataSkills[3].skillLv - 1;
		dataBasic.hp = dataSkills[3].skillValues[lv];
	}

	[Header("爆走企鵝:控制系統")]
	public ControlSystam controlSystem;

	private void UpdateMoveSpeed()
	{
		int lv = dataSkills[4].skillLv - 1;
		controlSystem.moveSpeed = dataSkills[4].skillValues[lv];
	}
}
