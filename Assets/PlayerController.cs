using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider speedSlider;
    public float speed;
    public int speedInt;

    private Rigidbody rb;
    private Renderer rend;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        speedSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void LateUpdate()
    {
        
    }

    public void ValueChangeCheck()
    {
        speed = speedSlider.value * 10;
        //speedInt = (int)speed;
        //Debug.Log("The speed value changed to " + speed.ToString() + " or " + speedInt.ToString() + " as an int.");
        switch ((int)speed)
        {
            case 0:
                rend.material.SetColor("_Color", Color.red);
                break;
            case 5:
                rend.material.SetColor("_Color", Color.yellow);
                break;
            case 10:
                rend.material.SetColor("_Color", Color.green);
                break;
        }

    }

}
