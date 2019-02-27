using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prepare
{
    public static List<Blueprint> blueprints;
    public static string filename;
}
public class PrepareInterface : MonoBehaviour {
    private GameObject blueprintButton;
    private Transform bpParent;
    private static List<Blueprint> blueprint;
	// Use this for initialization
	void Start () {
        blueprintButton = Resources.Load("Prefabs/UIPrefabs/bluePrintButton") as GameObject;
        bpParent = GameObject.Find("Canvas/warehouse").transform;
        CreateInterface();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void CreateInterface()
    {
        //获取
        blueprint = ReadBlueprintData.instance.GetOwnBlueprint(Prepare.filename);
        for (int i =0;i<blueprint.Count;i++)
        {
            GameObject go = Instantiate(blueprintButton);
            go.transform.SetParent(bpParent,false);
            go.transform.name = blueprint[i].name;
        }
    }
    /// <summary>
    /// 获取Item的Info
    /// </summary>
    /// <param name="name">Item的名称标识</param>
    /// <returns>Item Info</returns>
    public static string[] GetItemInfo(string name)
    {
        string[] info = new string[] { };
        for (int i =0;i<blueprint.Count;i++)
        {
            if (blueprint[i].name == name)
            {
                info = new string[] { blueprint[i].name, blueprint[i].woodExpend.ToString(), blueprint[i].metalExpend.ToString() };
            }
            else
            {
                print("No Such of Item");
            }
        }
        return info;
    }
}
