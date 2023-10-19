using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public  class GameManagement : MonoBehaviour
{
    [SerializeField] public LevelSO[] levelSOs;
    [SerializeField] private PlayerDataSO playerDataSO;
    [SerializeField] public TextMeshProUGUI comboStreak;
    [SerializeField] public TextMeshProUGUI star;
    [SerializeField] public TextMeshProUGUI timeRemain;
    [SerializeField] public TextMeshProUGUI lvTxt;
    [SerializeField] public TextMeshProUGUI coinTxt;
    [SerializeField] public Button pauseBtn;
    [SerializeField] public Button resumeBtn;
    [SerializeField] public Button backToMenu;
    [SerializeField] public Button gotoNextLevel;
    [SerializeField] public Button playAgain;
    [SerializeField] public Button quit;
    [SerializeField] public Transform gameOverCanvas;
    [SerializeField] public Transform pauseCanvas;
    [SerializeField] public Transform victoryCanvas;
    [SerializeField] public CartContainer cardContainer;
    [SerializeField] public SoundSO soundSO;
    [SerializeField] public int levelIndex;
    public static float volumn;
    [SerializeField] public CardCollection cardCollection;
    public List<int> queue=new List<int>();
    private int  pivotIndex;
    private int currentFinishMatch;
    private int[] checkList=new int[10];
    public static int maximunCartContainer;
    public static float timer;
    private bool gameOver;
    private bool win;
    private int numberOfCard;
    public int currenScore;
    public int currentComboScore;
    public int ComboStreak;
    public float timeForUseCombo;
    public float timeForUseComboCurrent;
   [SerializeField] private Vector3 lastItemPosition;
   [SerializeField] public Item lastItemAdded;
   [SerializeField] public card lastCard;
    private int lastIndexCard;
    public static GameManagement Instance { get; private set; }

    private void Awake()
    {
        ComboStreak = 0;
        timeForUseCombo = 8f;
        timeForUseComboCurrent = 0f;
        currentComboScore = 1;
        currenScore = 0;
        numberOfCard = 0;
        gameOver = false;
        win=false;
        levelIndex = playerDataSO.CurrentLV;
        volumn = 20f;
        maximunCartContainer = playerDataSO.currentCardSlot;
        coinTxt.text = playerDataSO.CurrentCoin.ToString();
        pivotIndex = queue.Count;
        timer = levelSOs[levelIndex].Timer;
        for (int i = 0;i < checkList.Length;i++)
        {
            checkList[i] = 0;
        }
        if (GameManagement.Instance == null)
        {
            Instance = this; 
        }
        else
        {
            GameManagement.Instance = this;
        }
    }
    void Start()
    {
        InitiateCard();
        pauseBtn.onClick.AddListener(() =>
        {
            pauseCanvas.gameObject.SetActive(true);
            SoundManagement.Instance.PlaySound(soundSO.hit);
            Time.timeScale = 0f;
        });
        gotoNextLevel.onClick.AddListener(() => {
            playerDataSO.CurrentLV += 1;
            SoundManagement.Instance.PlaySound(soundSO.hit);
            SceneManager.LoadScene(1);
        });
        resumeBtn.onClick.AddListener(() => {
           
            SoundManagement.Instance.PlaySound(soundSO.hit);
            pauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
        });
        backToMenu.onClick.AddListener(() => {
            SoundManagement.Instance.PlaySound(soundSO.hit);
            SceneManager.LoadScene(0);
        });
        playAgain.onClick.AddListener(() => {
            SoundManagement.Instance.PlaySound(soundSO.hit);
            if (playerDataSO.CurrentCoin > 1000)
            {
                playerDataSO.CurrentCoin -= 1000;
                coinTxt.text = playerDataSO.CurrentCoin.ToString();
                SceneManager.UnloadSceneAsync(1);
                SceneManager.LoadScene(1);
            }

        
        });
        quit.onClick.AddListener(() =>
        {
            SoundManagement.Instance.PlaySound(soundSO.hit);
            playerDataSO.currentLife--;
            SceneManager.LoadScene(0);
        });


    }
    private void InitiateCard()
    {
      
            for(int j = 0; j < levelSOs[levelIndex].numberOfItemList.Count;j++)
        {
            for(int i = 0; i < levelSOs[levelIndex].numberOfItemList[j];i++)
            { for (int g = 0; g <= 2; g++)
                {
                    numberOfCard++;
                    SpawnCard(cardCollection.Items[j].preFab, this.transform); }
            }
                    
                    }    
          
        

    }
    private void SpawnCard(Transform template,Transform position)
    {
        Vector3 newPos =new Vector3(Random.Range(position.transform.position.x-100f, position.transform.position.x+100f), 50, Random.Range(position.transform.position.z - 120f, position.transform.position.z + 160f));
        Transform newCard= Instantiate(template,newPos,Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        timeForUseComboCurrent -= Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer < 0f ||gameOver)
        {
            Time.timeScale = 0f;
          
            gameOverCanvas.gameObject.SetActive(true);
        }
        if (win)
        {
          
            victoryCanvas.gameObject.SetActive(true);
        }


    }
  public void add(Item item)
    {
       
        //    1  2 3
        //p = 0  0 2 3
       
        lastItemPosition = item.transform.position;
        pivotIndex = queue.Count;
        if (queue.Contains(item.itemSO.priority))
        {  int lastIndexOfItem=queue.LastIndexOf(item.itemSO.priority);
            lastCard = cardContainer.cartPos[lastIndexOfItem];
            queue.Insert(lastIndexOfItem, item.itemSO.priority);
            HandleCartPosition(lastIndexOfItem);
            item.HandleMoveToPos(cardContainer.cartPos[lastIndexOfItem]);
            checkList[item.itemSO.priority]++;
            pivotIndex = queue.Count ;
            lastIndexCard = lastIndexOfItem;
            if (checkList[item.itemSO.priority] == 3)
            {
                currentFinishMatch=item.itemSO.priority;
              
                Invoke("correctMatch", 0.6f);
            }

     

        }
        else
        {
            for(int i=0; i<queue.Count; i++)
            {
                if (queue[i] > item.itemSO.priority)
                {
                    pivotIndex = i;
                    break;
                   
                   
                }
            }
           HandleCartPosition(pivotIndex);
                queue.Insert(pivotIndex, item.itemSO.priority);
            lastIndexCard = pivotIndex;
            lastCard = cardContainer.cartPos[pivotIndex];
            item.HandleMoveToPos(cardContainer.cartPos[pivotIndex]);
            pivotIndex = queue.Count ;
            checkList[item.itemSO.priority]++;
            if (checkList[item.itemSO.priority] == 3)
            {
                currentFinishMatch = item.itemSO.priority;
               
                Invoke("correctMatch", 0.2f);
            }
        }



        if (checkList[item.itemSO.priority] == 3)
        {
            checkList[item.itemSO.priority] = 0;
            
            pivotIndex=queue.Count-3 ;
        }
        if (queue.Count == maximunCartContainer&&currentFinishMatch==-10)
        {

            gameOver = true;
            playerDataSO.CurrentLife--;
            SoundManagement.Instance.PlaySound(soundSO.gameover);
        }
        Debug.Log(String.Join("; ", queue));
     
      

    }
    private void correctMatch()
    {
        SoundManagement.Instance.PlaySound(soundSO.correct);
        RemoveCard(queue.LastIndexOf(currentFinishMatch) - 2);
        queue.Remove(currentFinishMatch);
        queue.Remove(currentFinishMatch);
        queue.Remove(currentFinishMatch);
        Debug.Log(String.Join("; ", queue));
        if (timeForUseComboCurrent > 0f)
        {
            currentComboScore += 1;
        }
        else
        {
            currentComboScore = 1;
        }
        currenScore += currentComboScore;
        playerDataSO.CurrentStar += currentComboScore;
        timeForUseComboCurrent = timeForUseCombo;
        comboStreak.text = "Combo x " + currentComboScore.ToString();
        currentFinishMatch = -10;
        numberOfCard -= 3;
        if(numberOfCard <=0) {
            SoundManagement.Instance.PlaySound(soundSO.Victory);
            win = true;
            mainUI.levelIndex++;
        }
    }
    private void RemoveCard(int index)
    {
        for (int i = index; i < Math.Min(index + 3, maximunCartContainer ); i++)
        {
            Debug.Log(i);
            cardContainer.cartPos[i].item.DestroySefl();
            cardContainer.cartPos[i].item= null;
        }
        for (int i = index; i <Math.Min(index + 3,maximunCartContainer-3); i++)
        {
            if (cardContainer.cartPos[i + 3].item != null)
            {
                cardContainer.cartPos[i + 3].item.HandleMoveToPos(cardContainer.cartPos[i]);
                cardContainer.cartPos[i + 3].item = null;
            }
        }
        
    }
    private void HandleCartPosition(int pivotIndex)
    {
        for(int i = maximunCartContainer - 2; i >=pivotIndex; i--)
        {
            if (cardContainer.cartPos[i].item != null)
            {
                cardContainer.cartPos[i].item.HandleMoveToPos(cardContainer.cartPos[i + 1]);
            }
        }
    }
    private void HandleBackCartPosition(int pivotIndex)
    {
        for (int i =  pivotIndex; i <maximunCartContainer-1;i++)
        {
            if (cardContainer.cartPos[i+1].item != null)
            {
                cardContainer.cartPos[i+1].item.HandleMoveToPos(cardContainer.cartPos[i]);
            }
        }
    }
    public void BackTileFeature()
    {  if (lastCard.item != null)
        {
            SoundManagement.Instance.PlaySound(soundSO.hit);
            lastCard.item = null;
            checkList[lastItemAdded.itemSO.priority]--;
            lastItemAdded.GetComponent<EventTriggerItem>().enabled = true;
            queue.RemoveAt(lastIndexCard);
            Debug.Log(String.Join("; ", queue));
            HandleBackCartPosition(lastIndexCard);
            lastItemAdded.SettingPropertyForBack(lastItemPosition);
        }
        }
}