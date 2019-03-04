using UnityEngine;
using System.IO;
using LitJson;
using System.Text;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
/// <summary>
/// 存档操作
/// </summary>
public class ArchiveOperate : MonoBehaviour {
    //实例化的存档按钮
    private GameObject archiveBtn;
    //存档按钮的父物体
    private Transform abtnParent;

    // Use this for initialization
    void Start () {
        archiveBtn = (GameObject)Resources.Load("Prefabs/A");
        abtnParent = GameObject.Find("Canvas/ArchiveChoose").transform;
    }
    /// <summary>
    /// 游戏开始按钮  触发游戏读档
    /// </summary>
    public void StartGame()
    {
        //先创建3个存档按钮
        CreateArchiveButton();
    }
    /// <summary>
    /// 创建存档按钮 数量3
    /// </summary>
    void CreateArchiveButton()
    {
        //实例化三个存档按钮
        for (int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(archiveBtn);
            //更改按钮的名称  按钮名称和存档文件命名一样
            go.transform.name = "A" + (i + 1).ToString();
            go.transform.SetParent(abtnParent, false);
        }
    }
    /// <summary>
    /// 读取存档并应用
    /// </summary>
    public static void ReadDataByNumber(string archivePath)
    {
        string data = File.ReadAllText(archivePath,Encoding.UTF8);
        //player类和其他声明区分开
        JsonData jsondata = JsonMapper.ToObject(data);
        JsonData playerjsondata = jsondata["player"];
        //存档类实例
        Archive archive = new Archive();
        archive.currentHealthy = (int)jsondata["currentHealthy"];
        //测试用存档路径
        archive.ArchiveNameForTesting = archivePath;
        //玩家类实例
        Player player = new Player();
        archive.player = player;
        player.MaxBatteryAmount = (int)playerjsondata["MaxBatteryAmount"];
        player.Speed = (int)playerjsondata["Speed"];
        player.Wit = (int)playerjsondata["Wit"];
        player.Vit = (int)playerjsondata["Vit"];
        //给存档单例赋值
        Archive.SetInstance(archive);
    }
    //加密存档
    void SecurityData(){

    }
    /// <summary>
    /// 创建存档  新建
    /// </summary>
    public void CreateGameData(string filename)
    {
        Archive archive = new Archive();
        archive.player = new Player();
        //初次创建存档，给player赋值  339 是新建数据
        archive.player.Wit = 3;
        archive.player.Vit = 3;
        archive.player.Speed = 9;
        //把数据写入
        string jsonstr = JsonMapper.ToJson(archive);
        CreateDataFile(jsonstr,filename);
        Archive.SetInstance(archive);
    }
    /// <summary>
    /// 创建新的游戏存档
    /// </summary>
    /// <param name="data">data</param>
    void CreateDataFile(string data,string filename)
    {
        //存档地址
        string path = Application.dataPath + "/Archive/" + filename;
        if (!File.Exists(path))
        {
            FileStream fileStream = new FileStream(path,FileMode.OpenOrCreate ,FileAccess.Write,FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fileStream);
            sw.WriteLine(data);
            sw.Close();
            fileStream.Close();
            fileStream.Dispose();
        }
        else
        {
            print("FInd File");
        }
    }
}
