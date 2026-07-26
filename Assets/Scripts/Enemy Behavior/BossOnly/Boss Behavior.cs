using UnityEngine;

public class BossBehavior : MonoBehaviour
{

    private float speed;
    private Animator Bossanimator;
    private float movespeed;
    private BossHealthBar BHB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BHB = GetComponent<BossHealthBar>();
        Bossanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
