using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    LineManager lm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lm = GameObject.FindWithTag("LineManager").GetComponent<LineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lm.mousePos;
        if(lm.delete)
        {
            GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
        }    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("okay");
       Destroy(collision.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("okay2");
        Destroy(collision.gameObject);
    }
}
