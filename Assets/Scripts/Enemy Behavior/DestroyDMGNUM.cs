using UnityEngine;

public class DestroyDMGNUM : MonoBehaviour
{
    [SerializeField] private float ActiveTime;
    // Update is called once per frame
    void Update()
    {
        ActiveTime -= Time.deltaTime;

        if (ActiveTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
