using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float leftBoundary = 0f;
    [SerializeField]
    private float rightBoundary = 0f;
    [SerializeField]
    private float moveSpeed = 1f;
    //gia su enemy di chuyen sang phai 
    private bool _isMovingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //lay vi tri hien tai 
        var currentPosition = transform.localPosition;
        if (currentPosition.x > rightBoundary)
        {
            // neu vi tri hien tai cua enemy > ben phai 
            // di chuyen sang trai 
            _isMovingRight = false;
        }
        else if (currentPosition.x < leftBoundary)
        {
            // neu vi tri hien tai cua enemy < ben trai 
            // di chuyen sang phai
            _isMovingRight = true;
        }
        //di chuyen ngang
        //(1,0,0) * 1 * 0.02 = (0.002,0,,0)
        var direction = Vector3.right;
        if (_isMovingRight == false)
        {
            direction = Vector3.left;
        }
        //var direction = _isMovingRight ? Vector3.right : Vector3.left;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // scale hien tai   
        // mat: trai >0 phai <0
        var currentScale = transform.localScale;
        if(
            (_isMovingRight==true && currentScale.x > 0 ) ||
            (_isMovingRight==false && currentScale.x < 0 ) 
            )
        {
            currentScale.x *= -1;
        }
        transform.localScale = currentScale;
    }
 
    private void OnTriggerEnter2D(Collider2D other )
    {
        var tag = other.gameObject.tag;
        if (tag == "Bullet")
        {
            Destroy(gameObject);
        }

    }
    private void OncollisionEnter2D(Collision2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
    
}
