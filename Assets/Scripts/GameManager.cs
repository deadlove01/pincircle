using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    #region simple singleton

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    #endregion
    
    public GameObject needlePrefab;
    public Vector3 startPos;
    
    
    private Button btnShoot;
    private Button btnRestart;
    private Circle curCirle;

    private GameObject curNeedle;
    void Start()
    {
        CreateNeedle();
    }

    void Init()
    {
        curCirle = GameObject.FindGameObjectWithTag("Circle").GetComponent<Circle>();
        btnShoot = GameObject.FindGameObjectWithTag("ShootBtn").GetComponent<Button>();
        btnShoot.onClick.AddListener(() => FireNeedle());
        //BtnRestart
        //btnRestart = GameObject.Find("BtnRestart").GetComponent<Button>();
      
        //btnRestart.onClick.AddListener(()=> RestartGame());
    }

    

    public void CreateNeedle()
    {
        curNeedle = Instantiate(needlePrefab, startPos, Quaternion.identity);
    }


    public void FireNeedle()
    {
        curNeedle.GetComponent<NeedleController>().Fire();
    }


    public void EndGame()
    {
        curCirle.StopRotateMySelf();
        btnShoot.onClick.RemoveAllListeners();
        ScoreManager.Instance.ShowEndGamePanel(true);
        print("end game");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
  


}
