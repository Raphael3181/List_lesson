using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BaitItem : MonoBehaviour
{
    public SpriteAtlas baits_atlas;
    public Sprite silver, gold;
    public Text baitName, price, amount;
    public Image baitImage, priceImage;

    public void LoadInfo(BaitsInfo baitsInfo)
    {
        baitName.text = Localization.GetString("Baits", "price" + baitsInfo.id);
        price.text = baitsInfo.price.ToString();
        amount.text = $"Кол-во: {baitsInfo.amount}";
        baitImage.sprite = baits_atlas.GetSprite(baitsInfo.id.ToString());
        if (baitsInfo.gold)
        {
            priceImage.sprite = gold;
        }
        else
        {
            priceImage.sprite = silver;
        }
    }
}
