using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 选择道具的Pointer
/// </summary>
public class Pointer : MonoBehaviour {
    public static Pointer instance;
    private Transform m_transform;

    private GameObject selectObj;
    
    void Awake()
    {
        instance = this;
    }
	// Use this for initialization
	void Start () {
        m_transform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        //指向鼠标位置
        //求鼠标和指针的向量
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        //根据三角函数算弧度  再转角度
        float angle = 360 - Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        //赋值
        m_transform.eulerAngles = new Vector3(0,0,angle);

        //发射射线
       // Ray2D ray = new Ray2D(m_transform.position,m_transform.forward);
       //射线的实现效果不好

	}
    /// <summary>
    /// 指针通过collider的碰撞来确定选择
    /// </summary>
    /// <param name="item"></param>
    void OnTriggerStay2D(Collider2D item)
    {
        if (item != null)
        {
            selectObj = item.gameObject;
            item.gameObject.transform.localScale = Vector3.Lerp(item.gameObject.transform.localScale,new Vector3(0.4f,0.4f,0.4f),Time.time * 0.1f);
        }
        else
        {
            print("Null");
        }
    }
    void OnTriggerExit2D(Collider2D item)
    {
        if (item != null)
        {
            item.gameObject.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        }
    }
    /// <summary>
    /// 确定选择的item
    /// </summary>
    public void ConfirmItem()
    {
        print("选择了 ：" + selectObj.name);
        
    }
}
