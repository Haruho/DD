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
public class ReadBuleprintData : MonoBehaviour {
    //用来存储item 实例
    public static List<Blueprint> blueprints;
    //建造面板的UI
    public Transform conPanel;
    //建造物UI预设体
    public GameObject conPrefab;
    private string datapath;
	// Use this for initialization
	void Start () {
        blueprints = new List<Blueprint>();
        datapath = Application.dataPath + "/Resources/Blueprint.json";

        ReadData();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ReadData()
    {
        string data = File.ReadAllText(datapath,Encoding.UTF8);
        JsonData root = JsonMapper.ToObject(data);
        JsonData node = root["blueprint"];

        for (int i =0;i<node.Count;i++)
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
            blueprints.Add(bp);
        }
        CreateContructionsPanel(blueprints);
    }
    /// <summary>
    /// 创建建造物的面板
    /// </summary>
    void CreateContructionsPanel(List<Blueprint> conObj)
    {
        for (int i =0;i<conObj.Count;i++)
        {
            //获取拥有状态的实例
            if (conObj[i].ownState)
            {
                //实例化UI
                GameObject go = Instantiate(conPrefab,conPanel);
                //替换图片
                go.GetComponent<Image>().sprite = 
                    (Sprite)Resources.Load("ItemImage/" + conObj[i].image, typeof(Sprite));
            }
        }
    }
}
