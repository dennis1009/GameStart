using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMgr : MonoBehaviour {
    public static LineRenderer lineRenderer;
    static List<Vector3> PointList = new List<Vector3>();
    public static Vector3[] PointArray;
    static float oldx = 0;
    static float oldy = 0;
    public static float timer = 0.0f;
    public static float timegap = 2.0f;
    public static Camera m_camera;
    int maxPoint = 50;
	// Use this for initialization
	void Start ()
    {
        m_camera = FindObjectOfType<Camera>();
        DataMgr.Instance().Init();
        lineRenderer = GetComponent<LineRenderer>();
        PointList.Add(Vector3.zero);
        PointList.Add(Vector3.forward);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timegap)
        {
            DataMgr.Instance().CalcPrice();
            CalcPoint();
            lineRenderer.SetPositions(PointArray);
            MoveCamera();
            timer = 0;
            UIMgr uiMgr = FindObjectOfType<UIMgr>();
            uiMgr.m_price.text = DataMgr.Instance().curprice.ToString();
        }



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
        DataMgr dataMgr = DataMgr.Instance();
        Vector3 n_point = Vector3.zero;
        n_point.x = oldx + timegap/1.0f;         //基于timeGap刷新横轴
        oldx = n_point.x;                        //记录上一个横轴
        n_point.y = dataMgr.curprice;
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

    public static void MoveCamera()
    {
        Vector3 curPoint = PointArray[PointArray.Length - 1];
        curPoint.z -= 500;
        curPoint.y -= curPoint.y/2;
        m_camera.transform.position = curPoint;
    }
}
