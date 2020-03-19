public class CardDto
{
    //card背景图片
    public int imageIndex;
    //card类型
    public enum CardType { baseCard, skillCard }; 
    //判断当前何种卡牌
    public CardType whichCard;  
    //card名字
    public string cardTitle = "";
    //card介绍
    public string cardIntro = "";
    //用一个ID来设计卡牌的功能（抽象事件牌技能）
    public int cardID;

    public Card(CardType type, string cardTitle, string cardIntro, int cardID)
    {


        this.cardTitle = cardTitle;
        this.cardIntro = cardIntro;
        this.whichCard = type;
        this.cardID = cardID;
        if (type == CardType.baseCard)
        {

            ImageIndex = 0;
        }
        if (type == CardType.skillCard)
        {

            ImageIndex = 1;
        }
    }


}
