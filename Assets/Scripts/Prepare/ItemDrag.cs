using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 实现UI的拖拽效果
/// </summary>
public class ItemDrag : MonoBehaviour{
    Transform backpack;
    Transform warehouse;
    Text infoText;
    //存放信息的变量
    string[] info = new string[] { };
    private void Start()
    {
        backpack = GameObject.Find("Canvas/backpack").transform;
        warehouse = GameObject.Find("Canvas/warehouse").transform;
        infoText = GameObject.Find("Canvas/ItemIntro/Text").GetComponent<Text>();
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
    public void PointerEnter()
    {
        if (info.Length == 0)
        {
            info = PrepareInterface.GetItemInfo(transform.name);
        }
        //给text赋值
        infoText.text = "名称：" + info[0] + "\n"
                        + "花费木材：" + info[1] + "\n"
                        + "花费金属：" + info[2];
    }
    public void PointerExit()
    {
        infoText.text = "";
    }
}
