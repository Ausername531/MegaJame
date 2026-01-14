using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    InputActionAsset input;
    InputAction space;
    Vector2 startPos;
    void OnEnable()
    {
        input.FindActionMap("Ball").Enable();
    }
    void OnDisable()
    {
        input.FindActionMap("Ball").Disable();
    }
    void Awake()
    {
        space = InputSystem.actions.FindAction("Space");
        startPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(space.WasPressedThisFrame() && rb.gravityScale == 0)
        {
            rb.gravityScale = 1;
        }
        else if (space.WasPressedThisFrame() && rb.gravityScale == 1)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = new Vector2(0, 0);
            gameObject.transform.position = startPos;
        }
    }
}
