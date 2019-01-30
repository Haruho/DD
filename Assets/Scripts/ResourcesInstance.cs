using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesInstance : MonoBehaviour {
    public ResourcesType type;
    public float life;

    private Transform m_transform;
    private BoxCollider2D m_collider;
    private Animator anim;
	// Use this for initialization
	void Start () {
        life = 100;
        m_transform = transform;
        m_collider = transform.GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
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
                anim.SetBool("gather_finish",true);
            }
        }
    }
}
