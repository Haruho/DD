using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gate的实例
/// </summary>
public class GateInstance : MonoBehaviour {
    private GateType type;
    private Collider2D m_collider;

    private SpriteRenderer m_sr;
	// Use this for initialization
	void Start () {
        m_collider = transform.GetComponent<Collider2D>();
        m_sr = transform.GetComponent<SpriteRenderer>();
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
            print("altar");
        }
        else if (rate>0.25f && rate < 0.75f)
        {
            type = GateType.battery;
            print("battery");
        }
        else if (rate > 0.75f)
        {
            type = GateType.wormhole;
            print("Wormhole");
        }
        //获取图示
        GateClass gc = new GateClass();
        m_sr.sprite = gc.ObjToSprite(type.ToString());
        //触发之后就不会再次触发
        m_collider.enabled = false;
    }
}
