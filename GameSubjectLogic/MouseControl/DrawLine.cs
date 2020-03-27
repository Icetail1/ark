using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DrawLine : MonoBehaviour
{

    /// <summary>
    /// 直线渲染器
    /// </summary>



    LayerMask batmanGroupMask = 1 << 8;

    /// <summary>
    /// 是否第一次鼠标按下
    /// </summary>
    private bool firstMouseDown = false;

    /// <summary>
    /// 是否鼠标一直按下
    /// </summary>
    private bool mouseDown = false;
    private bool firstMouseUp = false;
    private void Start()
    {
        isCancelCardShow = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstMouseDown = true;
            mouseDown = true;
            firstMouseUp = false;
            //播放声音
            //audioSource.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            firstMouseUp = true;
        }

        onDrawLine();

        firstMouseDown = false;

    }


    /// <summary>
    /// 保存的所有坐标
    /// </summary>
    private Vector3[] positions = new Vector3[30];

    /// <summary>
    /// 当前保存的坐标数量
    /// </summary>
    private int posCount = 0;

    /// <summary>
    /// 代表这一帧鼠标的位置 就 头的坐标
    /// </summary>
    private Vector3 head;

    /// <summary>
    /// 代表上一帧鼠标的位置
    /// </summary>
    private Vector3 last;

    public GameObject CancelCard;
    private bool isCancelCardShow;
    /// <summary>
    /// 画线
    /// </summary>
    private void onDrawLine()
    {
            if (firstMouseUp)
            {

                    onRayCast(Input.mousePosition);
 
                

                firstMouseUp = false;
                isCancelCardShow = false;
            }



    }

    private void onRayCast(Vector3 worldPos)
    {
        //Debug.Log("worldPos:"+worldPos);
        Ray ray = Camera.main.ScreenPointToRay(worldPos);
        //检测到第一个物体  Raycastall则是所有
        RaycastHit[] hits = Physics.RaycastAll(ray);

        //Debug.Log("hits.Length:"+hits.Length);
        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log((hits[i].collider.name));

            switch (hits[i].collider.gameObject.tag) {
                case "Lucyfa":
                    if(CardManagement.Instance.NowChooseCard.CardID ==4)
                    {
                        hits[i].collider.gameObject.GetComponent<Lucyfa>().CardOnthis(CardManagement.Instance.NowChooseCard);
                    }
                    break;

                }
        //TODO 
        //hits[i].collider.gameObject.SendMessage("OnCut", SendMessageOptions.DontRequireReceiver);
        //这里写打击到的牌的事件功能
        //2018年7月17日13:35:41

    }

        //拖到空处 判断是否是AOE
        //选中挥斩卡牌
        //TODO
        //目前AOE一旦被选中就会触发，要添加取消出牌的功能
        if (Input.mousePosition.y > 220)
        {
           
        }


    }





    private void savePosition(Vector3 pos)
    {
        pos.z = 0;

        if (posCount <= 29)
        {
            for (int i = posCount; i <= 29; i++)
            {
                positions[i] = pos;
            }
        }
        else
        {
            for (int i = 0; i < 29; i++)
                positions[i] = positions[i + 1];

            positions[29] = pos;
        }
    }


   
}