using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    public GameObject[] p1Sticks;
    public GameObject[] p2Sticks;

    public int P1Life;
    public int P2Life;

    public int P1Shield;
    public int P2Shield;

    public GameObject P1Wins;
    public GameObject P2Wins;

    public AudioSource hurtSound;

    public Animator player1Anim;
    public Animator player2Anim;

    public string mainMenu;

    public delegate void Callback();

    void Start () {
        player1Anim = player1.GetComponent<Animator>();
        player2Anim = player2.GetComponent<Animator>();
    }

    public IEnumerator Wait(float time, Callback callback = null)
    {
        yield return new WaitForSeconds(time);
        if (callback != null)
        {
            callback();
        }
    }


	// Update is called once per frame
	void Update () {
		
        if (P1Life <= 0)
        {
            player1.SetActive(false);
            P2Wins.SetActive(true);
        }

        if (P2Life <= 0)
        {
            player2.SetActive(false);
            P1Wins.SetActive(true);
        }

        if (P1Shield <= 0)
        {
            player1Anim.SetBool("isShield", false);
            StartCoroutine(Wait(10, delegate () {
                // wont be executed until the Wait coroutine calls "callback()"
                P1Shield = 3;
            }));

        }

        if (P2Shield <= 0)
        {
            player2Anim.SetBool("isShield", false);
            StartCoroutine(Wait(10, delegate () {
                // wont be executed until the Wait coroutine calls "callback()"
                P2Shield = 3;
            }));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenu);
        }
    }


    public void HurtP1()
    {
        if (!player1Anim.GetBool("isShield"))
            P1Life -= 1;
        else
            P1Shield -= 1;

        for (int i = 0; i < p1Sticks.Length; i++)
        {
            if (P1Life > i)
            {
                p1Sticks[i].SetActive(true);
            }
            else
            {
                p1Sticks[i].SetActive(false);
            }
        }

        hurtSound.Play();
    }

    public void HurtP2()
    {
        print(player2Anim.GetBool("isShield").ToString());
        if (!player2Anim.GetBool("isShield"))
            P2Life -= 1;
        else
            P2Shield -= 1;

        for (int i = 0; i < p2Sticks.Length; i++)
        {
            if (P2Life > i)
            {
                p2Sticks[i].SetActive(true);
            }
            else
            {
                p2Sticks[i].SetActive(false);
            }
        }

        hurtSound.Play();
    }
}
