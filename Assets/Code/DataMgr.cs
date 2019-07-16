using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr  {
    int startprice = 0;
    public float curprice ;
    public float curmoney = 50000.00f ;
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

        startprice = Random.Range(100, 200);
        curprice = startprice;
        curmoney = 50000.00f;

    }

    public void CalcPrice()
    {
        curprice += Random.Range((float)(curprice * -0.5), (float)(curprice * 0.5));
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
        int nowbuyCount = isall ? (int)(curmoney / curprice) : 1;
        float nowbuyPrice = curprice;
        int oldcount = haveCount;
        haveCount += nowbuyCount;
        curmoney -= nowbuyCount * nowbuyPrice;
        avgPrice = (avgPrice * oldcount + nowbuyCount * nowbuyPrice )/haveCount;

        uiMgr.m_count.text = haveCount.ToString();
        uiMgr.m_money.text = curmoney.ToString("f2");
        uiMgr.m_avg.text = avgPrice.ToString("f2");
    }

    public void SellAction(bool isall)
    {
        if (haveCount <= 0)
        {
            Debug.LogError("你都没有卖个锤子呢？");
            return;
        }
        if (curprice <= 0)//0元保护
        {
            Debug.LogError("0元禁止出售或购买");
            return;
        }
        UIMgr uiMgr = Object.FindObjectOfType<UIMgr>();
        int nowsellCount = isall ? haveCount : 1;
        float nowsellPrice = curprice;
        haveCount -= nowsellCount;
        curmoney += nowsellCount * nowsellPrice;

        uiMgr.m_count.text = haveCount.ToString();
        uiMgr.m_money.text = curmoney.ToString("f2");
        uiMgr.m_avg.text = haveCount == 0 ? "0" : avgPrice.ToString("f2");
    }
}
