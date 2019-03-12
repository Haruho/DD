using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实现玩家的攻击效果
/// </summary>
public class PlayerAttack : MonoBehaviour {
	//玩家攻击状态的标志位
	public static bool isCanAttack;
	// Use this for initialization
	void Start () {
		isCanAttack = false;
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
}
