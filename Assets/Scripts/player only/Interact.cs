using UnityEngine;
using UnityEngine.InputSystem;
using Unity.UI; 

public class Interact : MonoBehaviour
{

    public InputActionReference interact;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnEnable()
    {
        interact.action.Enable();
    }

    private void OnDisable()
    {
        interact.action.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
