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
            //GameObject fistItem = Instantiate(itemPrefab);
            //fistItem.transform.SetParent(transform,false);
            //fistItem.name = "空手";
            //fistItem.GetComponentInChildren<Text>().text = "切换回空手";
            //fistItem.GetComponent<ItemTypeInstance>().type = 0;
            //itemList.Add(fistItem.transform);
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                selectPointer.GetComponent<RectTransform>().anchoredPosition = new Vector2(60, -140);
            }
            //打开item菜单
            if (Input.GetKey(KeyCode.F))
            {
                //指针变换父物体  方便获取选择的item
                selectPointer.SetParent(itemList[listIndex], false);
                //选择操作
                if (Input.GetKeyDown(KeyCode.RightArrow) && listIndex < itemList.Count-1)
                {
                    //索引
                    listIndex++;
                    //指针位置
                    selectPointer.GetComponent<RectTransform>().anchoredPosition = new Vector2(60,-140);
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow)&& listIndex > 0)
                {
                    listIndex--;
                    selectPointer.GetComponent<RectTransform>().anchoredPosition = new Vector2(60,-140);
                }
            }
            //释放选择建的时候代表选择完成
            if (Input.GetKeyUp(KeyCode.F))
            {
                //重置索引
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
                //指针位置变换隐藏
                selectPointer.GetComponent<RectTransform>().anchoredPosition = new Vector2(-100, -170f);
                //重置
                selectPointer.SetParent(GameObject.Find("Canvas").transform,false);
                //item窗口动画
                transform.GetComponent<Animator>().Play("ItemPanleAnimation_back");

                //触发制作行为
                
            }
        }
    }
}
