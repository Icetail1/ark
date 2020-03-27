using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class LucyfaAtk : Conditional
{

    public GameObject Lucyfa;

    public override void OnStart()
    {
        Lucyfa = GameObject.Find("boss");
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        Lucyfa.GetComponent<Lucyfa>().ATTKa();
        UIManager.Instance.isTurnOver = false;
        Lucyfa.GetComponent<Lucyfa>().ATK = Random.Range(1, 20);
        PlayManager.Instance.turnCost = PlayManager.Instance.limitCost;
        PlayManager.Instance.Defence = 0;
        BuffManager.Instance.Cut = 0;
        return TaskStatus.Success;


    }
}