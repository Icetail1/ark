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
    public int ATK;
    [SerializeField]
    private Text ShowHP;//
    [SerializeField]
    private Text ShowPresent_HP;//
    [SerializeField]
    private Text ShowATK;//


    void Start()
    {
        ShowHP.text = HP.ToString();
        ShowPresent_HP.text = Present_HP.ToString();
        ShowATK.text = ATK.ToString();
        ATK = 10;
    }


    private void Update()
    {
        UIUpdate();
    }

    public void CardOnthis(CardDto card)
    {
        switch (card.CardID)
        {
            case 10:
                PlayTsukiSasu();
                
                break;

            case 14:
                PlayPoFuChenZhou();
                break;

            case 1:
                PlayAtk_1();
                break;

            case 2:
                PlayAtk_2();
                break;

            case 3:
                PlayAtk_3();
                break;

        }
    }
    public void PlayTsukiSasu()
    {
        float Demage =PlayManager.Instance.persent_HP * 0.5f * 3f;
        Present_HP = (int)(Present_HP - Demage);
        //自身吸血
        PlayManager.Instance.persent_HP = (int)(PlayManager.Instance.persent_HP * 0.5 + BuffManager.Instance.BattleXiXue * Demage);
        UIUpdate();
    }
    public void PlayPoFuChenZhou()
    {
        float Demage = (BuffManager.Instance.BattleBeiShui) * (PlayManager.Instance.HP - PlayManager.Instance.persent_HP) * 9;
      Present_HP = (int)(Present_HP - Demage);
        //自身吸血
        PlayManager.Instance.persent_HP = (int)(PlayManager.Instance.persent_HP + BuffManager.Instance.BattleXiXue * Demage);
        //回合结束后死亡
        PlayManager.Instance.turnoverdie = true;
        UIUpdate();
    }
    public void PlayAtk_1()
    {
        float Demage = 0;
        //判断是否装备武器
        if (WeaponManagement.Instance.WeaponIsOnATK1)
        {
            switch (WeaponManagement.Instance.ATK1_weapon.weaponID)
            {
                case 1:
                    Demage = (BuffManager.Instance.BattleBeiShui) * (PlayManager.Instance.HP - PlayManager.Instance.persent_HP) + 5;
                    Debug.Log("demage" + Demage);
                    break;
   

            }
        }
        else
        {
            Demage = 5f;
        }

        Present_HP = (int)(Present_HP - Demage);
        //自身吸血
        PlayManager.Instance.persent_HP =(int)( PlayManager.Instance.persent_HP + BuffManager.Instance.BattleXiXue * Demage);
        UIUpdate();
    }
    public void PlayAtk_2()
    {
        float Demage =0;
        if (WeaponManagement.Instance.WeaponIsOnATK2)
        {
            switch (WeaponManagement.Instance.ATK2_weapon.weaponID)
            {
                case 1:
                    Demage = (BuffManager.Instance.BattleBeiShui) * (PlayManager.Instance.HP - PlayManager.Instance.persent_HP ) + 5;
                    Debug.Log("demage" + Demage);
                    break;

            }
        }
        else
        {
            Demage = 5f;
        }
        Present_HP = (int)(Present_HP - Demage);
        PlayManager.Instance.persent_HP = (int)(PlayManager.Instance.persent_HP + BuffManager.Instance.BattleXiXue * Demage) ;
        UIUpdate();
    }
    public void PlayAtk_3()
    {
        float Demage = 0;
        if (WeaponManagement.Instance.WeaponIsOnATK3)
        {
            switch (WeaponManagement.Instance.ATK3_weapon.weaponID)
            {
                case 1:
                    Demage = (BuffManager.Instance.BattleBeiShui) * (PlayManager.Instance.HP - PlayManager.Instance.persent_HP) + 5;
                    Debug.Log("demage"+Demage);
                    break;

            }
        }
        else
        {
            Demage = 5f;
        }
        Present_HP = (int)(Present_HP - Demage);
        PlayManager.Instance.persent_HP = (int)(PlayManager.Instance.persent_HP + BuffManager.Instance.BattleXiXue * Demage);
        UIUpdate();
    }
    public void ATTKa()
    {
        float Demage;

        Demage = ATK *(1- BuffManager.Instance.Cut) - PlayManager.Instance.Defence;
        Debug.Log("BuffManager" + BuffManager.Instance.Cut);
        Debug.Log("PlayManager" + PlayManager.Instance.Defence  );
        Debug.Log("@@@@" + Demage);
        try
        { if(Demage< PlayManager.Instance.persent_HP) { 

            if (Demage >= 0)
            {
                PlayManager.Instance.persent_HP = (int)(PlayManager.Instance.persent_HP - Demage);
            }
            }
            else
            {
                PlayManager.Instance.persent_HP = 0;
                Time.timeScale = 0;
                Cursor.visible = false;
                throw new CustomException("菜！！");
               
            }
        }catch(CustomException ex)
        {
            GameObject.Find("Mannager").GetComponent<TeachMode_UI_Manager>().SetError(ex.Message);
        }
        CardManagement.Instance.DrugCard();

    }
    public void UIUpdate()
    {
        ShowHP.text = HP.ToString();
        ShowPresent_HP.text = Present_HP.ToString();
        ShowATK.text = ATK.ToString();
    }
}