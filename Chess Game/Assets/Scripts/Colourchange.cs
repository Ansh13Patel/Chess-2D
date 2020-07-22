using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colourchange : MonoBehaviour
{

    private Vector2 position;
    private Vector2 direction;
    private float length;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.Raycast(position, direction, length);
            Physics2D.Raycast(new Vector2((Input.mousePosition).x,(Input.mousePosition).y), Vector2.zero, 0f);

            this.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        
    }
}
