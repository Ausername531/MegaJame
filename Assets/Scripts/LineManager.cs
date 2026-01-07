using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LineManager : MonoBehaviour
{
    [SerializeField] GameObject[] bouncyNodes;
    [SerializeField] GameObject[] noBounceNodes;
    [SerializeField] GameObject[] normalNodes;
    Camera mainCam;
    [SerializeField] GameObject line;
    public bool drawBlueLine = false;
    public bool drawRedLine = false;
    public bool drawGreenLine = false;
    public Vector2 lineStartPos;
    InputActionAsset input;
    InputAction click;
    void OnEnable()
    {
        input.FindActionMap("Game").Enable();
    }
    void OnDisable()
    {
        input.FindActionMap("Game").Disable();
    }
    void Awake()
    {
        click = InputSystem.actions.FindAction("Click");
        mainCam = Camera.main;
    }
    void Update()
    {
        if (click.WasPressedThisFrame())
        {
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
            for (int i = 0; i < bouncyNodes.Length; i++)
            {
                if (mousePos == new Vector2(bouncyNodes[i].transform.position.x, bouncyNodes[i].transform.position.y))
                {
                    drawBlueLine = true;
                    lineStartPos = new Vector2(bouncyNodes[i].transform.position.x, bouncyNodes[i].transform.position.y);
                    Instantiate(line);
                    break;
                }
            }
            for (int i = 0; i < noBounceNodes.Length; i++)
            {
                if (mousePos == new Vector2(noBounceNodes[i].transform.position.x, noBounceNodes[i].transform.position.y))
                {
                    drawRedLine = true;
                    lineStartPos = new Vector2(noBounceNodes[i].transform.position.x, noBounceNodes[i].transform.position.y);
                    Instantiate(line);
                    break;
                }
            }
            for (int i = 0; i < normalNodes.Length; i++)
            {
                if (mousePos == new Vector2(normalNodes[i].transform.position.x, normalNodes[i].transform.position.y))
                {
                    drawGreenLine = true;
                    lineStartPos = new Vector2(normalNodes[i].transform.position.x, normalNodes[i].transform.position.y);
                    Instantiate(line);
                    break;
                }
            }
        }
        if(click.WasReleasedThisFrame())
        {
            drawBlueLine = false;
            drawRedLine = false;
            drawGreenLine = false;
        }
    }
}
