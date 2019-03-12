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
            //测试用判断空引用
            if(Prepare.filename == null){
                blueprint = new List<Blueprint>();
            }else{
                blueprint = ReadBlueprintData.instance.GetOwnBlueprint(Prepare.filename);
            }
            //添加空手Item  置于首位
            GameObject fistItem = Instantiate(itemPrefab);
            fistItem.transform.SetParent(transform,false);
            fistItem.name = "空手";
            fistItem.GetComponentInChildren<Text>().text = "切换回空手";
            fistItem.GetComponent<ItemTypeInstance>().type = 0;
            itemList.Add(fistItem.transform);
            for(int i =0;i<blueprint.Count;i++){
                //实例化Item菜单
                GameObject itemTemp = Instantiate(itemPrefab);
                itemTemp.transform.SetParent(transform,false);
                itemTemp.name =  blueprint[i].name;
                //图片
                itemTemp.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImage/" + blueprint[i].image);
                //item类型赋值
                itemTemp.GetComponent<ItemTypeInstance>().type = blueprint[i].type;
                //item耗费Text
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
                //生成装备图片  触发攻击功能
                //非空手的情况下触发
                if (selectPointer.GetComponentInParent<ItemTypeInstance>().type == 2)
                {
                    PlayerAttack.isCanAttack = true;
                }
                else
                {
                    PlayerAttack.isCanAttack = false;
                }
                selectPointer.SetParent(itemList[listIndex],false);
                selectPointer.GetComponent<RectTransform>().anchoredPosition = new Vector2(-100, -170f);
                selectPointer.SetParent(GameObject.Find("Canvas").transform,false);
                transform.GetComponent<Animator>().Play("ItemPanleAnimation_back");
            }
        }
    }
}
