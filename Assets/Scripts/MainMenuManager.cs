using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject rulesScreen;
    // Start is called before the first frame update
    void Start()
    {
        this.rulesScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void openRulesScreen()
    {
        this.rulesScreen.SetActive(true);
    }
}
