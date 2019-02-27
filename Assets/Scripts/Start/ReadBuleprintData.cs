using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;
using UnityEngine.UI;
/// <summary>
/// 从Blueprint.json中读取相应的设计图数据  存放在list中
/// </summary>
public class ReadBlueprintData : MonoBehaviour {
    ////建造面板的UI
    //public Transform conPanel;
    ////建造物UI预设体
    //public GameObject conPrefab;
    public static ReadBlueprintData instance;
    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start() {

    }
    //由存档类触发Item类
    public void BlueprintInit()
    {

    }
    public List<Blueprint> GetOwnBlueprint(string fileNumber)
    {
        //读取item的json  根据编号
        string datapath = Application.dataPath + "/Blueprint/Blueprint" + fileNumber + ".json";
        string data = File.ReadAllText(datapath, Encoding.UTF8);
        List<Blueprint> blueprints = new List<Blueprint>();
        JsonData root = JsonMapper.ToObject(data);
        JsonData node = root["blueprint"];
        for (int i = 0;i<node.Count;i++)
        {
            Blueprint bp = new Blueprint();
            bp.id = (int)node[i]["id"];
            bp.name = (string)node[i]["name"];
            bp.woodExpend = (int)node[i]["woodExpend"];
            bp.metalExpend = (int)node[i]["metalExpend"];
            bp.type = (int)node[i]["type"];
            bp.value = (int)node[i]["value"];
            bp.image = (string)node[i]["image"];
            bp.ownState = (bool)node[i]["ownState"];
            if (bp.ownState)
            {
                blueprints.Add(bp);
            }
        }
        return blueprints;
    }
    /// <summary>
    /// 读取item的数量
    /// </summary>
    /// <param name="fileNumber">文件编号</param>
    /// <returns>[所有item数量，解锁的item数量]</returns>
    public List<int> GetItemNumber(string fileNumber)
    {
        //读取item的json  根据编号
        string datapath = Application.dataPath + "/Blueprint/Blueprint" + fileNumber+".json";
        string data = File.ReadAllText(datapath, Encoding.UTF8);
        JsonData root = JsonMapper.ToObject(data);
        JsonData node = root["blueprint"];
        int allItemNumber = 0;
        int ownItemNumber = 0;
        List<int> temp = new List<int>();
        for (int i = 0; i < node.Count; i++)
        {
            allItemNumber += 1;
            Blueprint bp = new Blueprint();
            bp.ownState = (bool)node[i]["ownState"];
            if (bp.ownState)
            {
                ownItemNumber += 1;
            }
        }
        //填充数组
        temp.Add(allItemNumber);
        temp.Add(ownItemNumber);
        ////panel创建
        //CreateContructionsPanel(blueprints);
        return temp;
    }

    /// <summary>
    /// 创建新的Item的Json文件
    /// </summary>
    /// <param name="filename">文件名</param>
    public void CreateNewBlueprintFile(string filename)
    {
        //标准的Item信息文件
        string sourceFile = Application.dataPath + "/Blueprint/Standrad.json";
        string destFile = Application.dataPath + "/Blueprint/" + filename;
        File.Copy(sourceFile, destFile);
    }
}
