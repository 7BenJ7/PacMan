using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Canvas")]
    [SerializeField] 
    private Canvas menu;
    [SerializeField] 
    private Canvas hud;
    [SerializeField] 
    private Canvas credits;
    [SerializeField] 
    private Canvas gameOver;
    [SerializeField] 
    private Canvas win;
    
    [Header("Fin de partie")]
    [SerializeField] 
    private TMP_Text looseScore;
    [SerializeField] 
    private TMP_Text winScore;
    [SerializeField] 
    private int nbGommesMax;
    private int _nbGommes;

    [Header("Pacman")] 
    [SerializeField] 
    private PlayerManager pacman;
    [SerializeField]
    private Transform spawnTransform;

    [Header("Fantomes")] 
    public List<GhostController> fantomes;
    
    [Header("HUD")]
    [SerializeField] 
    private GameObject hearts;
    private List<Image> _heartsList = new List<Image>();
    [SerializeField] 
    private Image heart;
    [SerializeField] 
    private TMP_Text scoreText;

    public int score;
    public int life;

    private void Awake()
    {
        if(Instance != null) Destroy(Instance.gameObject);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        hud.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
        
        AudioManager.Instance.PlayMusic("Menu", true);
    }

    public void StartGame()
    {
        menu.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
        hud.gameObject.SetActive(true);
        
        _heartsList.Clear();
        foreach (Image image in hearts.GetComponentsInChildren<Image>())
        {
            Destroy(image.gameObject);
        }
        for (int i = 0; i < 3; i++)
        {
            Image newHeart = Instantiate(heart, Vector3.zero, Quaternion.identity);
            _heartsList.Add(newHeart);
            newHeart.transform.SetParent(hearts.transform);
            newHeart.gameObject.SetActive(true);
        }

        _nbGommes = nbGommesMax;
        
        AudioManager.Instance.StopMusic("Menu");
        AudioManager.Instance.PlaySFX("Start");
        StartCoroutine(StartGameCoroutine());
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void Credits()
    {
        menu.gameObject.SetActive(false);
        hud.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
    }

    public void ReturnToMenu()
    {
        credits.gameObject.SetActive(false);
        hud.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
    
    public void Spawn()
    {
        PlayerManager pacmanSpawned = Instantiate(pacman, spawnTransform.position, Quaternion.identity);
        pacmanSpawned.gameObject.SetActive(true);
    }

    public void TakeDamage()
    {
        Debug.Log(_heartsList.Count);
        AudioManager.Instance.PlaySFX("Mort");

        if (_heartsList.Count > 1)
        {
            Destroy(_heartsList[^1].gameObject);
            _heartsList.RemoveAt(_heartsList.Count-1);
            //TODO Anim mort
            Destroy(PlayerManager.Instance.gameObject);
            StartCoroutine(RespawnCoroutine());
        }

        else
        {
            //TODO Anim mort
            Destroy(_heartsList[^1].gameObject);

            Destroy(PlayerManager.Instance.gameObject);
            StartCoroutine(DeathCoroutine());
        }
    }
    
    public void ScoreUp(int scoreAdded)
    {
        Debug.Log("score up");
        score += scoreAdded;
        scoreText.text = "Score : \n" + score;
    }

    public void GommeRestante()
    {
        _nbGommes--;
        
        if (_nbGommes == 0)
        {
            Destroy(PlayerManager.Instance.gameObject);
            winScore.text = "Score : " + score;
            score = 0;
            AudioManager.Instance.PlayMusic("Menu");
        
            credits.gameObject.SetActive(false);
            hud.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(false);
            win.gameObject.SetActive(true);
            menu.gameObject.SetActive(false);
        }
    }

    private IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSeconds(4.5f);
        Spawn();
    }
    
    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(2);
        Spawn();
    }
    
    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(2);
        looseScore.text = "Score : " + score;
        score = 0;
        AudioManager.Instance.PlayMusic("Menu");
        
        credits.gameObject.SetActive(false);
        hud.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        win.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
    }
    }