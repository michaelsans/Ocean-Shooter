using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [System.Serializable] public class ShopItem
    {
        public Sprite image;
        public int price;
        public bool isPurchased;
    }

    [SerializeField] public List<ShopItem> ShopItemsList;
    [SerializeField] Animator NoCoins;

    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;

    Button buyBtn;

    void Start()
    {
        SetShop();
    }
    private void Update()
    {
        if(PlayerManager.playerManagerInstance.levelLoaded)
        {
            for (int i = 0; i <= 9; i++)
            {
                ShopItemsList[i].isPurchased = PlayerManager.playerManagerInstance.updateItemPurchased[i];
                buyBtn = ShopScrollView.GetChild(i).GetChild(2).GetComponent<Button>();
                buyBtn.interactable = !ShopItemsList[i].isPurchased;
                if(ShopItemsList[i].isPurchased)
                    buyBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Purchased";
                else
                    buyBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Buy";
            }
            
            PlayerManager.playerManagerInstance.levelLoaded = false;
        }

    }
    public void SetShop()
    {
        PlayerManager.playerManagerInstance.LoadPlayer();
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        int len = ShopItemsList.Count;

        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].image;
            g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ShopItemsList[i].price.ToString();

            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            buyBtn.interactable = !ShopItemsList[i].isPurchased;
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);

        }

        Destroy(ItemTemplate);
    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        if(PlayerManager.playerManagerInstance.HasEnoughMoney(ShopItemsList[itemIndex].price))
        {
            PlayerManager.playerManagerInstance.UseMoney(ShopItemsList[itemIndex].price);
            ShopItemsList[itemIndex].isPurchased = true;

            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            buyBtn.interactable = false;
            buyBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Purchased";
            PlayerManager.playerManagerInstance.updateItemPurchased[itemIndex] = ShopItemsList[itemIndex].isPurchased;
        }
        else
        {
            NoCoins.SetTrigger("NoCoins");
            Debug.Log("pobre");
        }
    }
}
