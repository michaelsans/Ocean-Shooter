using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LootMenu : MonoBehaviour
{
    public GameObject player;
    public int playerHealth;
    public bool alive;
    public GameObject loot;
    public GameObject[] hp;
    private void Start()
    {
        loot.SetActive(false);
        for (int i = 0; i < hp.Length; i++)
        {
            hp[i].SetActive(true);
        }
    }
    void Update()
    {
        alive = player.GetComponent<NewPlayer>().alive;
        playerHealth = player.GetComponent<NewPlayer>().currentHealth;
        if (alive)
        {
            loot.SetActive(false);
            Time.timeScale = 1f;
        }  
        else if (!alive)
        {
            
            StartCoroutine(GameOver());
        }
    }

    public void SetHealthBar()
    {

        if (playerHealth == 15)
        {
            hp[2].GetComponent<Animator>().SetBool("estourar", true);
        }
        if (playerHealth == 10)
        {
            for (int i = 0; i < hp.Length - 1; i++)
            {
                hp[i].SetActive(true);
                hp[1].GetComponent<Animator>().SetBool("estourar", true);
            }
        }
        else if(playerHealth == 5)
        {
            for (int i = 0; i < hp.Length - 2; i++)
            {
                hp[i].SetActive(true);
                hp[0].GetComponent<Animator>().SetBool("estourar", true);
            }
        }
    }
    public void BackToBase()
    {
        SceneManager.LoadScene(0);
        NewAudioManager.instance.Play("Theme");
        NewAudioManager.instance.Play("bubbles"); 
    }

    IEnumerator GameOver()
    {
        loot.SetActive(true);
        yield return new WaitForSeconds(.7f);
        Time.timeScale = 0.1f;
    }

}
