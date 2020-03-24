using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponManagement : Singleton<WeaponManagement>
{
    //预制武器信息
    public WeaponDto[]  preWeaponSet;
    


    //TODO  
    //添加新卡牌的方法
    void Start()
    {
        preWeaponSet = new WeaponDto[100];
        preWeaponSet[0] = new WeaponDto(WeaponDto.Weapons.ATK, "仇闪", "额外造成当前背水值的伤害", 1);

        preWeaponSet[1] = new WeaponDto(WeaponDto.Weapons.Defence, "椰子树", "额外获得50cut", 2);

    }
    
    public WeaponDto ATK1_weapon= preWeaponSet[0];
    public bool WeaponIsOnATK1 = true;
    public WeaponDto ATK2_weapon= preWeaponSet[0];
    public bool WeaponIsOnATK2 = true;
    public WeaponDto ATK3_weapon= preWeaponSet[0];
    public bool WeaponIsOnATK3 = true;
    public WeaponDto Defence1_weapon =preWeaponSet[1];
    public bool WeaponIsOnDefence1 = true;
    public WeaponDto Defence2_weapon =preWeaponSet[1];
    public bool WeaponIsOnDefence2 = true;
    public WeaponDto Defence3_weapon =preWeaponSet[1];
    public bool WeaponIsOnDefence3 = true;




}
