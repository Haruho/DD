using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 存档的3个按钮
/// </summary>
public class ArchiveButton : MonoBehaviour {
    private Button mButton;
	// Use this for initialization
	void Start () {
        mButton = transform.GetComponent<Button>();
        Init();
	}
    /// <summary>
    /// 寻找存档数据
    /// </summary>
    /// <returns>存档是否存在</returns>
    public bool Init()
    {
        //print("archive button");
        //根据按钮名称获取存档文件
        if (File.Exists(Application.dataPath + "/Archive/" + mButton.name + ".cd"))
        {
            mButton.GetComponentInChildren<Text>().text = "有存档 \n 收集率：" + ReadBuleprintData.GetCollectionRate();
            return true;
        }
        else
        {
            mButton.GetComponentInChildren<Text>().text = "使用新存档";
            return false;
        }
    }
}
