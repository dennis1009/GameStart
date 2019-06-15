using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr  {
    int startprice = 0;
    public int curprice ;
    public int curmoney = 50000 ;
    public int haveCount;
    public float avgPrice;
    private static DataMgr dataMgr;
    
    public static DataMgr Instance()
    {
        if (dataMgr == null)
            dataMgr = new DataMgr();
     
        return dataMgr;
     
    }
    public void Init ()
    {

        startprice = Random.Range(10, 20);
        curprice = startprice;

	}

    public void CalcPrice()
    {
        curprice += Random.Range(-10, 10);
    }

    public void BuyAction(bool isall)
    {
        UIMgr uiMgr = Object.FindObjectOfType<UIMgr>();
        int nowbuyCount = isall ? curmoney / curprice : 1;
        int nowbuyPrice = curprice;
        haveCount += nowbuyCount;
        curmoney -= nowbuyCount * nowbuyPrice;
        avgPrice = avgPrice +((nowbuyCount * nowbuyPrice) / nowbuyPrice);//todo 平均价格不对

        uiMgr.m_count.text = haveCount.ToString();
        uiMgr.m_money.text = curmoney.ToString();
        uiMgr.m_avg.text = avgPrice.ToString();
    }

    public void SellAction(bool isall)
    {
        UIMgr uiMgr = Object.FindObjectOfType<UIMgr>();
        int nowsellCount = isall ? haveCount : 1;
        int nowsellPrice = curprice;
        haveCount -= nowsellCount;
        curmoney += nowsellCount * nowsellPrice;

        uiMgr.m_count.text = haveCount.ToString();
        uiMgr.m_money.text = curmoney.ToString();
        uiMgr.m_avg.text = avgPrice.ToString();
    }
}
