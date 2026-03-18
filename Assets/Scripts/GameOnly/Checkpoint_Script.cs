using UnityEngine;

public class Checkpoint_Script : MonoBehaviour
{
    SpriteRenderer spRenderer;
    GameManagerScript gameManagerScript;


    //AudioSource activate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        spRenderer = GetComponent<SpriteRenderer>();
        gameManagerScript = FindAnyObjectByType<GameManagerScript>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //if we trigger a checkpoint set it to be our respawn point
            if(gameManagerScript.respawnPoint != this.gameObject.transform.position)
            {

                gameManagerScript.respawnPoint = this.gameObject.transform.position;
            }
            //go through all checkpoints and "reset" them
            Checkpoint_Script[] checkpoints = FindObjectsOfType<Checkpoint_Script>();
            foreach (Checkpoint_Script cPoint in checkpoints)
            {
                cPoint.spRenderer.color = Color.red;
            }

            //this should only activate the one we walk through and "deactivate" previous one
            spRenderer.color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
