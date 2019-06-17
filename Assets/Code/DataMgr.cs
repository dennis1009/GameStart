using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr  {
    int startprice = 0;
    public int curprice ;
    public int curmoney = 50000 ;
    public int haveCount;
    public int avgPrice;
    private static DataMgr dataMgr;
    
    public static DataMgr Instance()
    {
        if (dataMgr == null)
            dataMgr = new DataMgr();
     
        return dataMgr;
     
    }
    public void Init ()
    {

        startprice = Random.Range(100, 200);
        curprice = startprice;

	}

    public void CalcPrice()
    {
        curprice += Random.Range(-50, 50);
        if (curprice<0)
        {
            curprice = 0;
        }
    }

    public void BuyAction(bool isall)
    {
        if (curprice <= 0)//0元保护
        {
            Debug.LogError("0元禁止出售或购买");
            return;
        }
        UIMgr uiMgr = Object.FindObjectOfType<UIMgr>();
        int nowbuyCount = isall ? curmoney / curprice : 1;
        int nowbuyPrice = curprice;
        int oldcount = haveCount;
        haveCount += nowbuyCount;
        curmoney -= nowbuyCount * nowbuyPrice;
        avgPrice = (avgPrice * oldcount +((nowbuyCount * nowbuyPrice) / nowbuyCount))/haveCount;

        uiMgr.m_count.text = haveCount.ToString();
        uiMgr.m_money.text = curmoney.ToString();
        uiMgr.m_avg.text = avgPrice.ToString();
    }

    public void SellAction(bool isall)
    {
        if (curprice <= 0)//0元保护
        {
            Debug.LogError("0元禁止出售或购买");
            return;
        }
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
