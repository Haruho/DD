using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 场景管理器
/// </summary>
public class SceneController : MonoBehaviour {
    public void ToMain()
    {
        SceneManager.LoadScene(1);
    }
    //返回初始界面
    public void ToStart()
    {
        SceneManager.LoadScene(0);
    }
}
