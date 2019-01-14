using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.GetComponent<Collider2D>().enabled = false;
        //开始随机移动
        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10,10),Random.Range(-10,10)));
        StartCoroutine(IngroneFirstFrame());
	}
	
	// Update is called once per frame
	void Update () {
        //直接通过刚体速度判断的话  物体开始运动速度也是0
    }
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            //判断满不满足加血条件
            if (GameSceneUIManager.currentBatteryAmount < player.transform.GetComponent<PlayerInstance>().cplayer.MaxBatteryAmount)
            {
                GameSceneUIManager.instance.AddBattery(player.transform.GetComponent<PlayerInstance>().cplayer.MaxBatteryAmount);
                Destroy(gameObject);
            }
            else
            {
                print("Full Health");
            }
        }
    }
    IEnumerator IngroneFirstFrame()
    {
        yield return new WaitForSeconds(1);
        transform.GetComponent<Collider2D>().enabled = true;
    }
}
