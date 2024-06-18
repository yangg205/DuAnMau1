using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float leftBomoving;
    [SerializeField]
    private float rightBomoving;
    private bool isMovingleft = true;
    public float health;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private ParticleSystem _efboss;
    [SerializeField]
    private GameObject _Win;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        _healthSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left * moveSpeed* Time.deltaTime);   
        var currentPosition = transform.localPosition;
        if (currentPosition.x < leftBomoving)
        {
            isMovingleft = false;
        }
        else if (currentPosition.x
            > rightBomoving)
        {
            isMovingleft = true;
        }
        var direction = isMovingleft ? Vector3.left : Vector3.right;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        var currentScale = transform.localScale;
        if ((isMovingleft == true && currentScale.x < 0) || (isMovingleft == false && currentScale.x > 0))
        {
            currentScale.x *= -1;
        }
        transform.localScale = currentScale;
        if (health == 0)
        {
            //tao hieu ung no
            /*var ps = Instantiate(_efboss, gameObject.transform.localPosition, Quaternion.identity);*/
            Destroy(gameObject);
                _Win.SetActive(true);
                Time.timeScale = 0;
            
        }
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            //huy vien dan
            Destroy(other.gameObject);
            health -= 20f;
            _healthSlider.value = health;
           /* if(health == 0)
            {
                //tao hieu ung no
                var ps = Instantiate(_efboss, gameObject.transform.localPosition, Quaternion.identity);
                Destroy(gameObject);
            }*/
        }
    }
}
