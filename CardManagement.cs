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
    public int SumCardNum = 15;
    //总共抽多少张卡牌
    public int SumDrugNum = 5;
    //已经抽了多少张卡牌
    public int AlreadyDrugNum = 0;
    
    
    //还剩多少张卡牌
    public int RemainCardNum;
    //基础牌数量
    private int BaseCardNum;
    //技能卡数量
    private int SkillCardNum;
    
    
    
    public Card[] preSkillType;

    public Card[] preBaseType;
    //所有卡牌存放的地方
    public Card[] cardGroup;

    //用来抽牌的列表
    public List<int> cardToDrugList;
    public List<int> AlreadyInHand;
    //消失牌表
    public List<int> DisappearCard;
    //用来弃牌的列表
    public List<Card> cardToLoseList;
    

    public GameObject cardToSeePrefab;
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

        preSkillType = new Card[1000];
        preBaseType = new Card[1000];
        
        preSkillType[0] = new Card(Card.CardType.SkillCard, "一键背水", "使当前生命值变为1，背水效果翻倍，本回合无敌", 1);

        preSkillType[1] = new Card(Card.CardType.SkillCard, "利刃附魔", "使所有基础攻击牌获得背水1", 2);

        preSkillType[2] = new Card(Card.CardType.SkillCard, "嘲讽", "获得10+"+playermanager.instance.Defend+"点防御力，当前cut值翻倍", 3);
    
        preSkillType[3] = new Card(Card.CardType.SkillCard, "突刺", "消耗50%当前生命值（"+playermanager.instance.persent_HP*0.5+"），造成3倍已消耗生命值的伤害", 4);

        preSkillType[4] = new Card(Card.CardType.SkillCard, "生命分流", "消耗2点生命值,抽一张牌，回响", 5);

        preSkillType[5] = new Card(Card.CardType.SkillCard, "战吼", "本场战斗生命上限翻倍(当前生命值不会受到影响)", 6);

        preSkillType[6] = new Card(Card.CardType.SkillCard, "生命吸取", "获得吸血1", 7);

        preSkillType[7] = new Card(Card.CardType.SkillCard, "破釜沉舟", "造成9次背水效果的伤害，回合结束后即死", 8);

        preSkillType[8] = new Card(Card.CardType.SkillCard, "融合", "这张卡牌获得你所有基础卡的效果以及其附加武器效果", 9);
      
        preBaseType[0] = new Card(Card.CardType.SkillCard, "暗属性攻击", "造成5点伤害/n "+"todo 附加效果/n"+"todo 武器效果/n", 10);
        
        preBaseType[1] = new Card(Card.CardType.SkillCard, "暗属性攻击", "造成5点伤害/n "+"todo 附加效果/n"+"todo 武器效果/n", 11);
        
        preBaseType[2] = new Card(Card.CardType.SkillCard, "暗属性攻击", "造成5点伤害/n "+"todo 附加效果/n"+"todo 武器效果/n", 12);
        
        preBaseType[3] = new Card(Card.CardType.SkillCard, "防御", "获得5点护甲/n "+"todo 附加效果/n"+"todo 武器效果/n", 13);
        
        preBaseType[4] = new Card(Card.CardType.SkillCard, "防御", "获得5点护甲/n "+"todo 附加效果/n"+"todo 武器效果/n", 14);
        
        preBaseType[5] = new Card(Card.CardType.SkillCard, "防御", "获得5点护甲/n "+"todo 附加效果/n"+"todo 武器效果/n", 15);
        
        
        
    }

    public void CreatOriginalCardGroup(PlayManager.HeroCareer heroCareer)
    {
        //TODO
        //根据传入的不同职业生成不同的初始卡组

        CardGroup = new Card[200];
        if (heroCareer == PlayManager.HeroCareer.Warrior)
        {
            for (int i = 0; i < 6; i++)
            {
                CardGroup[i] = preBaseType[i]；
            }
            for (int i = 0; i < 9; i++)
            {
                CardGroup[i + 6] = preSkillType[i];
            }
        }
        else if (heroCareer == PlayManager.HeroCareer.Master)
        {



        }
        else if (heroCareer == PlayManager.HeroCareer.Warrior)
        {



        }


    }
