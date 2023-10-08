using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance 
    { 
        get 
        { 
            if (_instance == null)
            {
                Debug.Log("UI Manager is Null!");
            }

            return _instance; 
        } 
    }

    public Text playerGemCountText;
    public Image selectionImg;
    public Text gemCountText;
    public Image[] lifeImges;

    public GameObject[] itemImages;

    public GameObject WinPanel;
    public GameObject GameOverPanel;
    private GameObject Player;
    private Player player;
    public GameObject HUD;

    private void Awake()
    {
        _instance = this;
        Player = GameObject.FindWithTag("Player");
        player = Player.GetComponent<Player>();
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = gemCount + " G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int gems)
    {
        gemCountText.text = gems + "";
    }

    public void DamageLifeUpdate(int health)
    {
        for (int i = lifeImges.Length-1; i > health-1; i--)
        {
            lifeImges[i].enabled = false;
        }
    }

    public void RestartLevel()
    {
        
        player.DeactivateNewInputSystem();
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
    }

    public void QuitToMenu()
    {
        player.DeactivateNewInputSystem();
        SceneManager.LoadSceneAsync("Main_Menu", LoadSceneMode.Single);
    }

    public void ActivateWinMenu()
    {
        WinPanel.SetActive(true);
        StartCoroutine(TimeStop());
    }

    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
    }

    public void ActivateGameOverMenu()
    {
        GameOverPanel.SetActive(true);
        StartCoroutine(TimeStop());
    }
}
