﻿/// <summary>
/// Player类
/// author : chill
/// </summary>
public class Player{
    /// <summary>
    /// 体力属性
    /// </summary>
    public int Vit { get; set; }
    /// <summary>
    /// 速度属性
    /// </summary>
    public int Speed { get; set; }
    /// <summary>
    /// 智力属性
    /// </summary>
    public int Wit { get; set; }

    private int maxBatteryAmount = 3;
    /// <summary>
    /// 携带电池的最大数量，默认是3
    /// </summary>
    public int MaxBatteryAmount
    {
        get
        {
            return maxBatteryAmount;
        }
        set
        {
            maxBatteryAmount = value;
        }
    }
}
