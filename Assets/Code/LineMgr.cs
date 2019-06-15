using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMgr : MonoBehaviour {
    public static LineRenderer lineRenderer;
    static List<Vector3> PointList = new List<Vector3>();
    public static Vector3[] PointArray;
    static float oldx = 0;
    static float oldy = 0;
    int maxPoint = 50;
	// Use this for initialization
	void Start ()
    {
       
        lineRenderer = GetComponent<LineRenderer>();
        PointList.Add(Vector3.zero);
        PointList.Add(Vector3.forward);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public static void CalcList(Vector3 n_point)
    {
        if (lineRenderer.positionCount <= PointList.Count)
            lineRenderer.positionCount++;
        PointList.Add(n_point);
        PointArray = PointList.ToArray();
    }
    public static void CalcPoint()
    {
        Vector3 n_point = Vector3.zero;
        n_point.x = oldx + DataMgr.timegap/1.0f; //基于timeGap刷新横轴
        oldx = n_point.x;                        //记录上一个横轴
        n_point.y = DataMgr.curprice;
        if (n_point.y < oldy)
        {
            lineRenderer.material.color = Color.green;
        }
        else
        {
            lineRenderer.material.color = Color.red;
        }
        oldy = n_point.y;
        CalcList(n_point);

    }
}
