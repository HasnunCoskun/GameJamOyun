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


    //deðer kýsýmlarý



    int motivasyon = 5;
    int umut = 5;
    int gun = 1;
    int unityTamamlama = 0;
    int projeTamamlama = 0;
    int unityBasari = 70;
    int projeBasari = 50;

    bool unityDeneme = false;
    bool projeDeneme = false;

    // text kýsýmlarý
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
        SceneManager.LoadScene("BaþlangýçSahnesi");

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



    } //kendiliðinden kaybolan mesaj HASNUN EKLEDÝ

    public void uyariPanelKapa()
    {
        uyariPanel.SetActive(false);
    } // uyarý panelini kapamaya yarayan kod
    public void cikisButton()
    {
        panel.SetActive(false);
    }  //pcden çýkýþ yapan kýsým

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
                    mesajGoster("Basarýlý! Unity'de ilerledin!");
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
                    mesajGoster("Yarý yolda kafan dagýldý ve sonunu getiremedin. Tekrar denemen gerekecek.");
                    umut -= 1;
                    _umut.text = umut.ToString();
                    lose.Play();
                }
            }
            else
            {
                mesajGoster("Unity görevlerini zaten bitirdin.");
            }


            //Text kýsýmlarý
            motiv.text = motivasyon.ToString();

            unity.text = unityTamamlama.ToString();
        }
        else
        {
            uyariPanel.SetActive(true);
            _uyariPanel.text = "Bugün çalýsmaya yetecek motivasyonun kalmadý, yeni bir güne geçmeyi dene!";
            sleep.Play();


        }




    } //Unity butonuna týklayýnca olan iþlemler
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
                    mesajGoster("Dikkatin çok dagýnýktý, modülü tamamlayamadýn.");
                    projeBasari -= 3;
                    _projeBasari.text = projeBasari.ToString();
                    lose.Play();
                }
            }
            else
            {
                mesajGoster("Coursera görevlerini zaten bitirdin.");
            }


            //Text kýsýmlarý
            motiv.text = motivasyon.ToString();

            proje.text = projeTamamlama.ToString();
        }
        else
        {
            uyariPanel.SetActive(true);
            _uyariPanel.text = "Bugün çalýsamaya yetecek motivasyonun kalmadý, yeni bir güne geçmeyi dene!";
            sleep.Play();

        }
        Debug.Log("proje button");

    } //coursera butonuna týklayýnca olan iþlemler
    public void sporButton()
    {
        if (motivasyon >= 2)
        {
            motivasyon -= 2;
            umut += 3;
            mesajGoster("Güzel bir yürüyüs yapýp dostlarýnla bulustun. Hayat daha güzel gibi, degil mi?");
            motiv.text = motivasyon.ToString();
            _umut.text = umut.ToString();
        } else
        {
            mesajGoster("Böyle zor bir seyi yapacak kadar motivasyonun kalmadý. ");

        }
       

    } //spor ve sosyalleþme HASNUN EKLEDÝ
    public void hobiButton()
    {
        if (motivasyon >= 1)
        {
            motivasyon -= 1;
            unityBasari += 3;
            projeBasari += 3;
            mesajGoster("Biraz kendine zaman ayýrýp kafaný toparladýn.");
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
            mesajGoster("Bugün biraz keyif yapacak kadar bile motivasyonun kalmamýs. Ama her zaman bir yarýn var!");
            sleep.Play();

        }

    } //hobi yapma HASNUN EKLEDÝ

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
            gameOverText.text = "Tebrikler, kazandýn!";
            gameOverPanel.SetActive(true);
        }
        else if (gun >= 7)
        {
            gameOverText.text = "Görevlerini zamanýnda tamamlayamadýn.";
            gameOverPanel.SetActive(true);

        } else if (umut <= 0)
        {
            gameOverText.text = "Akademide ilerleyebilecegine dair umudun kalmadý.";
            gameOverPanel.SetActive(true);
        }else
        {
            gunGecis();
        }
            




      

    } //sonraki güne geçme HASNUN EKLEDÝ
 //5 saniye sonra paneli kapatýyor

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("bilgisayar"))
                {
                    Debug.Log("Bilgisyara basýldý selam ");
                    panel.SetActive(true);


                }

                if (hit.collider.gameObject.CompareTag("kapi"))
                {
                    Debug.Log("evden çikildi ");
                    sporButton();


                }
                if (hit.collider.gameObject.CompareTag("yatak")) //yataða týklama
                {
                    
                    panelKapa();
                    yatakButton();


                }

                if (hit.collider.gameObject.CompareTag("tv")) //yataða týklama
                {

                    panelKapa();
                    hobiButton();


                }
                Debug.Log(hit.collider.gameObject.tag);
            }
        } //mouse ile týklanan coliderin tagini yakalama

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


