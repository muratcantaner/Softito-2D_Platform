using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 7;

    [SerializeField] private Animator playerAnim;
    [SerializeField] private AudioSource deadSound;
    [SerializeField] private AudioSource coinSound;

    private bool kostuMu = false;
    public static bool isStart = false;

    [SerializeField] private int score = 0;

    [SerializeField] private Text scoreText,lastScoreText;
    [SerializeField] private GameObject restartPanel,startPanel;

    // private float horizontalValue;

    private void Start()
    {
        scoreText.text = score.ToString();
        if (GameManager.isRestart)
        {
            startPanel.SetActive(false);
        }
    }


    private void FixedUpdate()
    {
        if (!isStart)
        {
            return;
        }

        float horizontalValue = Input.GetAxis("Horizontal");
        Mover(horizontalValue);
        PlayerAnimations(horizontalValue);
        PlayerTurn(horizontalValue);

    }

    #region Karakter Hareket Islemleri
    private void Mover(float getHorizontal)
    {
        rb.velocity = new Vector2(getHorizontal * speed, rb.velocity.y);
    }
    #endregion

    #region Karakter Animasyon Islemleri
    private void PlayerAnimations(float getHorizontal)
    {
        if (getHorizontal != 0)
        {
            kostuMu = true;
        }
        else
        {
            kostuMu = false;
        }

        playerAnim.SetBool("KosuyorMu", kostuMu);
    }
    #endregion

    #region Karakter Yon Islemleri
    private void PlayerTurn(float getHorizontal)
    {
        if (getHorizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (getHorizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    #endregion


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Coin")
        {
            score+=10;
            scoreText.text = score.ToString();
            coinSound.Play();
            Destroy(collider.gameObject);
        }
        
    }

    #region Olme Islemleri
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision.gameObject);
    }

    private void Dead(GameObject getGameObject)
    {
        if (getGameObject.gameObject.CompareTag("Enemy") || getGameObject.CompareTag("Death"))
        {
            Destroy(gameObject, 0);

            deadSound.Play();
            lastScoreText.text = "Score : " + score.ToString();
            restartPanel.SetActive(true);
        }
        
    }

    #endregion

    public void PlayGame()
    {
        isStart = true;
        startPanel.gameObject.SetActive(false);
    }

    public void nextLevel()
    {
        
    }


}// class
