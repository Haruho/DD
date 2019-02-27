using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gate的实例
/// </summary>
public class GateInstance : MonoBehaviour {
    //Gate类型
    private GateType type;
    // private Collider2D m_collider;

    //private SpriteRenderer m_sr;
	// Use this for initialization
	void Start () {
        // m_collider = transform.GetComponent<Collider2D>();
        // m_sr = transform.GetComponent<SpriteRenderer>();
      //  gateGuise = Resources.Load<Sprite>("battery");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //碰到玩家触发Gate
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            ConfirmGateType();
        }
    }
    void ConfirmGateType()
    { 
        //根据随机数确定概率
        float rate = Random.value;
        if (rate < 0.25f)
        {
            type = GateType.altar;
          //  print("altar");
        }
        else if (rate>0.25f && rate < 0.75f)
        {
            type = GateType.battery;
           // print("battery");
        }
        else if (rate > 0.75f)
        {
            type = GateType.wormhole;
          //  print("Wormhole");
        }
        //单纯置换图片会导致功能混乱  选择实例化
        //获取图示 
        //GateClass gc = new GateClass();
        //m_sr.sprite = gc.ObjToSprite(type.ToString());
        ////触发之后就不会再次触发 电池除外
        //if (type == GateType.battery)
        //{
        //    transform.GetComponent<GateInstance>().enabled = false;
        //    transform.gameObject.AddComponent<BatteryBehaviour>();
        //}
        //else
        //{
        //    m_collider.enabled = false;
        //}
        //new一个gate会导致gates变量为空
        //实例化gate的结果
        //Instantiate(GateClass.instace.GateOpenResult(type),transform.position,Quaternion.identity);
        GameObject go = GateClass.instace.GateOpenResult(type);
        Instantiate(go, transform.position, Quaternion.identity);
        //删除触发Gate
        Destroy(this.gameObject);
    }
}
