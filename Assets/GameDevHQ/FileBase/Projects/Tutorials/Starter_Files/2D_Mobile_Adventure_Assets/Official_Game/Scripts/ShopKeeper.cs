using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;

    private Player _playerScript;
    public int currentSelectedItem = 0;
    public int currentItemCost = 200;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _shopPanel.SetActive(true);
            _playerScript = other.GetComponent<Player>();

            if(_playerScript != null)
            {
                UIManager.Instance.OpenShop(_playerScript.gems);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        //0 = Flame Sword
        //1 = Boots of FLight
        //2 = Key to Castle

        switch(item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(62);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-42);
                currentSelectedItem = 0;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-155);
                currentSelectedItem = 0;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if(_playerScript.gems > currentItemCost)
        {
            //reward
            if(currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }

            Debug.Log("Purchased " + currentSelectedItem);
            _playerScript.gems -= currentItemCost;
            Debug.Log("Remaining Gems: " + _playerScript.gems);

        }
        else
        {
            Debug.Log("You do not have enough gems. Closing shop");
            _shopPanel.SetActive(false);
        }
        //check if player has enough gems, if they do, minus gems and give item, else close shop
    }
}
