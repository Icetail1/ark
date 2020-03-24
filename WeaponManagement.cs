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
        preWeaponSet[0] = new WeaponDto(WeaponDto.Weapons.choushan, "仇闪", "背水1", 1);

        preWeaponSet[1] = new WeaponDto(WeaponDto.Weapons.yezishu, "椰子树", "获得50cut", 2);

    }
    
    public WeaponDto ATK1_weapon= preWeaponSet[0];
    public WeaponDto ATK2_weapon= preWeaponSet[0];
    public WeaponDto ATK3_weapon= preWeaponSet[0];
    public WeaponDto Defence1_weapon =preWeaponSet[1];
    public WeaponDto Defence2_weapon =preWeaponSet[1];
    public WeaponDto Defence3_weapon =preWeaponSet[1];



}
