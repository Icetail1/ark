﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class CardControllerer : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    //获取图片组件，设置图片  
    public Image image;
    //获取Prefab上绑定过的指定的图片
    public Sprite[] img;
    public Sprite[] smallImg;

    public int ImageIndex;
    public int demage;
    public CardDto.CardType whichCard;
    public CardDto Card;
    bool isGroupAtk;

    public Text title;


    public Image SmallImage;

    public int CardID;


    public void Start()
    {

        Invoke("SetInfo", 0);
    }
    ////设置卡牌标题与信息
    // 当鼠标从按钮上离开的时候自动调用此方法
    public void OnPointerExit(PointerEventData eventData)
    {

        GameObject.Find("CardInfo").GetComponent<Text>().text = "";

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        CardManagement.Instance.UpdateCardIntro(Card);
        GameObject.Find("CardInfo").GetComponent<Text>().text = Card.cardIntro;
    }
    public void SetCardChoose()
    {
        CardManagement.Instance.NowChooseCard = this.Card;
    }


    private void SetInfo()
    {
        title.text = Card.cardTitle;
    }

    /// <summary>
    /// 设置卡牌图片 
    /// </summary>
    /// <param name="index"></param>
    public void SetImage(int index)
    {

        ImageIndex = index;
        image.sprite = img[index];
        //Debug.Log(card.CardID);

        switch (Card.CardID)
        {
            case 0:
                SmallImage.sprite = smallImg[0];
                break;
            case 1:
                SmallImage.sprite = smallImg[1];
                break;
            case 2:
                SmallImage.sprite = smallImg[2];
                break;
            case 3:
                SmallImage.sprite = smallImg[3];
                break;
            case 4:
                SmallImage.sprite = smallImg[4];
                break;
            case 5:
                SmallImage.sprite = smallImg[5];
                break;
            case 6:
                SmallImage.sprite = smallImg[6];
                break;
            case 7:
                SmallImage.sprite = smallImg[7];
                break;
            case 8:
                SmallImage.sprite = smallImg[8];
                break;
            case 9:
                SmallImage.sprite = smallImg[9];
                break;
            case 10:
                SmallImage.sprite = smallImg[10];
                break;
            case 11:
                SmallImage.sprite = smallImg[11];
                break;
            case 12:
                SmallImage.sprite = smallImg[12];
                break;
            case 13:
                SmallImage.sprite = smallImg[13];
                break;
            case 14:
                SmallImage.sprite = smallImg[14];
                break;
            case 15:
                SmallImage.sprite = smallImg[10];
                break;
        }
    }




  /*  public void SetCurChooseCardToEvent()
    {

        GameObject.FindGameObjectWithTag("Event").GetComponent<MainSceneEvent>().NowChooseCard = card;



    }
    */
    public void SetCard(CardDto card)
    {



        this.Card= card;


    }


    public void SetIntro(string Intro)
    {
        // CardIntro.text=Intro;
    }

    //以后补充各种set
    //...

    //小兵承受伤害

    public void DoEffect()
    {


    }
    public void DoDemage()
    {



    }

}