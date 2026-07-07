using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D platformEffector;

    private float waitTime = 0.1f;

    private bool dropping = false;
    void Start()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S) && !dropping)
        {
            dropping = true;
            waitTime = 0.1f;
            platformEffector.rotationalOffset = 180f;
        }


        if (dropping)

            waitTime -= Time.deltaTime;

            if (waitTime <= 0f)
        {
            platformEffector.rotationalOffset = 0f;
            dropping = false;
        }

    }
}
