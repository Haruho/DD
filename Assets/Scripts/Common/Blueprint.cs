/// <summary>
/// 建筑和武器的类
/// </summary>
public class Blueprint
{
    /// <summary>
    /// 建造物的名称
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 建造物花费的木材
    /// </summary>
    public int woodExpend { get; set; }
    /// <summary>
    /// 建造物花费的金属
    /// </summary>
    public int metalExpend { get; set; }
    /// <summary>
    /// 建造物类型 1是建筑  2是武器
    /// </summary>
    public int type { get; set; }
    /// <summary>
    /// 建造物的数值  攻击力或者其他
    /// </summary>
    public float value { get; set; }
    /// <summary>
    /// 建造物的缩略图
    /// </summary>
    public string image { get;set; }
}