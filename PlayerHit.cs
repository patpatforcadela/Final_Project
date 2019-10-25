using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FPSControllerLPFP;

public class PlayerHit : MonoBehaviour
{
    private float playerHealth;
    private float maxHealth = 100f;
    public Slider healthBar;
    public Text title;
    public GameObject gameOverContainer;
    public GameObject gameOverTimer;
    public GameObject player;
    public void Start()
    {
        playerHealth = maxHealth;
        healthBar.value = playerHealth / maxHealth;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shoulder")
        {
            playerWasHit(15f);
        }
    }
    public void playerWasHit(float damage)
    {
        playerHealth -= damage;
        healthBar.value = playerHealth / maxHealth;
        if (playerHealth <= 0)
        {
            gameOverContainer.SetActive(true);
            Time.timeScale = 0f;
            title.text = "Game Over";
            player.GetComponent<FpsControllerLPFP>().displayCursor();
        }
    }
}
