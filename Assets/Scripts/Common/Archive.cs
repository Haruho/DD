﻿/// <summary>
/// 玩家的存档类
/// </summary>
public class Archive{
    public static Archive archive = null;
    /// <summary>
    /// 当前的血量
    /// </summary>
    public int currentHealthy { get; set; }

    public Player player { get; set; }

    /// <summary>
    /// 读取完存档之后把数据传到这里
    /// </summary>
    /// <param name="archive"></param>
    public static void SetInstance(Archive dataarchive)
    {
        archive = dataarchive;
    }
    /// <summary>
    /// 初始化实例
    /// </summary>
    /// <returns></returns>
    public static Archive GetInstance()
    {
        if (archive == null)
        {
            return null;
        }
        return archive;
    }
}
