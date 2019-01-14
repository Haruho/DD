using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 玩家实例，包含输入操作的键位
/// </summary>
public class PlayerInstance : MonoBehaviour {
    //玩家实例
    public Player cplayer;

    //是否进入采集状态
    public bool isCanGather;
    //当前正在采集的物体
    public static GameObject currentObj;
    //transform实例
    private Transform ctransform;

    //玩家拥有的材料数量
    private int woodNumber;
    private int meatlNumber;
    //禁用移动标志位
    private bool isCanMove;
	// Use this for initialization
	void Start () {
        Init();
    }

    /// <summary>
    /// 初始化方法，所有玩家的变量在这里初始化
    /// </summary>
    private void Init()
    {

        //=========================
        //非初次进入游戏需要读取Archive的实例，也就是存档，根据存档给Player初始化
        //Mark
        //========================
        //初始化玩家实例
        Archive archive = Archive.GetInstance();
        //直接运行会空指针，方便测试先加一个临时的player
        if (archive == null)
        {
            Player tempplayer = new Player();
            tempplayer.Vit = 5;
            tempplayer.Wit = 5;
            tempplayer.Speed = 10;
            cplayer = tempplayer;
        }
        else
        {
            cplayer = archive.player;
        }
        //赋值
        //cplayer.Vit = 5;
        //cplayer.Speed = 10;
        //cplayer.Wit = 3;
        //print("MaxBatteryAmount :" + cplayer.MaxBatteryAmount);
        //print("Vit :" + cplayer.Vit);
        //print("Speed :" + cplayer.Speed);
        //print("Wit :" + cplayer.Wit);
        //transform声明
        ctransform = transform;
        //移动初始化
        isCanMove = true;
        //初始化电池UI
        GameSceneUIManager.instance.BatteryAmuountInit(cplayer.MaxBatteryAmount);
    }
    // Update is called once per frame
    void FixedUpdate () {

        OperateFunction();

    }
    /// <summary>
    /// 包含玩家的操作
    /// </summary>
    void OperateFunction()
    {
        //Move
        if (Input.GetKey(KeyCode.A) && isCanMove)
        {
            ctransform.Translate(Time.deltaTime * -cplayer.Speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) && isCanMove)
        {
            ctransform.Translate(Time.deltaTime * cplayer.Speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.W) && isCanMove)
        {
            ctransform.Translate(0,Time.deltaTime * cplayer.Speed,0);
        }
        if (Input.GetKey(KeyCode.S) && isCanMove)
        {
            ctransform.Translate(0, Time.deltaTime * -cplayer.Speed,0);
        }
        //采集
        if (Input.GetKey(KeyCode.E))
        {
            //接触到资源物体  能采集
            if (isCanGather)
            {
                //进度的设置
                currentObj.GetComponent<ResourcesInstance>().life -= 1f;
                GameSceneUIManager.instance.ChargebarDisplay();
                Vector3 ctPos = Camera.main.WorldToScreenPoint(ctransform.position);
                GameSceneUIManager.instance.chargeBar.GetComponent<RectTransform>().position = new Vector2(ctPos.x,ctPos.y + 100);
                if (currentObj.GetComponent<ResourcesInstance>().life == 0)
                {
                    print("Gather is Finish");
                   // isCanMove = true;
                    ResourcesCount(currentObj);
                }
                else
                {
                    //禁用移动
                    isCanMove = false;
                    print("Gathering");
                }
            }
            else
            {
                print("No gathering");
            }
        }else
        //采集完成之后在抬起按键的那帧取消交互  和资源实例中的取消交互目标一致
        if (Input.GetKeyUp(KeyCode.E))
        {
            //恢复移动
            isCanMove = true;
            //禁用UI
            GameSceneUIManager.instance.ChargeBarHide();
            if (isCanGather)
            {
                if (currentObj.GetComponent<ResourcesInstance>().life < 0)
                {
                    currentObj.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
        //使用电池回复生命值
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameSceneUIManager.instance.Heal();
        }
    }

    /// <summary>
    /// 更新UI的显示
    /// </summary>
    /// <param name="type"></param>
    void ResourcesCount(GameObject obj)
    {
        //确定资源类型
        ResourcesType type = obj.GetComponent<ResourcesInstance>().type;
        try
        {
            switch (type)
            {
                default:
                    break;
                case ResourcesType.metal:
                    meatlNumber = meatlNumber + 1;
                    break;
                case ResourcesType.wood:
                    woodNumber = woodNumber + 5;
                    break;
            }
        }
        catch
        {
            return;
        }
        finally
        {
            GameSceneUIManager.instance.UpdataResourcesUI(woodNumber, meatlNumber);
        }
    }
    //测试成功
    public void TestArchive()
    {
        //当前血量存储问题
        ArchiveOperate ao = new ArchiveOperate();
        ao.CreateGameData(cplayer);
    }
}
