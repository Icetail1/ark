using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardManagement : Singleton<CardManagement>
{
    [SerializeField]
    private GameObject SkillCard;//持有卡牌Prefab


    //判断卡组中已有卡牌的信息
    
    // 总共有多少张卡牌
    public int SumCardNum = 15;
    //总共抽多少张卡牌
    public int SumDrugNum = 7;
    //已经抽了多少张卡牌
    public int AlreadyDrugNum = 0;
    //已经一共抽了多少张卡牌
    public int AlreadySumDrugNum = 0;
    //已经一共抽了多少张卡牌
    public int AlreadySumThisTurnDrugNum = 0;
    //手牌上限
    public int LimitCardNum = 10;


    //还剩多少张卡牌
    public int RemainCardNum;
    //基础牌数量
    private int BaseCardNum;
    //技能卡数量
    private int SkillCardNum;



    public CardDto[] preSkillType;

    public CardDto[] preBaseType;
    //所有卡牌存放的地方
    public CardDto[] CardGroup;

    //用来抽牌的列表
    public List<int> CardToDrugList;
    public List<int> AlreadyInHand;
    public List<int> AlreadyDroped;
    public List<int> ThisTurnDroped;

    //用来弃牌的列表
    public List<int> CardToLoseList;


    public GameObject cardToSeePrefab;
    public CardDto NowChooseCard;

    //用来存储卡牌序号
    List<int> listNewCard;
    //TODO  
    //添加新卡牌的方法
    public bool isInitNewCard = false;
    public bool isMouseAleardyDown = false;
    //消失牌表
    public List<int> DisappearCard;
    public bool isDisappear;

    void Start()
    {
        CardGroup = new CardDto[1000];
        preSkillType = new CardDto[1000];
        preBaseType = new CardDto[1000];

        preSkillType[0] = new CardDto(CardDto.CardType.SkillCard, "一键背水", "使当前生命值变为1，背水效果翻倍，本回合无敌\n" + "COST:1",7, 1);

        preSkillType[1] = new CardDto(CardDto.CardType.SkillCard, "利刃附魔", "使所有基础攻击牌获得仇闪\n" + "COST:2", 8, 2);

        preSkillType[2] = new CardDto(CardDto.CardType.SkillCard, "嘲讽", "获得10点防御力，当前cut值翻倍\n" + "COST:3", 9, 3);

        preSkillType[3] = new CardDto(CardDto.CardType.SkillCard, "突刺", "消耗50%当前生命值（" + PlayManager.Instance.persent_HP * 0.5 + "），造成3倍已消耗生命值的伤害\n" + "COST:3", 10, 3);

        preSkillType[4] = new CardDto(CardDto.CardType.SkillCard, "生命分流", "消耗2点生命值,抽一张牌，回响\n" + "COST:0", 11, 0);

        preSkillType[5] = new CardDto(CardDto.CardType.SkillCard, "战吼", "本场战斗生命上限翻倍(当前生命值不会受到影响)\n" + "COST:5", 12, 5);

        preSkillType[6] = new CardDto(CardDto.CardType.SkillCard, "生命吸取", "获得吸血1\n" + "COST:2", 13, 2);

        preSkillType[7] = new CardDto(CardDto.CardType.SkillCard, "破釜沉舟", "造成9次背水效果的伤害，回合结束后即死\n" + "COST:3", 14, 3);

        preSkillType[8] = new CardDto(CardDto.CardType.SkillCard, "生命交换", "将自己的当前生命百分比与敌人相互转换，使用后移出卡组\n" + "COST:3",15, 3);
        if (WeaponManagement.Instance.WeaponIsOnATK1) {
            preBaseType[0] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + WeaponManagement.Instance.ATK1_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.ATK1_weapon.WeaponIntro + "\n" + "COST:1", 1, 1);
        }
        else
        {
            preBaseType[0] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 1, 1);

        }
        if (WeaponManagement.Instance.WeaponIsOnATK2)
        {
            preBaseType[1] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + WeaponManagement.Instance.ATK2_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.ATK2_weapon.WeaponIntro + "\n" + "COST:1", 2, 1);
        }
        else
        {
            preBaseType[1] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 2, 1);

        }
        if (WeaponManagement.Instance.WeaponIsOnATK2)
        {
            preBaseType[2] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + WeaponManagement.Instance.ATK3_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.ATK3_weapon.WeaponIntro + "\n" + "COST:1", 3, 1);
        } else
        {
            preBaseType[2] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 3, 1);

        }
        if (WeaponManagement.Instance.WeaponIsOnDefence1) {
            preBaseType[3] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + WeaponManagement.Instance.Defence1_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.Defence1_weapon.WeaponIntro + "\n" + "COST:1", 4, 1);
        }
        else
        {
            preBaseType[3] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 4, 1);

        }
        if (WeaponManagement.Instance.WeaponIsOnDefence2) {
            preBaseType[4] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + WeaponManagement.Instance.Defence2_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.Defence2_weapon.WeaponIntro + "\n" + "COST:1", 5, 1);
        }
        else
        {
            preBaseType[4] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 5, 1);

        }
        if (WeaponManagement.Instance.WeaponIsOnDefence3)
        {
            preBaseType[5] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + WeaponManagement.Instance.Defence3_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.Defence3_weapon.WeaponIntro + "\n" + "COST:1", 6, 1);
        }
        else
        {
            preBaseType[5] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 6, 1);

        }
    
            for (int i = 0; i < 6; i++)
            {
                CardGroup[i]= preBaseType[i];
        }
            for (int i = 0; i < 9; i++)
            {
                CardGroup[i+6]= preSkillType[i];
        }
            listNewCard = new List<int>(20);
        CardToLoseList = new List<int>(100);

        CardListSet();
        //InitlistNewCard();
        isInitNewCard = false;
        isMouseAleardyDown = false;
        CreatCardPrefeb();
    }

    public void SkillCardInformation()

    {

       


            
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

    //        ReStartCardList();

    //         CardToDrugList.Add(HowManyCard++);
    //         Debug.Log("preSkillType[listNewCard[i]]:"+listNewCard[i]);
    //         CardGroup[HowManyCard-1] = preSkillType[listNewCard[i]];
    //         listNewCard.Remove(listNewCard[i]);
    //     }

    public void CreatCardPrefeb()
    {
        //抽牌
        if (RemainCardNum != 0)
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
    public void DrugCard()
    {
        Debug.Log("loss" + CardToLoseList.Count);
        for (AlreadyDrugNum=0; AlreadyDrugNum < SumDrugNum; AlreadyDrugNum++)
        {
            try {
                if ((AlreadyInHand.Count + 1) > LimitCardNum)
                {
                   throw new CustomException("已经超出手牌上限");

                }
                if (RemainCardNum != 0)
                {
                    //随机数j
                    int j = Random.Range(0, CardToDrugList.Count);
                    if (CardToDrugList.Count > 0)
                    {
                        CreatCard(CardToDrugList[j]);
                        //剩余卡牌数-1
                        RemainCardNum--;
                        AlreadyInHand.Add(CardToDrugList[j]);
                        AlreadyDroped.Add(CardToDrugList[j]);
                        ThisTurnDroped.Add(CardToDrugList[j]);
                        //从抽牌List中移除掉这张牌
                        CardToDrugList.Remove(CardToDrugList[j]);

                        AlreadySumDrugNum++;
                        AlreadySumThisTurnDrugNum++;
                    }
                    else
                    {
                        GameObject.Find("Mannager").GetComponent<TeachMode_UI_Manager>().SetError("已经没有卡牌了！");
                    }

                }
                else
                {
                    AlreadyDroped = ThisTurnDroped.GetRange(0, ThisTurnDroped.Count);
                    ReStartCardList();
                    ReStartLoseCardList();
                    int j = Random.Range(0, CardToDrugList.Count);
                    //List中的第j+1个元素对应的值 (j+1)
                    if (CardToDrugList.Count > 0)
                    {
                        CreatCard(CardToDrugList[j]);
                        //剩余卡牌数-1
                        RemainCardNum--;
                        AlreadyInHand.Add(CardToDrugList[j]);
                        AlreadyDroped.Add(CardToDrugList[j]);
                        //从抽牌List中移除掉这张牌
                        CardToDrugList.Remove(CardToDrugList[j]);
                        AlreadySumDrugNum = AlreadyDrugNum;
                        AlreadySumDrugNum++;
                        AlreadySumThisTurnDrugNum++;
                        CardToLoseList.Clear();
                    }
                    else
                    {
                        throw new CustomException("已经没有卡牌了！！！");

                    }
                }



            }
            catch (CustomException cusEx) {
                GameObject.Find("Mannager").GetComponent<TeachMode_UI_Manager>().SetError(cusEx.Message);
            }
        }
        ThisTurnDroped.Clear();
    }

    public void CreatCard( int Rand)
    {
        //实例化Prefab,实例化时CardControllerer调用Start()函  数生成文字信息，SetImage生成图片信息
        GameObject Card = GameObject.Instantiate(SkillCard, new Vector3(692, 9, 0), Quaternion.identity);
        //SendMessage给预物体的脚本，完成更换贴图以及具化卡牌的功能  
        Card.GetComponent<CardControllerer>().SetCard((CardGroup[Rand]));
        //设置卡牌底图
        Card.GetComponent<CardControllerer>().SetImage(CardGroup[Rand].ImageIndex);
        //Card.GetComponent<CardControllerer>().SetAtk(CardGroup[Rand].Demage);

        Card.GetComponent<Transform>().SetParent(GameObject.Find("CardArea").GetComponent<Transform>());
      
        Card.GetComponent<RectTransform>().DOAnchorPos3D(new Vector3(-200 + (GameObject.Find("CardArea").transform.childCount-1) * 60, 0 , 0), 0.5f);

        Card.GetComponent<Transform>().SetAsLastSibling();
        Card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

    }
    private void CardListSet()
    {
        RemainCardNum = SumCardNum;
        //清空已有的LIST
        CardToDrugList.Clear();

        for (int i = 0; i < SumCardNum; i++)
        {
            CardToDrugList.Add(i);
        }

    }

    /// <summary>
    /// 洗牌后重置列表用于抽牌
    /// </summary>
    private void ReStartCardList()
    {
        RemainCardNum = CardToLoseList.Count - DisappearCard.Count;
       
        //清空已有的LIST
        CardToDrugList.Clear();

        for (int i = 0; i < CardToLoseList.Count; i++)
        {
            CardToDrugList.Add(CardToLoseList[i]);
        }
        Debug.Log("AlreadySumThisTurnDrugNum" + AlreadySumThisTurnDrugNum);
        for (int j = 0; j < AlreadySumThisTurnDrugNum; j++)
        {
            Debug.Log("AlreadyInHand" + AlreadyInHand[j]);
            CardToDrugList.Remove(AlreadyInHand[j]);
            
        }
        //    GameObject.Find("Event").GetComponent<MainSceneEvent>().HowManyCardHadUsed = 0;
      



    }

   

    private void ReStartLoseCardList()
    {
        if (CardToLoseList.Count > 0)
        {
            CardToLoseList.Clear();
        }

    }

    public void UndemageCard(CardDto card)
    {
        switch (card.CardID)
        {
            case 7:
                PlayYiJianBeiShui();
                break;

            case 8:
                PlayLiRenFuMo();
                break;

            case 9:
                PlayGuard();
                break;

            case 11:
                Invoke("PlayShengMingFenLiu",0.2f);
                break;

            case 12:
                PlayZhanhou();
                break;

            case 13:
                PlayShengMingXiQu();
                break;

            case 15:
                PlayExchange();
                break;

            case 4:
                PlayDefence_1();
                break;

            case 5:
                PlayDefence_2();
                break;

            case 6:
                PlayDefence_3();
                break;
        }
    }
    private void PlayYiJianBeiShui()
    {
        PlayManager.Instance.persent_HP = 1;
        PlayManager.Instance.IsWuDi = true;
        BuffManager.Instance.BattleBeiShui = BuffManager.Instance.BattleBeiShui * 2;

    }
    private void PlayLiRenFuMo()
    {
        WeaponManagement.Instance.WeaponIsOnATK1 = true;
        WeaponManagement.Instance.WeaponIsOnATK2 = true;
        WeaponManagement.Instance.WeaponIsOnATK3 = true;
        WeaponManagement.Instance.ATK1_weapon = WeaponManagement.Instance.preWeaponSet[0];
        WeaponManagement.Instance.ATK2_weapon = WeaponManagement.Instance.preWeaponSet[0];
        WeaponManagement.Instance.ATK3_weapon = WeaponManagement.Instance.preWeaponSet[0];
        isDisappear = true;
    }
    public void UpdateCardIntro(CardDto card)
    {
        card.cardIntro = CardGroup[card.CardID - 1].cardIntro;
    }
    private void PlayGuard()
    {
        PlayManager.Instance.Defence = PlayManager.Instance.Defence + 10;
        BuffManager.Instance.Cut = 0.5f;
    }
    private void PlayShengMingFenLiu()
    {//储存当前抽卡数
        int i = SumDrugNum;
        SumDrugNum = 1;
        this.DrugCard();
        PlayManager.Instance.persent_HP  = PlayManager.Instance.persent_HP - 2;
        SumDrugNum = i;
    }
    private void PlayZhanhou()
    {
        PlayManager.Instance.HP = PlayManager.Instance.HP * 2;
    }
    private void PlayShengMingXiQu()
    {
        BuffManager.Instance.BattleXiXue = BuffManager.Instance.BattleXiXue + 1;
    }
    private void PlayExchange()
    {
        float pacentP = (float)PlayManager.Instance.persent_HP / (float)PlayManager.Instance.HP;
        Debug.Log("pacentP" + pacentP);
        float pacentE = (float)GameObject.FindGameObjectWithTag("Lucyfa").GetComponent<Lucyfa>().Present_HP / (float)GameObject.FindGameObjectWithTag("Lucyfa").GetComponent<Lucyfa>().HP;
        Debug.Log("pacentE" + pacentE);

        GameObject.FindGameObjectWithTag("Lucyfa").GetComponent<Lucyfa>().Present_HP = (int)(GameObject.FindGameObjectWithTag("Lucyfa").GetComponent<Lucyfa>().HP * pacentP);
        PlayManager.Instance.persent_HP = (int)(PlayManager.Instance.HP * pacentE);
        isDisappear = true;

    }
    private void PlayDefence_1()
    {
        if (WeaponManagement.Instance.WeaponIsOnDefence1)
        {
            switch (WeaponManagement.Instance.Defence1_weapon.weaponID)
            {
                case 2:
                    BuffManager.Instance.Cut = 0.5f;
                    break;

            }
        }
        PlayManager.Instance.Defence = PlayManager.Instance.Defence + 5;

    }
    private void PlayDefence_2()
    {
        if (WeaponManagement.Instance.WeaponIsOnDefence2)
        {
            switch (WeaponManagement.Instance.Defence2_weapon.weaponID)
            {
                case 2:
                    BuffManager.Instance.Cut = 0.5f;
                    break;

            }
        }
        PlayManager.Instance.Defence = PlayManager.Instance.Defence + 5;
    }
    private void PlayDefence_3()
    {
        if (WeaponManagement.Instance.WeaponIsOnDefence3)
        {
            switch (WeaponManagement.Instance.Defence3_weapon.weaponID)
            {
                case 2:
                    BuffManager.Instance.Cut = 0.5f;
                    break;

            }
        }
        PlayManager.Instance.Defence = PlayManager.Instance.Defence + 5;
    }
    private void Update()
    {
        preSkillType[0] = new CardDto(CardDto.CardType.SkillCard, "一键背水", "使当前生命值变为1，背水效果翻倍，本回合无敌\n" + "COST:1", 7, 1);

        preSkillType[1] = new CardDto(CardDto.CardType.SkillCard, "利刃附魔", "使所有基础攻击牌获得仇闪\n" + "COST:2", 8, 2);

        preSkillType[2] = new CardDto(CardDto.CardType.SkillCard, "嘲讽", "获得10点防御力，当前cut值翻倍\n" + "COST:3", 9, 3);

        preSkillType[3] = new CardDto(CardDto.CardType.SkillCard, "突刺", "消耗50%当前生命值（" + PlayManager.Instance.persent_HP * 0.5 + "），造成3倍已消耗生命值的伤害\n" + "COST:3", 10, 3);

        preSkillType[4] = new CardDto(CardDto.CardType.SkillCard, "生命分流", "消耗2点生命值,抽一张牌，回响\n" + "COST:0", 11, 0);

        preSkillType[5] = new CardDto(CardDto.CardType.SkillCard, "战吼", "本场战斗生命上限翻倍(当前生命值不会受到影响)\n" + "COST:5", 12, 5);

        preSkillType[6] = new CardDto(CardDto.CardType.SkillCard, "生命吸取", "获得吸血1\n" + "COST:2", 13, 2);

        preSkillType[7] = new CardDto(CardDto.CardType.SkillCard, "破釜沉舟", "造成9次背水效果的伤害，回合结束后即死\n" + "COST:3", 14, 3);

        preSkillType[8] = new CardDto(CardDto.CardType.SkillCard, "生命交换", "将自己的当前生命百分比与敌人相互转换，使用后移出卡组\n" + "COST:3", 15, 3);
        if (WeaponManagement.Instance.WeaponIsOnATK1)
        {
            preBaseType[0] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + WeaponManagement.Instance.ATK1_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.ATK1_weapon.WeaponIntro + "\n" + "COST:1", 1, 1);
        }
        else
        {
            preBaseType[0] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 1, 1);

        }
        if (WeaponManagement.Instance.WeaponIsOnATK2)
        {
            preBaseType[1] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + WeaponManagement.Instance.ATK2_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.ATK2_weapon.WeaponIntro + "\n" + "COST:1", 2, 1);
        }
        else
        {
            preBaseType[1] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 2, 1);

        }
        if (WeaponManagement.Instance.WeaponIsOnATK2)
        {
            preBaseType[2] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + WeaponManagement.Instance.ATK3_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.ATK3_weapon.WeaponIntro + "\n" + "COST:1", 3, 1);
        }
        else
        {
            preBaseType[2] = new CardDto(CardDto.CardType.BaseCard, "暗属性攻击", "造成5点伤害\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 3, 1);

        }
        if (WeaponManagement.Instance.WeaponIsOnDefence1)
        {
            preBaseType[3] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + WeaponManagement.Instance.Defence1_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.Defence1_weapon.WeaponIntro + "\n" + "COST:1", 4, 1);
        }
        else
        {
            preBaseType[3] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 4, 1);

        }
        if (WeaponManagement.Instance.WeaponIsOnDefence2)
        {
            preBaseType[4] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + WeaponManagement.Instance.Defence2_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.Defence2_weapon.WeaponIntro + "\n" + "COST:1", 5, 1);
        }
        else
        {
            preBaseType[4] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 5, 1);

        }
        if (WeaponManagement.Instance.WeaponIsOnDefence3)
        {
            preBaseType[5] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + WeaponManagement.Instance.Defence3_weapon.WeaponTitle + "\n" + WeaponManagement.Instance.Defence3_weapon.WeaponIntro + "\n" + "COST:1", 6, 1);
        }
        else
        {
            preBaseType[5] = new CardDto(CardDto.CardType.BaseCard, "防御", "获得5点护甲\n" + "武器：\n" + "没有装备武器" + "\n" + "COST:1", 6, 1);

        }

        for (int i = 0; i < 6; i++)
        {
            CardGroup[i] = preBaseType[i];
        }
        for (int i = 0; i < 9; i++)
        {
            CardGroup[i + 6] = preSkillType[i];
        }
    }
}