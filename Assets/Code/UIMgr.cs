using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIMgr : MonoBehaviour {


    public GameObject PriceLabel;
    public GameObject Buttons;
    public Canvas SettingCanvas;
    public Text m_price;
    public Text m_money;
    public Text m_avg;
    public Text m_count;
    public CanvasGroup m_mask;

    // Use this for initialization
    void Start ()
    {

        m_mask = Buttons.GetComponent<CanvasGroup>();
        m_mask.blocksRaycasts = true;

        m_price = PriceLabel.transform.Find("curPrice/curPriceValue").GetComponent<Text>();
        m_money = PriceLabel.transform.Find("curMoney/curMoneyValue").GetComponent<Text>();
        m_avg = PriceLabel.transform.Find("avgPrice/avgPriceValue").GetComponent<Text>();
        m_count = PriceLabel.transform.Find("haveCount/haveCountValue").GetComponent<Text>();

        m_price.text = DataMgr.Instance().curprice.ToString("f2");
        m_money.text = DataMgr.Instance().curmoney.ToString("f2");
        m_avg.text = "0";
        m_count.text = "0";             

        Button m_buy = Buttons.transform.Find("BuyBtn/buy").GetComponent<Button>();
        Button m_buyAll = Buttons.transform.Find("BuyBtn/buyAll").GetComponent<Button>();
        Button m_sell = Buttons.transform.Find("SellBtn/sell").GetComponent<Button>();
        Button m_sellAll = Buttons.transform.Find("SellBtn/sellAll").GetComponent<Button>();
        Button m_setting = Buttons.transform.Find("SettingBtn").GetComponent<Button>();

        Button m_reset = SettingCanvas.transform.Find("SettingPanel/ResetBtn").GetComponent<Button>();
        Button m_quit = SettingCanvas.transform.Find("SettingPanel/QuitBtn").GetComponent<Button>();
        Button m_close = SettingCanvas.transform.Find("SettingPanel/CloseBtn").GetComponent<Button>();

        SettingCanvas.gameObject.SetActive(false);

        m_buy.onClick.AddListener(() => BtnBuyOnce());
        m_buyAll.onClick.AddListener(() => BtnBuyAll());
        m_sell.onClick.AddListener(() => BtnSellOnce());
        m_sellAll.onClick.AddListener(() => BtnSellAll());
        m_setting.onClick.AddListener(() => SwitchSettingPanel(true));
        m_reset.onClick.AddListener(() => SceneManager.LoadScene(2));
        m_close.onClick.AddListener(() => SwitchSettingPanel(false));
        m_quit.onClick.AddListener(() => SceneManager.LoadScene(0));


    }
	
    void SwitchSettingPanel(bool open)
    {
        SettingCanvas.gameObject.SetActive(open);
        m_mask.blocksRaycasts = !open  ;
    }
	// Update is called once per frame
    void BtnBuyOnce()
    {
        bool isall = false;
        DataMgr.Instance().BuyAction(isall);
        Debug.LogError("买一次");
    }
    void BtnBuyAll()
    {
        bool isall = true;
        DataMgr.Instance().BuyAction(isall);
        Debug.LogError("全买了！");
    }
    void BtnSellOnce()
    {
        bool isall = false;
        DataMgr.Instance().SellAction(isall);
        Debug.LogError("卖一次！");
    }
    void BtnSellAll()
    {
        bool isall = true;
        DataMgr.Instance().SellAction(isall);
        Debug.LogError("全卖了！");
    }
}

    