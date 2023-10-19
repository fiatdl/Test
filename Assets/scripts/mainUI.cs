using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainUI : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private PlayerDataSO playerDataSO;
   public static mainUI Instance { get; private set; }
   [SerializeField] public static int levelIndex;
    [SerializeField] public static int totalScore;
    [SerializeField] public static int totalLife;
    [SerializeField] public static int totalCoin;
    [SerializeField] public static int[] remainFeature = { 3, 3, 3, 3 };
    [SerializeField] private TextMeshProUGUI lv;
    [SerializeField] private TextMeshProUGUI star;
    [SerializeField] private TextMeshProUGUI coin;
    [SerializeField] private Transform Setting;
    [SerializeField] private Image process1;
    [SerializeField] private Image process2;

    [SerializeField] private TextMeshProUGUI life;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null) { 
        Instance = this;
        }
        levelIndex = playerDataSO.CurrentLV+1;
        totalLife =playerDataSO.CurrentLife;

        totalScore = playerDataSO.CurrentStar;
        totalCoin =playerDataSO.CurrentCoin;
        lv.text =  levelIndex.ToString();
        star.text =totalScore.ToString();
        coin.text =totalCoin.ToString();
        life.text =totalLife.ToString();
        process1.fillAmount = (float)(totalScore / 100);
        process2.fillAmount = (float)(levelIndex / 5);

          play.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
   
        Time.timeScale = 1.0f;
    }
    private void Awake()
    {
      
    
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlaySound(AudioClip audioClip, Vector3 position, float volumn = 20f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumn * 2f);
    }
}
