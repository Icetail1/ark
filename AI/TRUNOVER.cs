using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class TRUNOVER : Conditional
{


    public override TaskStatus OnUpdate()
    {
        if(UIManager.Instance.isTurnOver)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }


    }
}