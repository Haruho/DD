using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实现玩家的攻击效果
/// </summary>
public class PlayerAttack : MonoBehaviour {
	//玩家攻击状态的标志位
	public static bool isCanAttack;
    public static PlayerAttack instance;
    private Transform player;
    void Awake()
    {
        instance = this; 
    }
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
		isCanAttack = false;
        //给Player添加武器图片

	}
	
	// Update is called once per frame
	void Update () {
		if(isCanAttack){
			if(Input.GetMouseButtonDown(0)){
				//发射子弹  或者别的效果
				print("Shoot");
			}
		}
	}

    /// <summary>
    /// 成功制作武器，添加武器图片
    /// </summary>
    /// <param name="weaponName"></param>
    public void AddWeaponSprite(string weaponName)
    {
        
    }
}
