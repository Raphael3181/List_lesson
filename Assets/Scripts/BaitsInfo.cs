public class BaitsInfo  //Шаблон поля для наживки
{
    public int id;
    public int price;
    public int amount;
    public bool gold;

    public BaitsInfo(int id, int price, int amount, bool gold)
    {
        this.id = id;
        this.price = price;
        this.amount = amount;
        this.gold = gold;
    }
}
