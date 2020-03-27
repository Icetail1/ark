using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BuffManager : Singleton<BuffManager>
{
    // 全局背水buff
    public int SumBeiShui = 1;
    // 全局吸血buff
    public int SumXiXue = 0;
    // 战斗中背水buff
    public int BattleBeiShui = 1;
    // 战斗中吸血buff
    public int BattleXiXue = 0;
    // 战斗中Cut
    public float Cut = 0f;

    [SerializeField]
    private Text ShowBattleBeiShui;//
    [SerializeField]
    private Text ShowBattleXiXue;//

    [SerializeField]
    private Text ShowCut;//

    void Start()
    {
        BattleBeiShui = SumBeiShui;
        BattleXiXue = SumXiXue;
        ShowBattleBeiShui.text = BattleBeiShui.ToString();
        ShowBattleXiXue.text = BattleXiXue.ToString();
        ShowCut.text = Cut.ToString();
    }
    void Update()
    {
        ShowBattleBeiShui.text = BattleBeiShui.ToString();
        ShowBattleXiXue.text= BattleXiXue.ToString();
        ShowCut.text = Cut.ToString();
    }


}