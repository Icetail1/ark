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
            switch(card.CardID)
            {
            case 4:     
            PlayTsukiSasu(); 
            break;
            
            case 8:
            PlayPoFuChenZhou(); 
            break;
            
            case 10:
            PlayAtk_1(); 
            break;
            
            case 11:
            PlayAtk_2(); 
            break;
            
            case 12:           
            PlayAtk_3();
            break;

            }
    }
    public void PlayTsukiSasu()
    {
      float Demage = playermanager.instance.persent_HP * 0.5 * 3;
      Present_HP = Present_HP - Demage;
      playermanager.instance.persent_HP = playermanager.instance.persent_HP * 0.5 + Buffmanager.instance.BattleXiXue * Demage;
      UIUpdate();
    }
    public void PlayPoFuChenZhou()
    {
      float Demage = (Buffmanager.instance.BattleBeiShui) * (playermanager.instance.HP-playermanager.instance.persent_HP)*9
      Present_HP =(int)(Present_HP - Demage) ;
      playermanager.instance.persent_HP =playermanager.instance.persent_HP + Buffmanager.instance.BattleXiXue * Demage ;
      playermanager.instance.turnoverdie = true;
      UIUpdate();
    }
    public void PlayAtk_1()
    {

    }
    public void PlayAtk_2()
    {

    }
    public void PlayAtk_3()
    {

    }
    public void UIUpdate()
    {
      ShowHP.text = HP.ToString();
      ShowPresent_HP.text =ShowPresent_HP.ToString();
    }
}
