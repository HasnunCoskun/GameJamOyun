using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

internal class degertutma : MonoBehaviour
{
    public int motivasyon;
    public int umut;
    public TextMeshProUGUI text1;
    private Button but1;
    public playersc player;
    void Start()
    {
        player = GameObject.Find("player").GetComponent<playersc>();
        motivasyon = PlayerPrefs.GetInt("motivasyon");
        umut = PlayerPrefs.GetInt("umut");
        but1 = GameObject.Find("deneme123").GetComponent<Button>();
        but1.onClick.AddListener(geridon);
    }

    public void geridon()
    {
        if (player.score >= 1)
        {
            motivasyon += 10;
            PlayerPrefs.Save();
        }
        PlayerPrefs.SetInt("umut",umut);
        PlayerPrefs.SetInt("motivasyon", motivasyon);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
        
    }
    void Update()
    {
        text1.text = ("Score:"+ player.score.ToString());
        
    }
    
    
}



