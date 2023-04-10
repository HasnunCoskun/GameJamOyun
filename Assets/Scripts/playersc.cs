using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playersc : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject panel;
    public Rigidbody2D rgb;
    public int score;
    public Vector2 hareket;
    public float speed;
    private Animator anim;
    public int motivasyonn;


    public void odayaDon()
    {
        Debug.Log("Odaya dön.");
        Time.timeScale = 1;
        SceneManager.LoadScene("game");

    }
    void Start()
    {
        panel.SetActive(false);
        sprite = GetComponent<SpriteRenderer>();
        motivasyonn = PlayerPrefs.GetInt("motivasyon");
        anim = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("yebunu"))
        {
            score++;
            Destroy(col.gameObject);
        }
        else
        {
            score--;
            Destroy(col.gameObject);
        }
    }

    void Update()
    {
        hareket.x = Input.GetAxis("Horizontal");
        rgb.velocity = hareket * speed;
        if (hareket.x != 0)
        {
          anim.SetBool("kosuyor",true);  
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            sprite.flipX = true;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            sprite.flipX = false;
        }

        if (score == 3)
        {
            PlayerPrefs.SetInt("win", 1);
            Debug.Log("Kazandýn!");
            panel.SetActive(true);
            Time.timeScale = 0;
        }




    }
}
