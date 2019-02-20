using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour {
    public float speed;
    private Transform player;
    private Transform m_transform;
	// Use this for initialization
	void Start () {
        m_transform = transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(FollowPlayer());
    }
    IEnumerator FollowPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        //禁用刚体
        m_transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //跟随指令
        m_transform.Translate(player.position-m_transform.position * Time.deltaTime * speed);
    }
}
