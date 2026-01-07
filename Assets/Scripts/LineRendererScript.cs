using UnityEngine;
using UnityEngine.InputSystem;

public class LineRendererScript : MonoBehaviour
{
    LineManager lm;
    Camera mainCam;
    GameObject[] nodes;
    private LineRenderer lineRenderer;
    private bool lockedIn = false;
    private Vector2 lineStartPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lm = GameObject.FindWithTag("LineManager").GetComponent<LineManager>();
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
            if(lm.drawBlueLine)
            {
                lineRenderer.startColor = new Vector4(0, 0, 255, 1);
                lineRenderer.endColor = new Vector4(0, 0, 255, 1);
                lineRenderer.SetPosition(1, mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
            }
            if(lm.drawRedLine)
            {
                lineRenderer.startColor = new Vector4(255, 0, 0, 1);
                lineRenderer.endColor = new Vector4(255, 0, 0, 1);
                lineRenderer.SetPosition(1, mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
            }
            if(lm.drawGreenLine)
            {
                lineRenderer.startColor = new Vector4(0, 255, 0, 1);
                lineRenderer.endColor = new Vector4(0, 255, 0, 1);
                lineRenderer.SetPosition(1, mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
            }
        }
        if (!lm.drawBlueLine && !lm.drawGreenLine && !lm.drawRedLine && !lockedIn)
        {
            lockedIn = true;
            Vector2 position2 = new Vector2(Mathf.Round(mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x), Mathf.Round(mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y));
            
            lineRenderer.SetPosition(1, position2);
        }
    }
}
