using UnityEngine;

public class MouseControll : MonoBehaviour
{
    private bool clicked;
    void Update()
    {
        // Mouse pozisyonunu world pozisyonuna çevir
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 2D Raycast at
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        // Eðer fare bu objenin üzerinde deðilse
        if (hit.collider == null || hit.collider.gameObject != gameObject)
        {
            if(Input.GetMouseButtonDown(1))
            {
                clicked = false;
                Debug.Log(clicked);
            }
        }
        else
        {
            if(Input.GetMouseButtonUp(1))
            {
                clicked = true;
                Debug.Log(clicked);
            }
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name=="menzil"&&clicked)
        {
            Player.isEnemyClicked = true;
            Debug.Log(Player.isEnemyClicked);
        }
        else
        {
            Player.isEnemyClicked = false;
            Debug.Log(Player.isEnemyClicked);
        }
    }

}
