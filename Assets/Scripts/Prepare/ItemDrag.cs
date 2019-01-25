using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 实现UI的拖拽效果
/// </summary>
public class ItemDrag : MonoBehaviour{
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DragImg()
    {
        transform.GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
    }
}
