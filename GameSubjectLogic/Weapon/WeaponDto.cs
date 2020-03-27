public class WeaponDto
{
    //weapon图片
    public int imageIndex;
    //weapon类型
    public enum Weapons { ATK, Defence };
    //判断当前何种卡牌
    public Weapons whichWeapon;
    //weapon名字
    public string WeaponTitle = "";
    //weapon介绍
    public string WeaponIntro = "";
    //用一个ID来设计weapon的功能（抽象事件牌技能）
    public int weaponID;

    public WeaponDto(Weapons type, string WeaponTitle, string WeaponIntro, int weaponID)
    {


        this.WeaponTitle = WeaponTitle;
        this.WeaponIntro = WeaponIntro;
        this.whichWeapon = type;
        this.weaponID = weaponID;
        if (type == Weapons.ATK)
        {

            imageIndex = 0;
        }
        if (type == Weapons.Defence)
        {

            imageIndex = 1;
        }
    }


}