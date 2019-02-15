using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesInstance : MonoBehaviour {
    public ResourcesType type;
    public float life;

    private Transform m_transform;
    private BoxCollider2D m_collider;
    private Animator anim;
    //金属碎片的预设提
    private GameObject metal_slice;
	// Use this for initialization
	void Start () {
        life = 100;
        m_transform = transform;
        m_collider = transform.GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        metal_slice = Resources.Load("ResourcesResidue/metal_slice") as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D player)
    {

        //确定Player
        if (player.tag == "Player")
        {
            if (life >=0)
            {
                player.GetComponent<PlayerInstance>().isCanGather = true;
                PlayerInstance.currentObj = gameObject;
            }
        }
    }
    void OnTriggerExit2D(Collider2D player)
    {
        //确定Player
        if (player.tag == "Player")
        {
            player.GetComponent<PlayerInstance>().isCanGather = false;
            PlayerInstance.currentObj = null;
            //life < 0  取消交互
            if (life <= 0)
            {
                //取消资源实例的交互
                m_collider.enabled = false;
                //播放取消动画
                anim.SetBool(type.ToString() + "_gf",true);
            }
        }
    }
    /// <summary>
    /// 金属收集完毕的行为
    /// </summary>
    public void MetalGatherFinish()
    {
        print("Metal Gather Finish Behaviour");
        for (int i =0;i<3; i++)
        {
            GameObject go = Instantiate(metal_slice,m_transform.position,Quaternion.identity);
            go.name = "metal_slice" + i.ToString();
            //赋予随机的力
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10,10),10));
        }
    }
    /// <summary>
    /// 树木收集完毕的行为
    /// </summary>
    public void WoodGatherFinish()
    {
        print("Wood Gather Finish Behaviour");
        m_transform.GetChild(0).gameObject.SetActive(true);
    }
}
