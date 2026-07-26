using UnityEngine;

public class MiniBossScript : MonoBehaviour
{ 
    private float speed = 5;
    private float jumpforce = 10;
    private Animator minibossAnimator;
    private BossHealthBar bossHealth;
    void Start()
    {
        minibossAnimator = FindAnyObjectByType<Animator>();
        bossHealth = FindAnyObjectByType<BossHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
