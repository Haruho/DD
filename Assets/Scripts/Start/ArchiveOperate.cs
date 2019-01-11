using UnityEngine;
using System.IO;
using LitJson;
using System.Text;
/// <summary>
/// 存档操作
/// </summary>
public class ArchiveOperate : MonoBehaviour {
    string datapath;
    // Use this for initialization
    void Start () {
        datapath = Application.dataPath + "/Resources/data.cd";
        CheakArchiveInstance();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 检查有没有存档
    /// </summary>
    void CheakArchiveInstance()
    {
        //存档地址
        string path = Application.dataPath + "/Resources/data.cd";
        if (File.Exists(path))
        {
            //读取存档
            ReadData();
        }
        else
        {
            //NEW DATA  序列化存档
            CreateGameData();
        }
    }
    /// <summary>
    /// 读取存档并应用
    /// </summary>
    void ReadData()
    {
        string data = File.ReadAllText(datapath,Encoding.UTF8);
        //player类和其他声明区分开
        JsonData jsondata = JsonMapper.ToObject(data);
        JsonData playerjsondata = jsondata["player"];
        //存档类实例
        Archive archive = new Archive();
        archive.currentHealthy = (int)jsondata["currentHealthy"];
        //玩家类实例
        Player player = new Player();
        archive.player = player;
        player.MaxBatteryAmount = (int)playerjsondata["MaxBatteryAmount"];
        player.Speed = (int)playerjsondata["Speed"];
        player.Wit = (int)playerjsondata["Wit"];
        player.Vit = (int)playerjsondata["Vit"];
        print(archive.currentHealthy);
        print("MaxBatteryAmount :" + archive.player.MaxBatteryAmount);
        print("Vit :" + archive.player.Vit);
        print("Speed :" + archive.player.Speed);
        print("Wit :" + archive.player.Wit);
        Archive.SetInstance(archive);
        //return archive;
    }
    /// <summary>
    /// 创建存档  覆盖
    /// </summary>
    void CreateGameData(Player player)
    {
        Archive archive = new Archive();
        archive.player = player;
        string jsonstr = JsonMapper.ToJson(archive);
        print("overwrite data :" + jsonstr);
    }
    /// <summary>
    /// 创建存档  新建
    /// </summary>
    void CreateGameData()
    {
        Archive archive = new Archive();
        archive.player = new Player();

        string jsonstr = JsonMapper.ToJson(archive);
        CreateDataFile(jsonstr);
        print("new data :" + jsonstr);
    }

    /// <summary>
    /// 加密存档  DES
    /// </summary>
    void EncryptionData(string edata,string ekey)
    {
        //缺省
    }
    void CreateDataFile(string data)
    {
        string path = Application.dataPath + "/Resources/data.cd";
        if (!File.Exists(path))
        {
            FileStream fileStream = new FileStream(path,FileMode.OpenOrCreate ,FileAccess.Write,FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fileStream);
            sw.WriteLine(data);
            sw.Close();
            fileStream.Close();
            fileStream.Dispose();
        }
    }
}
