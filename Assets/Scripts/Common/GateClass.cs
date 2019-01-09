using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gate实现中的通用类
/// </summary>
public class GateClass : MonoBehaviour
{
    void Start()
    {
        //获取所有Gate的图示
    }


    public Sprite ObjToSprite(string sName)
    {
        Sprite s = null;
        //这个变量放在类中声明之后会报空指针
        object[] gateGuise = Resources.LoadAll("GateGuise", typeof(Sprite));
        //gateGuise = Resources.LoadAll("GateGuise", typeof(Sprite));
        for (int i = 0; i < gateGuise.Length; i++)
        {
            if (gateGuise[i].ToString().Contains(sName))
            {
                s = (Sprite)gateGuise[i];
            }
        }
        return s;
    }
}