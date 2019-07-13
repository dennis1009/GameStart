using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public Text m_time;
    public Button m_startnow;
    private int TotalTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeCountDown());
        m_startnow.onClick.AddListener(() => 
        {
            DataMgr.Instance().Init();
            SceneManager.LoadScene(1);
        });
    }

    // Update is called once per frame

    IEnumerator  TimeCountDown()
    {
        while (TotalTime >= 0)
        {
            m_time.text = TotalTime.ToString();
            yield return new WaitForSeconds(1);
            TotalTime--;
        }
        if (TotalTime <= 0 )
        {
            DataMgr.Instance().Init();
            SceneManager.LoadScene(1);
        }
    }
}
