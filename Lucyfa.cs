using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BehaviorDesigner.Runtime;
using System;
using UnityEngine.UI;

public class Lucyfa : MonoBehaviour
{
    public int HP = 10000;
    public int Present_HP = 10000;
    [SerializeField]
    private Text ShowHP;//
    [SerializeField]
    private Text ShowPresent_HP;//


    void Start()
    {
      ShowHP.text = HP.ToString();
      ShowPresent_HP.text =ShowPresent_HP.ToString();
    }


    private void Update()
    {
    
    }

    public void CardOnthis(Card card)
    {

            if (card.CardID == 4)
            {
            PlayTsukiSasu(); 
            }
            if (card.CardID == 8)
            {
            PlayPoFuChenZhou(); 
            }
            if (card.CardID == 10)
            {
            PlayAtk_1(); 
            }
            if (card.CardID == 11)
            {
            PlayAtk_2(); 
            }
            if (card.CardID == 12)
            {
            PlayAtk_3; 
            }
      
    }
    public void PlayTsukiSasu()
    {
      Present_HP = Present_HP - (playermanager.instance.persent_HP * 0.5 * 3);
      playermanager.instance.persent_HP = playermanager.instance.persent_HP * 0.5;
      UIUpdate();
    }
    public void PlayPoFuChenZhou()
    {
      Present_HP = Present_HP - (Buffmanager.instance.BattleBeiShui * (Present_HP-playermanager.instance.persent_HP)*9);
      playermanager.instance.turnoverdie = true;
      UIUpdate();
    }
    public void PlayAtk_1()
    {
      Present_HP = Present_HP - (playermanager.instance.persent_HP * 0.5 * 3);
      playermanager.instance.persent_HP = playermanager.instance.persent_HP * 0.5;
      UIUpdate();
    }
    public void PlayAtk_2()
    {
      Present_HP = Present_HP - (playermanager.instance.persent_HP * 0.5 * 3);
      playermanager.instance.persent_HP = playermanager.instance.persent_HP * 0.5;
      UIUpdate();
    }
    public void PlayAtk_3()
    {
      Present_HP = Present_HP - (playermanager.instance.persent_HP * 0.5 * 3);
      playermanager.instance.persent_HP = playermanager.instance.persent_HP * 0.5;
      UIUpdate();
    }
    public void UIUpdate()
    {
      ShowHP.text = HP.ToString();
      ShowPresent_HP.text =ShowPresent_HP.ToString();
    }
}
