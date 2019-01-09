using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 游戏场景的UI管理器
/// </summary>
public class GameSceneUIManager : MonoBehaviour {
    //显示资源的Text文本
    public Text woodText;
    public Text metalText;
    //采集的进度条
    public Image chargeBar;
    public static GameSceneUIManager instance;

    
    void Awake()
    {
        instance = this;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //更新资源显示
    public void UpdataResourcesUI(int wood,int metal)
    {
        woodText.text = "Wood Number:" +wood.ToString();
        metalText.text ="Metal Number:" + metal.ToString();
    }
    public void ChargebarDisplay()
    {
        chargeBar.gameObject.SetActive(true);
        chargeBar.fillAmount += 0.0105f;
        //颜色渐变
        chargeBar.color = Color.Lerp(Color.red,Color.green,Time.deltaTime);
        if (PlayerInstance.currentObj.GetComponent<ResourcesInstance>().life <= 0)
        {
            //重置charge的value
            chargeBar.fillAmount = 0;
            //取消显示
            chargeBar.gameObject.SetActive(false);
        }
    }
    public void ChargeBarHide()
    {
        //伐木进程不需要恢复树木的初始血量 也就不需要重置ChargeBar的重置
        //取消显示
        chargeBar.gameObject.SetActive(false);
    }
}
