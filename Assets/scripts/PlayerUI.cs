using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI star;
    [SerializeField] public TextMeshProUGUI timeRemain;
    [SerializeField] public TextMeshProUGUI lvTxt;
    [SerializeField] public Button pauseBtn;
    [SerializeField] public Button resumeBtn;
    [SerializeField] public Button backToMenu;
    [SerializeField] public Button gotoNextLevel;
  
    [SerializeField] public Transform gameOverCanvas;
    [SerializeField] public Transform pauseCanvas;
    [SerializeField] public Transform victoryCanvas;
    [SerializeField] public Transform processCanvas;
    [SerializeField] public Image ProcessBar;

    void Start()
    {
        processCanvas.transform.gameObject.SetActive(false);
        gameOverCanvas.transform.gameObject.SetActive(false);
        victoryCanvas.transform.gameObject.SetActive(false);
        pauseCanvas.transform.gameObject.SetActive(false);
        ProcessBar.fillAmount = 1;
    

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagement.Instance.timeForUseComboCurrent > 0f)
        {
            processCanvas.transform.gameObject.SetActive(true);
        }
        else
        {
            processCanvas.transform.gameObject.SetActive(false);
        }
        ProcessBar.fillAmount=(float)(GameManagement.Instance.timeForUseComboCurrent/GameManagement.Instance.timeForUseCombo);
    }
}
