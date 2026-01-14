using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;

public class LineManager : MonoBehaviour
{
    [SerializeField] public GameObject[] bouncyNodes;
    [SerializeField] public GameObject[] noBounceNodes;
    [SerializeField] public GameObject[] normalNodes;
    [SerializeField] public GameObject[] nodes;
    Camera mainCam;
    [SerializeField] GameObject blueLine;
    [SerializeField] GameObject greenLine;
    [SerializeField] GameObject redLine;
    public bool drawLine = false;
    public bool delete = false;
    public Vector2 lineStartPos;
    public Vector2 mousePos;
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
            delete = true;
            mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
            for (int i = 0; i < bouncyNodes.Length; i++)
            {
                if (mousePos == new Vector2(bouncyNodes[i].transform.position.x, bouncyNodes[i].transform.position.y))
                {
                    drawLine = true;
                    lineStartPos = new Vector2(bouncyNodes[i].transform.position.x, bouncyNodes[i].transform.position.y);
                    delete = false;
                    Instantiate(blueLine);
                    break;
                }
            }
            for (int i = 0; i < noBounceNodes.Length; i++)
            {
                if (mousePos == new Vector2(noBounceNodes[i].transform.position.x, noBounceNodes[i].transform.position.y))
                {
                    drawLine = true;
                    lineStartPos = new Vector2(noBounceNodes[i].transform.position.x, noBounceNodes[i].transform.position.y);
                    delete = false;
                    Instantiate(redLine);
                    break;
                }
            }
            for (int i = 0; i < normalNodes.Length; i++)
            {
                if (mousePos == new Vector2(normalNodes[i].transform.position.x, normalNodes[i].transform.position.y))
                {
                    drawLine = true;
                    lineStartPos = new Vector2(normalNodes[i].transform.position.x, normalNodes[i].transform.position.y);
                    delete = false;
                    Instantiate(greenLine);
                    break;
                }
            }
        }
        if(click.WasReleasedThisFrame())
        {
            drawLine = false;
            delete = false;
        }
    }
}
