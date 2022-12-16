using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    Vector2 rawInput;
    [SerializeField] float PadLeft;
    [SerializeField] float PadBottom;
    [SerializeField] float PadUp;
    [SerializeField] float PadRight;
    Vector2 minBounds;
    Vector2 maxBounds;
    void Start() {
        InitBounds();    
    }
    void Update()
    {
        Move();
    }


    void InitBounds(){
        Camera main = Camera.main;
        minBounds = main.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = main.ViewportToWorldPoint(new Vector2(1,1));
    }
    private void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + PadLeft,maxBounds.x - PadRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + PadBottom,maxBounds.y - PadUp);

        transform.position = newPos;
    }

    void OnMove(InputValue value){
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
