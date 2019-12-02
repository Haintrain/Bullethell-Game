using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 10f;
    private float moveHorizontal, moveVertical;

    Animator anims;
    Rigidbody2D rb;

    void Start()
    {
        anims = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        anims.SetFloat("Speed", Mathf.Sqrt(Mathf.Pow(moveHorizontal, 2) + Mathf.Pow(moveVertical, 2)));

        rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);



        //Char look at mouse code
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}


