using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneArchive : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TestArchive()
    {
        ArchiveOperate ao = new ArchiveOperate();
        Player a = new Player();
        ao.CreateGameData(a);
    }
}
