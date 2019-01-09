using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 玩家实例，包含输入操作的键位
/// </summary>
public class PlayerInstance : MonoBehaviour {
    //玩家实例
    private Player cplayer;

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
        //初始化玩家实例
        cplayer = new Player();
        //赋值
        cplayer.Vit = 5;
        cplayer.Speed = 10;
        cplayer.Wit = 3;
        //transform声明
        ctransform = transform;
        isCanMove = true;
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
}
