using UnityEngine;

public class FinishConditions : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("NextLevel");
        canvas.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canvas.SetActive(true);
    }
}
