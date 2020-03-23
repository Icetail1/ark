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
      
    }
    public void PlayTsukiSasu()
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
