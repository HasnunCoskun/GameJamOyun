using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class buttonControl : MonoBehaviour
{
    //ses

    public AudioSource win;
    public AudioSource lose;
    public AudioSource sleep;

    //paneller

    public GameObject panel;
    public GameObject uyariPanel;
    public GameObject mesajPanel;
    public GameObject menu;
    public GameObject gameOverPanel;


    //de�er k�s�mlar�



    int motivasyon = 5;
    int umut = 5;
    int gun = 1;
    int unityTamamlama = 0;
    int projeTamamlama = 0;
    int unityBasari = 70;
    int projeBasari = 50;

    bool unityDeneme = false;
    bool projeDeneme = false;

    // text k�s�mlar�
    public TextMeshProUGUI motiv;
    public TextMeshProUGUI _umut;
    public TextMeshProUGUI unity;
    public TextMeshProUGUI proje;
    public TextMeshProUGUI _gun;
    public TextMeshProUGUI _uyariPanel;
    public TextMeshProUGUI _mesajPanel;
    public TextMeshProUGUI _unityBasari;
    public TextMeshProUGUI _projeBasari;
    public TextMeshProUGUI gameOverText;



    System.Random rnd = new System.Random();

    private void Start()
    {

        
        panelKapa();
        _unityBasari.text = unityBasari.ToString();
        _projeBasari.text = projeBasari.ToString();
        motiv.text = motivasyon.ToString();
        _umut.text = umut.ToString();
        _gun.text = gun.ToString();
        unity.text = unityTamamlama.ToString();
        proje.text = projeTamamlama.ToString();
    }

    public void panelKapa()
    {
        panel.SetActive(false);
        uyariPanel.SetActive(false);
        mesajPanel.SetActive(false);
        menu.SetActive(false);
        gameOverPanel.SetActive(false);
    } //Panellerin kapatan fonksiyon

    public void menuPanel()
    {
        menu.SetActive(true);

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Ba�lang��Sahnesi");

    }
    IEnumerator besSaniyeSonraSil()
    {
        yield return new WaitForSeconds(5);
        mesajPanel.SetActive(false);
    }
    public void mesajGoster(string mesaj)
    {
        StopAllCoroutines();
        _mesajPanel.text = mesaj;
        mesajPanel.SetActive(true);
        StartCoroutine(besSaniyeSonraSil());



    } //kendili�inden kaybolan mesaj HASNUN EKLED�

    public void uyariPanelKapa()
    {
        uyariPanel.SetActive(false);
    } // uyar� panelini kapamaya yarayan kod
    public void cikisButton()
    {
        panel.SetActive(false);
    }  //pcden ��k�� yapan k�s�m

    public void unityButton()
    {
        Debug.Log("unity button");

        if (motivasyon >= 1)
        {
            if (unityTamamlama < 10)
            {
                motivasyon -= 1;
                unityDeneme = true;

                if (rnd.Next(0, 100) < unityBasari)
                {
                    unityTamamlama += 1;
                    mesajGoster("Basar�l�! Unity'de ilerledin!");
                    unityBasari += 1;
                    win.Play();

                    if (unityBasari > 100)
                    {
                        unityBasari = 100;
                    }

                    _unityBasari.text = unityBasari.ToString();
                }

                else
                {
                    mesajGoster("Yar� yolda kafan dag�ld� ve sonunu getiremedin. Tekrar denemen gerekecek.");
                    umut -= 1;
                    _umut.text = umut.ToString();
                    lose.Play();
                }
            }
            else
            {
                mesajGoster("Unity g�revlerini zaten bitirdin.");
            }


            //Text k�s�mlar�
            motiv.text = motivasyon.ToString();

            unity.text = unityTamamlama.ToString();
        }
        else
        {
            uyariPanel.SetActive(true);
            _uyariPanel.text = "Bug�n �al�smaya yetecek motivasyonun kalmad�, yeni bir g�ne ge�meyi dene!";
            sleep.Play();


        }




    } //Unity butonuna t�klay�nca olan i�lemler
    public void projeButton()
    {
        if (motivasyon >= 1)
        {
            if (projeTamamlama < 10)
            {
                motivasyon -= 1;
                projeDeneme = true;

                if (rnd.Next(0, 100) < projeBasari)
                {
                    mesajGoster("Tebrikler! Coursera'da ilerledin!");
                    umut += 2;
                    projeTamamlama += 1;
                    win.Play();
                }

                else
                {
                    mesajGoster("Dikkatin �ok dag�n�kt�, mod�l� tamamlayamad�n.");
                    projeBasari -= 3;
                    _projeBasari.text = projeBasari.ToString();
                    lose.Play();
                }
            }
            else
            {
                mesajGoster("Coursera g�revlerini zaten bitirdin.");
            }


            //Text k�s�mlar�
            motiv.text = motivasyon.ToString();

            proje.text = projeTamamlama.ToString();
        }
        else
        {
            uyariPanel.SetActive(true);
            _uyariPanel.text = "Bug�n �al�samaya yetecek motivasyonun kalmad�, yeni bir g�ne ge�meyi dene!";
            sleep.Play();

        }
        Debug.Log("proje button");

    } //coursera butonuna t�klay�nca olan i�lemler
    public void sporButton()
    {
        if (motivasyon >= 2)
        {
            motivasyon -= 2;
            umut += 3;
            mesajGoster("G�zel bir y�r�y�s yap�p dostlar�nla bulustun. Hayat daha g�zel gibi, degil mi?");
            motiv.text = motivasyon.ToString();
            _umut.text = umut.ToString();
        } else
        {
            mesajGoster("B�yle zor bir seyi yapacak kadar motivasyonun kalmad�. ");

        }
       

    } //spor ve sosyalle�me HASNUN EKLED�
    public void hobiButton()
    {
        if (motivasyon >= 1)
        {
            motivasyon -= 1;
            unityBasari += 3;
            projeBasari += 3;
            mesajGoster("Biraz kendine zaman ay�r�p kafan� toparlad�n.");
            motiv.text = motivasyon.ToString();
            _umut.text = umut.ToString();

            if (unityBasari > 100)
            {
                unityBasari = 100;
            }
            if (projeBasari > 100)
            {
                projeBasari = 100;
            }



            _unityBasari.text = unityBasari.ToString();
            _projeBasari.text = projeBasari.ToString();


        } else
        {
            mesajGoster("Bug�n biraz keyif yapacak kadar bile motivasyonun kalmam�s. Ama her zaman bir yar�n var!");
            sleep.Play();

        }

    } //hobi yapma HASNUN EKLED�

    public void gunGecis()
    {
        sleep.Play();
        gun++;
        motivasyon = umut;
        umut = 0;

        if (unityDeneme)
        {
            unityBasari += 5;
        }
        else
        {
            unityBasari -= 5;
        }

        if (projeDeneme)
        {
            projeBasari += 5;
        }
        else
        {
            projeBasari -= 5;
        }

        if (unityBasari > 100)
        {
            unityBasari = 100;
        }
        if (projeBasari > 100)
        {
            projeBasari = 100;
        }

        unityDeneme = false;
        projeDeneme = false;

        _gun.text = gun.ToString();
        motiv.text = motivasyon.ToString();
        _umut.text = umut.ToString();
        _unityBasari.text = unityBasari.ToString();
        _projeBasari.text = projeBasari.ToString();
    }
    public void yatakButton()
    {
        if ((gun <= 7) && (unityTamamlama == 10) && (projeTamamlama == 10))
        {
            gameOverText.text = "Tebrikler, kazand�n!";
            gameOverPanel.SetActive(true);
        }
        else if (gun >= 7)
        {
            gameOverText.text = "G�revlerini zaman�nda tamamlayamad�n.";
            gameOverPanel.SetActive(true);

        } else if (umut <= 0)
        {
            gameOverText.text = "Akademide ilerleyebilecegine dair umudun kalmad�.";
            gameOverPanel.SetActive(true);
        }else
        {
            gunGecis();
        }
            




      

    } //sonraki g�ne ge�me HASNUN EKLED�
 //5 saniye sonra paneli kapat�yor

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("bilgisayar"))
                {
                    Debug.Log("Bilgisyara bas�ld� selam ");
                    panel.SetActive(true);


                }

                if (hit.collider.gameObject.CompareTag("kapi"))
                {
                    Debug.Log("evden �ikildi ");
                    sporButton();


                }
                if (hit.collider.gameObject.CompareTag("yatak")) //yata�a t�klama
                {
                    
                    panelKapa();
                    yatakButton();


                }

                if (hit.collider.gameObject.CompareTag("tv")) //yata�a t�klama
                {

                    panelKapa();
                    hobiButton();


                }
                Debug.Log(hit.collider.gameObject.tag);
            }
        } //mouse ile t�klanan coliderin tagini yakalama

        if (unityDeneme)
        {
            unity.color = new Color32(54, 193, 102, 255);
        }
        else
        {
            unity.color = new Color32(255, 255, 255, 255);
        }
        if (projeDeneme)
        {
            proje.color = new Color32(54, 193, 102, 255);
        }
        else
        {
            proje.color = new Color32(255, 255, 255, 255);

        }
        }
    }


