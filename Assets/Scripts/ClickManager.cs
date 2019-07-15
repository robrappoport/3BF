using UnityEngine;
using System.Collections;

public class ClickManager : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
       
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Character")
                {
                    player.GetComponent<PlayerScript>().target = hit.collider.gameObject;
                    Debug.Log(hit.collider.gameObject.name);
                }
                

            }
        }
    }

}