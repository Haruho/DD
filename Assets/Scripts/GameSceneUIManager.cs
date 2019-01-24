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
    //UI电池预设体
    public GameObject battery;
    //实例化上面变量的父物体
    public Transform bContent;
    //生命值的滑动条
    public Slider healthSlider;

    //当前生命值
    public static float currentHealth;
    //当前电池数
    public static int currentBatteryAmount;

    public static GameSceneUIManager instance;

    public Text archivePath;
    void Awake()
    {
        instance = this;
    }
	// Use this for initialization
	void Start () {
        //生命值获取
        currentHealth = healthSlider.value;
        //存档测试text
       // archivePath.text = Archive.GetInstance().ArchiveNameForTesting;
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

    /// <summary>
    /// 初始化电池数量
    /// </summary>
    public void BatteryAmuountInit(int bAmount)
    {
        //========================
        //这个应该是从currentBatteryAmount作为for的循环数
        //=========================
        for (int i =0;i<bAmount;i++)
        {
            GameObject go = Instantiate(battery);
            go.transform.SetParent(bContent,false);
        }
        //电池数量获取
        currentBatteryAmount = bAmount;
    }
    /// <summary>
    /// 加血
    /// </summary>
    public void Heal()
    {
        print("Jia  xue  ---不知道为什么有延迟！？？？？");
        if (healthSlider.value < 10)
        {
            //加满！
            healthSlider.value += 10;
            //取消显示UI   或者  删除？  
            //有gridcontentlayout  所以删除最后一个子物体即可
            Destroy(bContent.GetChild(bContent.childCount - 1).gameObject);
            //当前电池数量减一
            currentBatteryAmount -= 1;
        }
        else
        {
            print("生命值已满");
        }

    }
    /// <summary>
    /// 获取电池
    /// </summary>
    public void AddBattery(int maxBattery)
    {
        //执行前已经判断
        //电池数量+1
        currentBatteryAmount += 1;
        //创建UI
        GameObject go = Instantiate(battery);
        go.transform.SetParent(bContent, false);
    }
}
