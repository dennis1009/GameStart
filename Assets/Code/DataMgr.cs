using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr : MonoBehaviour {
    int startprice = 0;
    float timer = 0.0f;
    public static float timegap = 2.0f;
    public static int curprice ;

    // Use this for initialization
    void Start () {

        startprice = Random.Range(10, 20);
        curprice = startprice;

	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timegap)
        {
            CalcPrice();
            LineMgr.CalcPoint();
            LineMgr.lineRenderer.SetPositions(LineMgr.PointArray);
            timer = 0;
        }
	}
    void CalcPrice()
    {
        curprice += Random.Range(-10, 10);
    }
}
