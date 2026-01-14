using UnityEngine;
using UnityEngine.InputSystem;

public class RedLine : MonoBehaviour
{
    LineManager lm;
    Camera mainCam;
    GameObject[] nodes;
    private LineRenderer lineRenderer;
    private BoxCollider2D coll;
    private bool lockedIn = false;
    private Vector2 lineStartPos;
    private bool touchingRed = false;
    private bool touchingBlue = false;
    private bool touchingGreen = false;
    private bool touchingWhite = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lm = GameObject.FindWithTag("LineManager").GetComponent<LineManager>();
        coll = GetComponent<BoxCollider2D>();
        lineStartPos = lm.lineStartPos;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, lineStartPos);
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lockedIn)
        {
            lineRenderer.startColor = new Vector4(255, 0, 0, 1);
            lineRenderer.endColor = new Vector4(255, 0, 0, 1);
            lineRenderer.SetPosition(1, mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        }
        if (!lm.drawLine && !lockedIn)
        {
            lockedIn = true;
            Vector2 position2 = new Vector2(Mathf.Round(mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x), Mathf.Round(mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y));
            
            lineRenderer.SetPosition(1, position2);
            float distance = Vector3.Distance(lineStartPos, position2);
            coll.size = new Vector2(distance, 0.5f);
            transform.position = (lineStartPos + position2) / 2;
            Vector3 direction = lineStartPos - position2;
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(direction, -transform.right)*-1);
            for (int i = 0; i < lm.normalNodes.Length; i++)
            {
                if (position2 == new Vector2(lm.normalNodes[i].transform.position.x, lm.normalNodes[i].transform.position.y))
                {
                    touchingGreen = true;
                }
            }
            for (int i = 0; i < lm.bouncyNodes.Length; i++)
            {
                if (position2 == new Vector2(lm.bouncyNodes[i].transform.position.x, lm.bouncyNodes[i].transform.position.y))
                {
                    touchingBlue = true;
                }
            }
            for (int i = 0; i < lm.noBounceNodes.Length; i++)
            {
                if (position2 == new Vector2(lm.noBounceNodes[i].transform.position.x, lm.noBounceNodes[i].transform.position.y))
                {
                    touchingGreen = true;
                }
            }
            for (int i = 0; i < lm.nodes.Length; i++)
            {
                if (position2 == new Vector2(lm.nodes[i].transform.position.x, lm.nodes[i].transform.position.y))
                {
                    touchingWhite = true;
                }
            }
            if (!touchingBlue && !touchingGreen && !touchingRed && !touchingWhite)
            {
                Destroy(gameObject);
            }
        }
        //check if mouse is over line
        if (lm.delete)
        {
            Vector2 ray = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            if (Physics2D.Raycast(ray, new Vector3(0, 0, 0)))
            {
                RaycastHit2D hit = Physics2D.Raycast(ray, new Vector3(0, 0, 0));
                if (hit.collider == gameObject.GetComponent<Collider2D>())
                {
                    Debug.Log("plonk");
                    Destroy(gameObject);
                }
            }
        }
    }
}
