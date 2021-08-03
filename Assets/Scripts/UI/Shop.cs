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
        }
        else
        {
            NoCoins.SetTrigger("NoCoins");
            Debug.Log("pobre");
        }
        
    }
}
