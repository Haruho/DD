using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 场景管理器
/// </summary>
public class SceneController : MonoBehaviour {
    public static SceneController instance;
    void Awake()
    {
        instance = this;
    }
    /// <summary>
    /// 前往游戏开始界面
    /// </summary>
    public void ToStart()
    {
        SceneManager.LoadScene(1);
    }
    //返回初始界面
    public void ToArchive()
    {
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// 前往准备界面
    /// </summary>
    public void ToPrepare()
    {
        SceneManager.LoadScene(2);
    }
    /// <summary>
    /// 前往游戏界面
    /// </summary>
    public void ToGame()
    {
        SceneManager.LoadScene(3);
    }
}
