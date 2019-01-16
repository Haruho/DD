using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;
/// <summary>
/// 从Blueprint.json中读取相应的设计图数据  存放在list中
/// </summary>
public class ReadBuleprintData : MonoBehaviour {
    public List<Blueprint> blueprints;
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
            bp.name = (string)node[i]["name"];
            bp.woodExpend = (int)node[i]["woodExpend"];
            bp.metalExpend = (int)node[i]["metalExpend"];
            bp.type = (int)node[i]["type"];
            bp.value = (int)node[i]["value"];
            bp.image = (string)node[i]["image"];
            blueprints.Add(bp);
        }
        print(blueprints.Count);
    }
}
