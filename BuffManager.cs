using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuffManager : Singleton<CardManager>
{
    // 全局背水buff
    public int SumBeiShui = 0;
    // 全局吸血buff
    public int SumXiXue = 0;
    // 战斗中背水buff
    public int BattleBeiShui  = 0;
    // 战斗中吸血buff
    public int BattleXiXue  = 0;
    // 战斗中Cut
    public float BattleCut  = 0f;
    
    void Start()
    {
    BattleBeiShui +=  SumBeiShui;
    BattleXiXue += SumXiXue;
    }
    void update()
    {
    BattleBeiShui +=  SumBeiShui;
    BattleXiXue += SumXiXue;
    }
    

 }
