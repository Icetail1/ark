if(CardMannagement.Instance.NowChooseCard.CardID == 4 
|| CardMannagement.Instance.NowChooseCard.CardID == 8
|| CardMannagement.Instance.NowChooseCard.CardID == 10
|| CardMannagement.Instance.NowChooseCard.CardID == 11
|| CardMannagement.Instance.NowChooseCard.CardID == 12){
检测
if true→
(if name = boss CardOnthis
DO3d
movetolosscard=todo
destroy this card)else(
return to gameobject first place
)


}else(
if(Input.mousePosition.y>220)
{
UndemageCard
DO3d
movetolosscard=todo
destroy this card

}else(
return to gameobject first place
)
)
