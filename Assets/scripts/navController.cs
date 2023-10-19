using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class navController : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI star;
    [SerializeField] public TextMeshProUGUI timeRemain;
    [SerializeField] public TextMeshProUGUI lvTxt;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timer = GameManagement.timer;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timeRemain.text = niceTime;
        star.text = GameManagement.Instance.currenScore.ToString();
        lvTxt.text="lv-"+(GameManagement.Instance.levelIndex+1).ToString();
    }
}
