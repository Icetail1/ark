using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LossCardShow_Manager : MonoBehaviour {
    //Button列表
    [SerializeField]
    private Button Close;

    [SerializeField]
    public GameObject Skillcard;
    /// <summary>
    /// 注册监听器
    /// </summary>

    private void Start()
    {
        for (int i = 0; i < CardManagement.Instance.CardToLoseList.Count; i++)
        {
            double gi = i / 3;
            float si = (float)(Math.Floor(gi));

            //实例化Prefab,实例化时CardControllerer调用Start()函数生成文字信息，SetImage生成图片信息
            GameObject Card = GameObject.Instantiate(Skillcard, Vector3.zero, Quaternion.identity);
            //SendMessage给预物体的脚本，完成更换贴图以及具化卡牌的功能 
            Card.GetComponent<CardListen>().enabled = false;
            Card.GetComponent<CardControllerer>().SetCard(CardManagement.Instance.CardGroup[CardManagement.Instance.CardToLoseList[i]]);
            //设置卡牌底图
            Card.GetComponent<CardControllerer>().SetImage(CardManagement.Instance.CardGroup[CardManagement.Instance.CardToLoseList[i]].ImageIndex);
            //Card.GetComponent<CardControllerer>().SetAtk(CardGroup[Rand].Demage);

            Card.GetComponent<Transform>().SetParent(GameObject.Find("LossCardImage").GetComponent<Transform>());
            Card.transform.localPosition = new Vector3(-130 + (i % 3) * 140, 430 - (si * 180), 0);

            Card.GetComponent<Transform>().SetSiblingIndex(0);
        }

        Close.onClick.AddListener(CloseLossCardShow);
       
    }


    private void OnDestroy()
    {
        Close.onClick.RemoveListener(CloseLossCardShow);
    } 

    private void CloseLossCardShow()
    {
            GameObject.Destroy(this.gameObject,0);
        UIManager.Instance.ifBackpackIsOpen = false;
    }
}
