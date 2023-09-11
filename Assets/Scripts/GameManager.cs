using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Canvas")]
    [SerializeField] 
    private Canvas hud;
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
    public List<GhostController> ghostInstances;
    
    [Header("HUD")]
    [SerializeField] 
    private GameObject hearts;
    [SerializeField] 
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
        hud.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
        
        _nbGommes = nbGommesMax;
        
        AudioManager.Instance.StopMusic("Menu");
        AudioManager.Instance.PlaySFX("Start");
        StartCoroutine(StartGameCoroutine());
    }

   public void ReturnToMenu()
   {
       AudioManager.Instance.PlaySFX("Bouton");
       StartCoroutine(ReturnButtonCoroutine());
   }
    
    public void Spawn()
    {
        ghostInstances = new List<GhostController>();
        PlayerManager pacmanSpawned = Instantiate(pacman, spawnTransform.position, Quaternion.identity);
        pacmanSpawned.gameObject.SetActive(true);
        foreach (GhostController ghost in fantomes)
        {
            GhostController ghostSpawned = Instantiate(ghost, ghost.transform.position, Quaternion.identity);
            ghostSpawned.gameObject.SetActive(true);
            ghostSpawned.gameObject.GetComponent<GhostController>().pacman = pacmanSpawned.gameObject;
            ghostInstances.Add(ghostSpawned);
        }

    }

    public void TakeDamage()
    {
        Debug.Log(_heartsList.Count);
        AudioManager.Instance.PlaySFX("Mort");
        PlayerManager.Instance.gameObject.GetComponentInChildren<AnimatedPacMan>().isDead = true;
        Destroy(_heartsList[^1].gameObject);
        PlayerManager.Instance.GetComponent<PacMan>().speed = 0;
        
        if (_heartsList.Count > 1)
        {
            _heartsList.RemoveAt(_heartsList.Count-1);
            
            foreach (GhostController ghost in ghostInstances)
            {
                Destroy(ghost.gameObject);
            }

            StartCoroutine(RespawnCoroutine());
        }

        else
        {
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
            
            hud.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(false);
            win.gameObject.SetActive(true);
        }
    }

    private IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSeconds(1f);
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
        AudioManager.Instance.PlayMusic("Menu", true);
        
        hud.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        win.gameObject.SetActive(false);
    }
    
    private IEnumerator ReturnButtonCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Menu");
    }
}