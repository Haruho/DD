using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class WormHoleBehaviour : MonoBehaviour {
    //休眠时间  经过休眠时间之后，虫洞开始生成怪物
    public float sleepTime;
    public TextMeshPro tmp;
    private GameObject monster_1;
	// Use this for initialization
	void Start () {
        monster_1 = Resources.Load("MonsterPrefabs/Monster_1") as GameObject;
        StartCoroutine(Awaking());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //虫洞的倒计时
    IEnumerator Awaking()
    {
        while (sleepTime > 0)
        {
            yield return new WaitForSeconds(1);
            sleepTime--;
            tmp.text = sleepTime.ToString();
            if (sleepTime <= 0)
            {
                //倒计时的时间和游戏进行时间有联系
                //取消倒计时的显示
                tmp.enabled = false;
                //生成怪物  需要一个Blast的效果
                GenreateMonster();
            }
        }
    }

    private void GenreateMonster()
    {
        GameObject monster = null;
        //ten for test
        for (int i = 0;i<10;i++)
        {
            GameObject go =  Instantiate(monster_1,transform.position,Quaternion.identity);
            //爆炸冲出效果
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-10,10), UnityEngine.Random.Range(-10,-20)));
        }
    }
}
