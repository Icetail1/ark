public class CardDto
{
    //card背景图片
    public int ImageIndex;
    //card类型
    public enum CardType { BaseCard, SkillCard };
    //判断当前何种卡牌
    public CardType whichCard;
    //card名字
    public string cardTitle = "";
    //card介绍
    public string cardIntro = "";
    //用一个ID来设计卡牌的功能（抽象事件牌技能）
    public int CardID;

    public int Cost;

    public CardDto(CardType Type, string CardTitle, string CardIntro, int CardID,int Cost)
    {


        this.cardTitle = CardTitle;
        this.cardIntro = CardIntro;
        this.whichCard = Type;
        this.CardID = CardID;
        this.Cost = Cost;
        if (Type == CardType.BaseCard)
        {

            ImageIndex = 0;
        }
        if (Type == CardType.SkillCard)
        {

            ImageIndex = 1;
        }
    }


}