// todo 增加卡牌
//     public void InitlistNewCard()
//     {
//         for (int j = 5; j < 8; j++)
//         {
//             listNewCard.Add(j);
//         }
//     }


  
//     /// <summary>
//     /// 
//     /// </summary>
//     public void AddaNewCardToGroup()
//     {
//         InitlistNewCard();
//         int i= Random.Range(0,listNewCard.Count);

//         ReStartCardList();

//         CardToDrugList.Add(HowManyCard++);
//         Debug.Log("preSkillType[listNewCard[i]]:"+listNewCard[i]);
//         CardGroup[HowManyCard-1] = preSkillType[listNewCard[i]];
//         listNewCard.Remove(listNewCard[i]);
//     }

    public void CreatCardPrefeb()
    {
        //抽牌
        if (RemainCardNum!=0)
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
    for(AlreadyDrugNum=0;AlreadyDrugNum< SumDrugNum;AlreadyDrugNum++){
        if(RemainCardNum!=0)
        {
            //随机数j
            int j = Random.Range(0, CardToDrugList.Count);
            //List中的第j+1个元素对应的值 (j+1)
            CreatCard(i, CardToDrugList[j]);
            //剩余卡牌数-1
            RemainCardNum--;
            //从抽牌List中移除掉这张牌
            CardToDrugList.Remove(CardToDrugList[j]);
            AlreadyInHand.add(j)
        }else
        {
        ReStartCardList();
        ReStartLoseCardList();
        int j = Random.Range(0, CardToDrugList.Count);
         //List中的第j+1个元素对应的值 (j+1)
            CreatCard(i, CardToDrugList[j]);
            //剩余卡牌数-1
            RemainCardNum--;
            //从抽牌List中移除掉这张牌
            CardToDrugList.Remove(CardToDrugList[j]);
            AlreadyInHand.add(j)
        
        }
        }
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
        RemainCardNum = SumCardNum - AlreadyDrugNum;
        //清空已有的LIST
        CardToDrugList.Clear();

        for (int i = 0; i < SumCardNum; i++)
        {
            CardToDrugList.Add(i);
        }
        for (int j = 0; j < AlreadyDrugNum; j++)
        {
            CardToDrugList.remove(AlreadyInHand[j]);
        }
        for (int h = 0; h < DisappearCard.count; h++)
        {
            CardToDrugList.remove(AlreadyInHand[h]);
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
    private void UndemageCard(CardDto card)
    {
           switch(card.CardID)
            {
            case 1:     
            PlayYiJianBeiShui(); 
            break;
            
            case 2:
            PlayLiRenFuMo(); 
            break;
            
            case 3:
            PlayGuard(); 
            break;
            
            case 5:
            PlayShengMingFenLiu(); 
            break;
            
            case 6:           
            PlayZhanhou();
            break;

            case 7:           
            PlayShengMingXiQu();
            break;
            
            case 9:           
            PlayYuGo();
            break;
            
            case 13:           
            PlayDefence_1();
            break;
            
            case 14:           
            PlayDefence_2();
            break;
            
            case 15:           
            PlayDefence_3();
            break;
            }
    }
    private void　PlayYiJianBeiShui()
    {
     PlayerManager.Instance.persent_HP = 1;
     PlayerManager.Instance.IsWuDi = true;
     BuffManager.Instance.BattleBeiShui=BuffManager.Instance.BattleBeiShui*2;
    
    }
    private void　PlayLiRenFuMo()
    {
    WeaponManager.Instance.ATK1_weapon =WeaponManager.Instance.preWeaponSet[0];
    WeaponManager.Instance.ATK2_weapon =WeaponManager.Instance.preWeaponSet[0];
    WeaponManager.Instance.ATK3_weapon =WeaponManager.Instance.preWeaponSet[0];
    DisappearCard.Add(2);
    }
    

}
