using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DD.UI
{
    /// <summary>
    /// 挂载该脚本的Object下的自物资数量应该是Blueprint数量
    /// </summary>
    public class ItemSelect : MonoBehaviour
    {
        public Transform selectPointer;
        private List<Transform> itemList = new List<Transform>();
        private int listIndex;
        private List<Blueprint> blueprint;
        private GameObject itemPrefab;
        // Use this for initialization
        void Start()
        {
            //获取Item的预设体
            itemPrefab = Resources.Load("Prefabs/UIPrefabs/Item") as GameObject;
            //获取所有蓝图信息 创建所有item的UI
            blueprint = ReadBlueprintData.instance.GetOwnBlueprint(Prepare.filename);
            for(int i =0;i<blueprint.Count;i++){
                GameObject itemTemp = Instantiate(itemPrefab);
                itemTemp.transform.SetParent(transform,false);
                itemTemp.name =  blueprint[i].name;
                itemTemp.GetComponentInChildren<Text>().text = "Wood Cost:" + blueprint[i].woodExpend.ToString() + "\n" + "Metal Cost:"+blueprint[i].metalExpend.ToString();
                itemList.Add(itemTemp.transform);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) && listIndex < itemList.Count-1)
                {
                    listIndex++;
                    selectPointer.GetComponent<RectTransform>().anchoredPosition += new Vector2(95, 0);
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow)&& listIndex > 0)
                {
                    listIndex--;
                    selectPointer.GetComponent<RectTransform>().anchoredPosition += new Vector2(-95, 0);
                }
                selectPointer.SetParent(itemList[listIndex], false);
                selectPointer.GetComponent<RectTransform>().anchoredPosition = new Vector2(76.8f,-170f);
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                listIndex = 0;
                print(selectPointer.parent.name);
                selectPointer.SetParent(itemList[listIndex],false);
                selectPointer.GetComponent<RectTransform>().anchoredPosition = new Vector2(-100, -170f);
                selectPointer.SetParent(GameObject.Find("Canvas").transform,false);
                transform.GetComponent<Animator>().Play("ItemPanleAnimation_back");
            }
        }
    }
}
