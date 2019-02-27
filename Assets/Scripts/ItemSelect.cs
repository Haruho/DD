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
        // Use this for initialization
        void Start()
        {
            for (int i = 0;i<transform.childCount;i++)
            {
                itemList.Add(transform.GetChild(i));
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
                selectPointer.SetParent(GameObject.Find("Canvas").transform,false);
                selectPointer.GetComponent<RectTransform>().anchoredPosition = new Vector2(-100, -170f);
            }
        }
    }
}
