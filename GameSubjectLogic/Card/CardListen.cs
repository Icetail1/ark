using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class CardListen : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{

    int BossMask = 1 << 8;
    // 延迟时间
    private float delay = 0.2f;
    // 按钮是否是按下状态
    private bool isDown = false;
    // 按钮是否是弹起状态
    private bool isUp = false;
    // 按钮最后一次是被按住状态时候的时间
    private float lastIsDownTime;

    //检测鼠标是否在按钮中
    private bool IsInButton = false;

    public Vector3 offset;

    public Vector3 m_MousePos = Vector3.zero;

    float speed  = 6.0f;

    public CardDto Card;
    //储存tansform值
    public Vector3 OriPos;
    //储存Recttansform值
    public Vector3 OriPox;
    



    void Start()
    {

    }


    void Update()
    {

        if (isDown)
        {
            BossMask = LayerMask.GetMask("Boss");
            Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
            transform.position = m_MousePos;


           

        }
        

            
            
            //Debug.Log("hits.Length:"+hits.Length);
      
        
    }
    // 当按钮被按下后系统自动调用此方法
    //选中卡牌后
    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject.Find("Mannager").GetComponent<TeachMode_UI_Manager>().SetError("");
        OriPos = transform.position;
        Debug.Log("X!"+OriPos.x);
        OriPox = new Vector3(this.GetComponent<RectTransform>().anchoredPosition.x, this.GetComponent<RectTransform>().anchoredPosition.y,0);
        this.GetComponent<CardControllerer>().SetCardChoose();
        isDown = true;

    }
  
    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
        try { 
       if(PlayManager.Instance.turnCost >= CardManagement.Instance.NowChooseCard.Cost) { 
        if (CardManagement.Instance.NowChooseCard.CardID == 1
        || CardManagement.Instance.NowChooseCard.CardID == 2
        || CardManagement.Instance.NowChooseCard.CardID == 3
        || CardManagement.Instance.NowChooseCard.CardID == 10
        || CardManagement.Instance.NowChooseCard.CardID == 14)
        {
            //检测到第一个物体  Raycastall则是所有
            RaycastHit rh = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out rh, 100f, 1 << 0))
            {
                Debug.Log("碰撞体的名字：" + rh.collider.name);
                if (rh.collider.name == "boss")
                {
                        Debug.Log("comein2");
                        rh.collider.gameObject.GetComponent<Lucyfa>().CardOnthis(CardManagement.Instance.NowChooseCard);
                        ResetPosition();
                        this.GetComponent<RectTransform>().DOAnchorPos3D(new Vector3(-296f, -115f, 0), 0.05f).OnComplete(() => GameObject.Destroy(this.gameObject));
                        if (!CardManagement.Instance.isDisappear)
                        {
                            CardManagement.Instance.CardToLoseList.Add(CardManagement.Instance.NowChooseCard.CardID - 1);
                            
                        }
                        CardManagement.Instance.isDisappear = false;
                        //消耗费用
                        PlayManager.Instance.turnCost = PlayManager.Instance.turnCost - CardManagement.Instance.NowChooseCard.Cost;
                            //移除打出的卡
                            try { 
                        CardManagement.Instance.AlreadyInHand.Remove(CardManagement.Instance.NowChooseCard.CardID-1);
                                if (GameObject.Find("boss").GetComponent<Lucyfa>().Present_HP<=0)
                                {
                                    Time.timeScale = 0;
                                    Cursor.visible = false;
                                    throw new CustomException("胜利！");
                                }
                            }catch(CustomException ex)
                            {
                                GameObject.Find("Mannager").GetComponent<TeachMode_UI_Manager>().SetError(ex.Message);
                            }
                                //当前手牌数-1
                        CardManagement.Instance.AlreadySumThisTurnDrugNum--;
                        Debug.Log("notInhand" + (CardManagement.Instance.NowChooseCard.CardID - 1));

                    ;

                }
            }else
            {
                transform.position = OriPos;
            }
                }
                else
                {
                    if (Input.mousePosition.y > 220)
                    {
                        CardManagement.Instance.UndemageCard(CardManagement.Instance.NowChooseCard);

                        if (CardManagement.Instance.NowChooseCard.CardID != 11)
                        {
                            this.GetComponent<RectTransform>().DOAnchorPos3D(new Vector3(-296f, -115f, 0), 0.05f).OnComplete(() => GameObject.Destroy(this.gameObject));
                            ResetPosition();
                            if (!CardManagement.Instance.isDisappear)
                            {
                                CardManagement.Instance.CardToLoseList.Add(CardManagement.Instance.NowChooseCard.CardID - 1);

                            }
                            CardManagement.Instance.isDisappear = false;
                            
                            //消耗费用
                            PlayManager.Instance.turnCost = PlayManager.Instance.turnCost - CardManagement.Instance.NowChooseCard.Cost;
                            //移除打出的卡
                            CardManagement.Instance.AlreadyInHand.Remove(CardManagement.Instance.NowChooseCard.CardID - 1);
                            //当前手牌数-1
                            CardManagement.Instance.AlreadySumThisTurnDrugNum--;
                            Debug.Log("notInhand" + (CardManagement.Instance.NowChooseCard.CardID - 1));
                        }
                        else
                        {

                            transform.position = OriPos;
                        }

                    }
                    else
                    {
                        transform.position = OriPos;
                    }
                }
            }
            else
            {
                transform.position = OriPos;
                throw new CustomException("费用不够！");
            }
        }catch(CustomException cusEx)
        {
            GameObject.Find("Mannager").GetComponent<TeachMode_UI_Manager>().SetError(cusEx.Message);
        }
       
    }

    // 当鼠标从按钮上离开的时候自动调用此方法
    public void OnPointerExit(PointerEventData eventData)
    {
        //this.GetComponent<Transform>().SetSiblingIndex(0);

        IsInButton = false;
        if (!isDown)
        {
            this.GetComponent<Transform>().DOScale(new Vector3(1, 1, 1), 0.01f);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Transform>().SetSiblingIndex(18);

        IsInButton = true;
        this.GetComponent<Transform>().DOScale(new Vector3(1.5f, 1.5f, 1), 0.01f);


    }
    private void ResetPosition()
    {
        for (int i = 0; i < GameObject.Find("CardArea").transform.childCount; i++)
        {
            RectTransform child = (RectTransform)GameObject.Find("CardArea").transform.GetChild(i);
           if(child.anchoredPosition.x > OriPox.x)
            {
                child.anchoredPosition = new Vector3(child.anchoredPosition.x -60, child.anchoredPosition.y,0);
            }
        }
    }
    private void checkPosition()
    {
        //check y -3.3f +3.3f
        //check x -1.9f +1.9f
        Vector3 pos = transform.position;
        float x = pos.x;
        float y = pos.y;
        if (y < -3.3f)
        {
            y = -3.3f;
        }
        if (y > 3.3f)
        {
            y = 3.3f;
        }
        if (x < -1.9f)
        {
            x = -1.9f;
        }
        if (x > 1.9f)
        {
            x = 1.9f;
        }
        transform.position = new Vector3(x, y, 0);
    }

}