using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 实现UI的拖拽效果
/// </summary>
public class ItemDrag : MonoBehaviour{
    Transform backpack;
    Transform warehouse;
    private void Start()
    {
        backpack = GameObject.Find("Canvas/backpack").transform;
        warehouse = GameObject.Find("Canvas/warehouse").transform;
    }
    /// <summary>
    /// Item的点击效果，从仓库到背包
    /// </summary>
    public void OnClick()
    {
        //在背包中的话
        if (transform.parent.name == backpack.name)
        {
            transform.SetParent(warehouse, false);
        }
        else if (transform.parent.name == warehouse.name)
        {
            transform.SetParent(backpack, false);
        }
    }
}
