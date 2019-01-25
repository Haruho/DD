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
        List<Blueprint> blueprints = ReadBuleprintData.instance.GetOwnBlueprint(Prepare.filename);
        for (int i =0;i<blueprints.Count;i++)
        {
            GameObject go = Instantiate(blueprintButton);
            go.transform.SetParent(bpParent,false);
        }
    }
}
