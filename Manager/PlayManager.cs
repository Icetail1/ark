using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayManager : Singleton<PlayManager> {
    [HideInInspector]
    public int HP;//最大生命值
    public int limit_MP;//最大MP
    public int persent_HP;//当前生命值
    public int persent_MP;//当前MP
    public int Attack;//攻击力
    public int Defence;//防御力
    public int Point;
    public int HPPoint;
    public Text Hptext;
    public Text PhpText;
    public Text DefenceText;
    public Text Cost;
    public bool IsWuDi;
    public bool turnoverdie;
    public int limitCost;
    public int turnCost;
    //职业
    public enum HeroCareer { Warrior,Master,Hunter};
    public HeroCareer IsInHeroCareer;
    

    private void Start()
    {
        HP = 100;
        limit_MP = 0;
        limitCost = 5;
        turnCost = limitCost;
        persent_HP = 100;
        persent_MP = 0;
        Attack = 1;
        Defence = 0;
        Point = 2;
        HPPoint = 10;
        Hptext.text = HP.ToString();
        PhpText.text = persent_HP.ToString();
        DefenceText.text = Defence.ToString();
        Cost.text = turnCost.ToString();
    }

    private void Update()
    {
        Hptext.text= HP.ToString();
        PhpText.text = persent_HP.ToString();
        DefenceText.text = Defence.ToString();
        Cost.text = turnCost.ToString();
    }




}
