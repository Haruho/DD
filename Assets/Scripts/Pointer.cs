using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 选择道具的Pointer
/// </summary>
public class Pointer : MonoBehaviour {
    private Transform m_transform;
   // Ray2D ray;
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
        RaycastHit2D hit = Physics2D.Raycast(m_transform.position, m_transform.up,8);
        if (hit.transform != null)
        {
            print(hit.transform.name);
        }
	}
}
