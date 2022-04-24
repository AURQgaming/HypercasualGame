using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColisionScript : MonoBehaviour
{
    public Carmovement playerScript;
    public GameControler gameControler;
    public Score score;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="collectable")
        {
            score.AddScore(1);
            Destroy(other.gameObject);
        } 
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Obstracles")        
        {
            gameControler.GameOver();
            playerScript.enabled = false;
        }
    }
}
