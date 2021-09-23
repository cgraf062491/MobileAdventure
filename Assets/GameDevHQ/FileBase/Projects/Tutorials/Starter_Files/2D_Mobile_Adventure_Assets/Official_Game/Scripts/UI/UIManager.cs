using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("The UIManager is Null");
            }
            return _instance;
        }
    }

    [SerializeField] private Text _playerGemCountText;
    [SerializeField] private Image _selectionImage;
    [SerializeField] private Text _GemCountText;
    [SerializeField] private GameObject[] lives;

    void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount)
    {
        _playerGemCountText.text = gemCount.ToString() + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        _selectionImage.rectTransform.anchoredPosition = new Vector2(_selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        _GemCountText.text = "" + count;
    }

    public void UpdateLives(int liveremaining)
    {
        lives[liveremaining].SetActive(false);
    }
}
