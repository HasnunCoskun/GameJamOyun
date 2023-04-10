using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class geçiş : MonoBehaviour
{
    private Scene _scene;


    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); //caching
    }

  public void geçişFonk()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }

    public void açıklamaGeçişFonk()
    {
        SceneManager.LoadScene("NasılOynanır1");
    }

    public void hazırlayanlarGeçişFonk()
    {
        SceneManager.LoadScene("Hazırlayanlar");
    }

    public void geriDönüş()
    {
        SceneManager.LoadScene(_scene.buildIndex -1);
    }

    public void başaDönüş()
    {
        SceneManager.LoadScene(0);
    }

    public void oyunaGeçiş()
    {
        SceneManager.LoadScene("game");
    }

    public void iyiOyunlar()
    {
        SceneManager.LoadScene("İyiOyunlar");
    }

    public void cikis()
    {
        Application.Quit();
    }
}
