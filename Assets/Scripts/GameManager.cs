using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Enemy[] enemies;
    public Player player;
    public Transform coins;
    public Door door;
    public SpriteRenderer doorSpriteRenderer;
    public BoxCollider2D doorBoxCollider;
    public Sprite openedDoorSprite;
    public GameObject deadScreen;
    public GameObject wonScreen;
    public Button mainMenuButton;
    public TextMeshProUGUI totalScoreTextDead;
    public TextMeshProUGUI totalScoreTextWon;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI currentScore;
    public Passage passage;
    public bool isDead;
    public bool goneToMainMenu;
    public int score;
    public int lives { get; private set; }


    private void Start()
    {
        NewGame();
        UpdateHighScore();
    }

    private void Update()
    {
        if (this.lives <= 0 && !isDead) {
            isDead = true;
            GameOver();
        }

        if (totalScoreTextDead.text != this.score.ToString())
        {
            totalScoreTextDead.text = this.score.ToString();
            totalScoreTextWon.text = this.score.ToString();
        }

        if (currentScore.text != this.score.ToString()) {
            currentScore.text = this.score.ToString();
        }
        //CoinCollected(coins);
        //Debug.Log(score);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    } 

    public void NewGame()
    {
        SetScore(0);
        SetLives(1);
        NewRound();
    }

    public void NewRound()
    {
        foreach (Transform coin in this.coins) {
            coin.gameObject.SetActive(true);
        }

        
        Debug.Log("NEW ROUND");

        ResetState();

    }

    private void ResetState()
    {
        for (int i=0; i<this.enemies.Length; i++) {
            this.enemies[i].gameObject.SetActive(true);
        }
        
        this.player.gameObject.SetActive(true);

    }

    private void GameOver()
    {
        /*for (int i=0; i<this.enemies.Length; i++) {
            this.enemies[i].gameObject.SetActive(false);
        }*/
        
        this.player.gameObject.SetActive(false);
        //this.deadScreen.enabled = true;
        ResetCoinCount();
        deadScreen.SetActive(true);
    }

    private void GetDoorComponents()
    {
        this.doorSpriteRenderer = door.gameObject.GetComponent<SpriteRenderer>();
        this.doorBoxCollider = door.gameObject.GetComponent<BoxCollider2D>();
    }

    public void SetScore(int score) 
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void EnemyDead(Enemy enemy)
    {
        SetScore(this.score + enemy.points);
        //Destroy(enemy);
    }

    public void PlayerDead()
    {
        this.player.gameObject.SetActive(false);
        SetLives(this.lives - 1);

        if (this.lives > 0) {
            Invoke(nameof(ResetState), 3.0f);
        }
        else {
            GameOver();
        }
        //deneme icin hardcode
        deadScreen.SetActive(true);
    }
    
    public void EnterDoor(Player player, Passage passage)
    {
        //FindObjectOfType<Passage>(0).OnTriggerEnter2D();
        CoinObject.totalCoins = -1;
        for (int i=0; i<this.enemies.Length; i++) {
            Destroy(enemies[i]);
        }
    }

    public void CoinCollected(CoinObject coin)
    {  
        coin.gameObject.SetActive(false);
        SetScore(this.score + coin.points);
        //SetScore(this.score + coin.GetComponent<points>());
        //Destroy(coin);
        

        if(!HasRemainingCoins()) {
            //this.player.gameObject.SetActive(false);
            doorSpriteRenderer.sprite = openedDoorSprite;
            doorBoxCollider.isTrigger = true;


            //Invoke(nameof(NewRound), 3.0f); //Yeni bolume gecis
        }

        CheckHighScore();
    }

    public void SpeedPotionCollected(SpeedPotion pot)
    {
        //CoinCollected(pot);
        CancelInvoke(nameof(SetDefaultSpeed));
        pot.gameObject.SetActive(false);
        Destroy(pot);
        StartCoroutine(SpeedUp(8));
        StopCoroutine("SpeedUp");
        this.player.speed = 5;
        Invoke(nameof(SetDefaultSpeed), pot.duration);
        //CancelInvoke(nameof(SpeedUp));
        //Invoke(nameof(SpeedUp), pot.duration);
        //this.player.speed = 12;
    }

    private IEnumerator SpeedUp(float waitTime)
    {
        float timePassed = 0;
        while (timePassed < 1) {
            this.player.speed = 12; 
            timePassed += Time.deltaTime;
            yield return null;
        }
        
        /*this.player.speed = 12;
        yield return new WaitForSeconds(waitTime);*/

    }

    private void SetDefaultSpeed()
    {
        this.player.speed = 8;
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }
    
    public void InvinciblePotionCollected(InvinciblePotion pot) 
    {
        //CancelInvoke(nameof(ResetFrightened));
        for (int i=0; i<enemies.Length; i++) {
            enemies[i].isFrightened = true;
        }
        player.isEnemyFrightened = true;
        //Destroy(enemies[0]);
        pot.gameObject.SetActive(false);
        Invoke(nameof(ResetFrightened), pot.duration);
        //Destroy(pot);
        //CancelInvoke(nameof(ResetEnemyMultiplier));
        //Invoke(nameof(ResetEnemyMultiplier), pot.duration);
    }

    private void ResetFrightened()
    {
        for (int i=0; i<enemies.Length; i++) {
            enemies[i].isFrightened = false;
        }

        player.isEnemyFrightened = false;
    }

    public void ResetCoinCount()
    {
        CoinObject.totalCoins = -1;
    }

    public void WonLevelScreen()
    {
        //wonScreen.pointsText.text = score.ToString() + " POINTS";
        wonScreen.SetActive(true);
    }
    /*private void ResetEnemyMultiplier()
    {
        enemyMultiplier = 1;
    }
    */
    private bool HasRemainingCoins()
    {
        int flag = 0;
        foreach (Transform c in this.coins) {
            if (c.gameObject.activeSelf) {
                flag = 1;
            }
        }
        
        if (flag == 1) {
            return true;
        } else {
            return false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void CheckHighScore() {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            UpdateHighScore();
        }
    }

    void UpdateHighScore()
    {
        HighScore.text = $"{PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
