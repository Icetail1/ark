using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardManagement : Singleton<CardManager>
{
    [SerializeField]
    private GameObject CardPrefeb;//持有卡牌Prefab


    //判断卡组中已有卡牌的信息

    // 总共有多少张卡牌
    public int sumCardNum = 15;
    //总共抽多少张卡牌
    public int sumDrugNum = 5;
    //还剩多少张卡牌
    public int remainCardNum;
    //基础牌数量
    private int baseCardNum;
    //技能卡数量
    private int skillCardNum;
    
    public Card[] preSkillType;

    public Card[] preEnventType;
    //所有卡牌存放的地方
    public Card[] cardGroup;

    //用来抽牌的列表
    public List<int> CardToDrugList;
    //用来弃牌的列表
    public List<Card> CardToLoseList;
    
    public AudioSource DrawCardAuido;
    
    public GameObject CardToSeePrefab;
    //用来存储卡牌序号
    List<int> listNewCard ;
    //TODO  
    //添加新卡牌的方法
    public bool isInitNewCard=false;
    public bool isMouseAleardyDown=false;
    void Start()
    {
        listNewCard = new List<int>(20);
        CardToLoseList = new List<Card>(100);

        ReStartCardList();
        //InitlistNewCard();
        isInitNewCard = false;
        isMouseAleardyDown = false;
    }

public void SkillCardInformation()
    {

        preEnventType = new Card[1000];
        preSkillType = new Card[1000];
        
        preSkillType[0] = new Card(Card.CardType.SkillCard, "一键背水", "使当前生命值变为1，背水效果翻倍，本回合无敌", 1);

        preSkillType[1] = new Card(Card.CardType.SkillCard, "利刃附魔", "使所有基础攻击牌获得背水1", 2);

        preSkillType[2] = new Card(Card.CardType.SkillCard, "嘲讽", "获得10+"+playermanager.instance.Defend+"点防御力，当前cut值翻倍", 3);
    
        preSkillType[3] = new Card(Card.CardType.SkillCard, "突刺", "消耗50%当前生命值（"+playermanager.instance.persent_HP*0.5+"），造成3倍已消耗生命值的伤害", 4);

        preSkillType[4] = new Card(Card.CardType.SkillCard, "生命分流", "消耗2点生命值,抽一张牌，回响", 5);

        preSkillType[5] = new Card(Card.CardType.SkillCard, "战吼", "本场战斗生命上限翻倍(当前生命值不会受到影响)", 6);

        preSkillType[6] = new Card(Card.CardType.SkillCard, "生命吸取", "获得吸血1", 3, 7);

        preSkillType[7] = new Card(Card.CardType.SkillCard, "包扎", "消耗<color=yellow>6</color>点怒气,恢复<color=red>20</color>点生命值", 0, 9);

        preSkillType[8] = new Card(Card.CardType.SkillCard, "包扎", "消耗<color=yellow>6</color>点怒气,恢复<color=red>20</color>点生命值", 0, 9);
      

    }

    public void CreatOriginalCardGroup(PlayManager.HeroCareer heroCareer)
    {
        //TODO
        //根据传入的不同职业生成不同的初始卡组

        CardGroup = new Card[200];
        if (heroCareer == PlayManager.HeroCareer.Warrior)
        {
            for (int i = 0; i < 8; i++)
            {
                CardGroup[i] = new Card(Card.CardType.AtkCard, "打击", "对目标造成<color=red>3(+ATK)</color>点伤害,获得<color=yellow>3</color>点怒气", 3, 0);
            }
            for (int i = 0; i < 5; i++)
            {
                CardGroup[i + 8] = preSkillType[i];
            }
            CardGroup[13] = preEnventType[2];
        }
        else if (heroCareer == PlayManager.HeroCareer.Master)
        {



        }
        else if (heroCareer == PlayManager.HeroCareer.Warrior)
        {



        }


    }
    public void InitlistNewCard()
    {
        for (int j = 5; j < 8; j++)
        {
            listNewCard.Add(j);
        }
    }


  
    /// <summary>
    /// 
    /// </summary>
    public void AddaNewCardToGroup()
    {
        InitlistNewCard();
        int i= Random.Range(0,listNewCard.Count);

        ReStartCardList();

        CardToDrugList.Add(HowManyCard++);
        Debug.Log("preSkillType[listNewCard[i]]:"+listNewCard[i]);
        CardGroup[HowManyCard-1] = preSkillType[listNewCard[i]];
        listNewCard.Remove(listNewCard[i]);
    }

    public void CreatCardPrefeb()
    {
        //抽牌
        if (HowManyCardRemain >= HowManytoDrug)
        {

            DrugCard();
        }
        else
        {
            //洗牌
            ReStartCardList();
           // HowManyCardRemain = HowManyCard;
            ReStartLoseCardList();
            DrugCard();
        }
    }

    /// <summary>
    /// 满足条件时抽上限牌数
    /// </summary>
    private void DrugCard()
    {
        for (int i = 0; i < HowManytoDrug; i++)
        {
            //随机数j
            int j = Random.Range(0, CardToDrugList.Count);
            //List中的第j+1个元素对应的值 (j+1)
            CreatCard(i, CardToDrugList[j]);
            //剩余卡牌数-1
            HowManyCardRemain--;
            //从抽牌List中移除掉这张牌
            CardToDrugList.Remove(CardToDrugList[j]);



        }
        DrawCardAuido.Play();
    }

    public void CreatCard(int i, int Rand)
    {
        //实例化Prefab,实例化时CardInstance调用Start()函数生成文字信息，SetImage生成图片信息
        GameObject Card = GameObject.Instantiate(CardPrefeb, Vector3.zero, Quaternion.identity);
        //SendMessage给预物体的脚本，完成更换贴图以及具化卡牌的功能  
        Card.GetComponent<CardInstance>().SetCard((CardGroup[Rand]));
        //设置卡牌底图
        Card.GetComponent<CardInstance>().SetImage(CardGroup[Rand].ImageIndex);
        //Card.GetComponent<CardInstance>().SetAtk(CardGroup[Rand].Demage);
        
        Card.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
        Card.GetComponent<RectTransform>().DOAnchorPos3D(new Vector3(-340 + i * 180, -240, 0), 3f);
        Card.GetComponent<Transform>().SetSiblingIndex(0);
    }

    /// <summary>
    /// 洗牌后重置列表用于抽牌
    /// </summary>
    private void ReStartCardList()
    {
        remainCardNum = sumCardNum;
        //清空已有的LIST
        CardToDrugList.Clear();

        for (int i = 0; i < HowManyCard; i++)
        {
            CardToDrugList.Add(i);
        }

            GameObject.Find("Event").GetComponent<MainSceneEvent>().HowManyCardHadUsed = 0;

    }


    /// <summary>
    ///只有打出牌和弃牌的时候 添加到弃牌List中 
    /// </summary>
    public void AddCardToLoseCardList(Card loseCard)
    {
        CardToLoseList.Add(loseCard);
    }

    private void ReStartLoseCardList()
    {
        if(CardToLoseList.Count>0)
        {
            CardToLoseList.Clear();
        }
        
    }



}
