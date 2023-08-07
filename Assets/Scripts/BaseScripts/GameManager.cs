using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.SceneManagement;
using Plugins;
using UnityEngine.UI;
public class GameManager : BaseSingleton<GameManager>
{
    public GameObject Boiiler;

    [Title("Rope Alignment Values")]
    public RopeAlignmentScriptible AlignmentScriptible;

    [Title("Image Values")]
    public Sprite SockImage;
    public Sprite BraImage;
    public Image DressImage;

    [Title("Dress Aligment Values")]
    public DressListScriptible DressListScriptible;

    [Title("Money Values")]
    public double Money;
    public TextMeshProUGUI MoneyText;
    public int PlusesMoney;

    [Title("WishList List Values")]
    public List<WishListScriptible> WishList = new List<WishListScriptible>();
    public int WishListIndex;
    public List<BoilerDressColorController> dressColorControllers = new List<BoilerDressColorController>();
    public List<GameObject> Lists = new List<GameObject>();

    [Title("Win Values")]
    public GameObject WinPanel;
    public int DayNumber;
    public TextMeshProUGUI DayNumberText;

    [Title("Boiler Price Values")]
    public int BoilerPrice;
    public TextMeshProUGUI BoilerPriceText;
    public GameObject Boiler;

    private void Awake()
    {
        GetAligmentScriptibleOneClear();
        GetDressScriptibleOneClear();
        for (int i = 0; i < dressColorControllers.Count; i++)
        {
            dressColorControllers[i].WishListScriptible = WishList[WishListIndex];
            for (int j = 0; j < Lists.Count; j++)
            {
                Lists[j].gameObject.SetActive(false);
            }
            Lists[WishListIndex].gameObject.SetActive(true);
        }
        WishListIndex++;
    }

    private void Update()
    {
        MoneyText.text = MathUtils.FormatNumber(Money);
        BoilerPriceText.text = MathUtils.FormatNumber(BoilerPrice);
        DayNumberText.text = DayNumber.ToString();
    }

    private void GetAligmentScriptibleOneClear()
    {
        AlignmentScriptible.RopeList.Clear();
        AlignmentScriptible.RopePos = GameObject.FindWithTag("RopePos");
        AlignmentScriptible.ListIndex = 0;
        AlignmentScriptible.RopeList.Add(AlignmentScriptible.RopePos.transform);
    }

    private void GetDressScriptibleOneClear()
    {
        DressListScriptible.DressList.Clear();
        DressListScriptible.DressPos = GameObject.FindWithTag("DressPos");
        DressListScriptible.DressList.Add(DressListScriptible.DressPos.transform);
    }

    public void AddWishListMoney()
    {
        PlusesMoney = 200;
        Money += PlusesMoney;
    }

    public void AddMoney()
    {
        PlusesMoney = 100;
        Money += PlusesMoney;
    }

    public void GetWishListWin()
    {
        for (int i = 0; i < dressColorControllers.Count; i++)
        {
            dressColorControllers[i].WishListScriptible = WishList[WishListIndex];
            for (int j = 1; j < Lists.Count; j++)
            {
                Lists[j].gameObject.SetActive(false);
            }
            Lists[WishListIndex].gameObject.SetActive(true);
        }

        WishListIndex++;

        if (WishListIndex == WishList.Count)
        {
            WishListIndex = 0;
        }

        DayNumber++;
        WinPanel.gameObject.SetActive(false);
    }


    public void GetActiveWinPanel()
    {
        WinPanel.SetActive(true);
    }

    public void GetBuyBoiler()
    {
        if (Money >= BoilerPrice)
        {
            Money -= BoilerPrice;
            Boiler.GetComponent<BoxCollider>().enabled = true;
            Boiler.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
            Debug.Log("Buy");
        }
    }
}
