using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class TeachMode_UI_Manager : MonoBehaviour, IPointerDownHandler
{
    //Button列表
    //计数器
    public CanvasGroup canvasGroup;
    public CanvasGroup cG2;
    float value =1f;
    private int index = 0;
    private int num;
    public Text Textshow0;
    public Text Textshow1;
    public Text Textshow2;
    public Text Textshow3;
    public Text ErrorMessage;
    public string[] textshow;
    private int i = 0;
    public GameObject ControlColor2;
    float AlphaValue = 0.5F;
    public Image banner;
    [SerializeField]
    private Button BackpackOn;
    [SerializeField]
    private Button LossCardOn;
    [SerializeField]
    private Button EndTurn;
    [SerializeField]
    private Button StartTurn;
    [SerializeField]
    public GameObject Backpack;
    [SerializeField]
    public GameObject LossCardShow;


    private void Start()

    {
        BackpackOn.onClick.AddListener(BackpackOpen);
        LossCardOn.onClick.AddListener(LossCardOpen);
        EndTurn.onClick.AddListener(EndThisTurn);
        StartTurn.onClick.AddListener(StartThisTurn);
        cG2.alpha = 0.5f;
        Textshow0 = GameObject.Find("Text").GetComponent<Text>(); 
        Textshow1 = GameObject.Find("Text1").GetComponent<Text>(); 
        Textshow2 = GameObject.Find("Text2").GetComponent<Text>();
        Textshow3 = GameObject.Find("Text3").GetComponent<Text>(); 
        textshow = new string[4];
        textshow[0] = "欢迎来到教程，接下来为您介绍游戏界面及操作方法。\n" +
            "(点击继续)";
        textshow[1] = "这里是您现在所拥有的手牌，左边是固定武器防御卡，右边是技能卡。\n" +
            "(点击继续)";
        textshow[2] = "点击背包可以看到您现在所拥有的所有卡牌\n" +
            "(点击继续) ";
        textshow[3] = "点击弃牌堆可以看到您已经弃掉的卡牌\n" +
            "(点击继续) ";
        Invoke("ShowImg", 1f);


        //开始时刻的时间
        /* _time = Time.time;*/

        /* Invoke("ShowImg", 3f);*/
    }

    void ShowImg()
    {
        Textshow0.DOText(textshow[0], 1f).OnComplete(() => banner.gameObject.SetActive(false));

    }

    void ShowImg1()
    {
        
        Textshow1.DOText(textshow[1], 1f).OnComplete(() => banner.gameObject.SetActive(false));
        i++;

    }
    void ShowImg2()
    {
       
        Textshow2.DOText(textshow[2], 1f).OnComplete(() => banner.gameObject.SetActive(false));
        i++;

    }
    void ShowImg3()
    {
        
        Textshow3.DOText(textshow[3], 1f).OnComplete(() => banner.gameObject.SetActive(false));
        i++;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        banner.gameObject.SetActive(true);
        switch (i)
        {
            case 0:
                Textshow0.text = "";
                ShowImg1();
                break;
            case 1:
                Textshow1.text = "";
                ShowImg2();
                break;
            case 2:
                Textshow2.text = "";
                ShowImg3();
                break;

        }
    }
    private void BackpackOpen()
        {
        if (!UIManager.Instance.ifBackpackIsOpen){
            //实例化Prefab,实例化时CardControllerer调用Start()函数生成文字信息，SetImage生成图片信息
            GameObject BackpackCreate = GameObject.Instantiate(Backpack, new Vector3(693, 6, 0), Quaternion.identity);
            BackpackCreate.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
            BackpackCreate.GetComponent<RectTransform>().DOAnchorPos3D(new Vector3(9, -6, 0), 0.1f);
            BackpackCreate.GetComponent<Transform>().SetAsLastSibling();
            UIManager.Instance.ifBackpackIsOpen = true;
        }else{
            GameObject.Destroy(GameObject.Find("Backpack(Clone)"), 0);
            UIManager.Instance.ifBackpackIsOpen = false;
        }
    }
    private void LossCardOpen()
    {
        if (!UIManager.Instance.ifLossCardIsOpen)
        {
            //实例化Prefab,实例化时CardControllerer调用Start()函数生成文字信息，SetImage生成图片信息
            GameObject LossCardCreate = GameObject.Instantiate(LossCardShow, new Vector3(693, 6, 0), Quaternion.identity);
            LossCardCreate.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
            LossCardCreate.GetComponent<RectTransform>().DOAnchorPos3D(new Vector3(9, -6, 0), 0.1f);
            LossCardCreate.GetComponent<Transform>().SetAsLastSibling();
            UIManager.Instance.ifLossCardIsOpen = true;
        }
        else
        {
            GameObject.Destroy(GameObject.Find("LossCardShow(Clone)"), 0);
            UIManager.Instance.ifLossCardIsOpen = false;
        }
    }

    private void EndThisTurn()
    {
        for (int i = 0; i < GameObject.Find("CardArea").transform.childCount; i++)
        {
            RectTransform child = (RectTransform)GameObject.Find("CardArea").transform.GetChild(i);
            child.DOAnchorPos3D(new Vector3(-296, -115  , 0), 0.05f).OnComplete(() => GameObject.Destroy(child.gameObject));
   
                }
        for(int i = 0; i < CardManagement.Instance.AlreadyInHand.Count; i++) { 
        CardManagement.Instance.CardToLoseList.Add(CardManagement.Instance.AlreadyInHand[i]);
        }
        CardManagement.Instance.AlreadyInHand.Clear();
        
        CardManagement.Instance.AlreadySumThisTurnDrugNum = 0;      
        UIManager.Instance.isTurnOver = true;
       
        this.SetError("");
    }
    private void StartThisTurn()
    {
        CardManagement.Instance.DrugCard();
    }

    public void SetError(String str)
    {
        ErrorMessage.text = str;


    }

    void Update()
    {
  
    }
}
