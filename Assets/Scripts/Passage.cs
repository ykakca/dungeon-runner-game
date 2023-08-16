using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public string LevelName;
    
    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            FindObjectOfType<GameManager>().WonLevelScreen();
            FindObjectOfType<GameManager>().ResetCoinCount();
            //FindObjectOfType<GameManager>().LoadScene(LevelName);
        }
    }
}
