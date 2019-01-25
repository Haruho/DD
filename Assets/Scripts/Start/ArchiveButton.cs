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
    //是否要创建新的存档文件
    private bool isNewData;
	// Use this for initialization
	void Start () {
        mButton = transform.GetComponent<Button>();
        //添加委托
        mButton.onClick.AddListener(OnClick);
        if (File.Exists(Application.dataPath + "/Archive/" + mButton.name + ".cd"))
        {
            isNewData = false;
        }
        else
        {
            isNewData = true;
        }
        Init();
	}
    /// <summary>
    /// 寻找存档数据
    /// </summary>
    /// <returns>存档是否存在</returns>
    public bool Init()
    {
        string fileNumber = mButton.name.Substring(mButton.name.Length - 1, 1);
        //根据按钮名称获取存档文件
        if (!isNewData)
        {
            //先读取数据 返回所有的item的长度
            List<int> ratelist = ReadBuleprintData.instance.GetItemNumber(fileNumber);
            //计算所有率 保留一个小数
            string rate = (((float)ratelist[1] / ratelist[0]) * 100).ToString("0.0") + "%";
            mButton.GetComponentInChildren<Text>().text = "有存档 \n 收集率：" + rate;
            return true;
        }
        else
        {
            mButton.GetComponentInChildren<Text>().text = "使用新存档";
            return false;
        }
    }
    /// <summary>
    /// 按钮的点击事件  直接去读取archive数据 并且把数据传送到下一个场景
    /// </summary>
    void OnClick()
    {
        //获取存档编号
        string fileNumber = mButton.name.Substring(mButton.name.Length - 1, 1);
        Prepare.filename = fileNumber;
        //读取存档
        if (!isNewData)
        {
            string archivePath = Application.dataPath + "/Archive/" + mButton.name + ".cd";
            ArchiveOperate.ReadDataByNumber(archivePath);
            //执行完上面的数据读取  跳转场景
            SceneController.instance.ToStart();
        }
        else
        //创建新存档 和 新的item json文件
        {
            ArchiveOperate ao = new ArchiveOperate();
            ao.CreateGameData(mButton.name+ ".cd");
            ReadBuleprintData.instance.CreateNewBlueprintFile("Blueprint" + fileNumber + ".json");
        }
            
    }
}
