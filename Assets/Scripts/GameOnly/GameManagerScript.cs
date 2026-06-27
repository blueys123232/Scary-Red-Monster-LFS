using System.Collections;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //time before dying/respawning after death
    [SerializeField] private float RespawnDelay;

    [HideInInspector] public bool curRespawning;

    private PlayerMovement pMovement;
    private UIManager uiMan;

    public Vector3 respawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pMovement = FindAnyObjectByType<PlayerMovement>();
        uiMan = FindAnyObjectByType<UIManager>(); 

        //initial respawn point when we start the game
        respawnPoint = pMovement.transform.position;   
    }

    public void RespawnPlayer()
    {
        //this will be called when the player dies
        //if we are not currently respawning then respawn
        if (!curRespawning)
        {
            curRespawning = true;

            StartCoroutine(respawn());
        }
    }

    public IEnumerator respawn()
    {
        uiMan.FadeOut();

        yield return new WaitForSeconds(RespawnDelay);

        pMovement.transform.position = respawnPoint;
        curRespawning = false;
        uiMan.FadeIn();
    }
}
