using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
    public Button StartBtn;

	// Use this for initialization
	void Start ()
    {
        StartBtn.onClick.AddListener(() =>
        {
            DataMgr.Instance().Init();
            SceneManager.LoadScene(1);
        });
		
	}


}
