using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {

    public float speed;
    public Text minusText; 
    public Text countText;
    public Text winText;
    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int minusCount;
    private int plusCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        scoreText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            plusCount = plusCount + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("MinusUp"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            minusCount = minusCount + 1;
            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "Count " + count.ToString();

        minusText.text = "Negative Count " + minusCount.ToString();

        if (plusCount >= 12)
        {
            winText.text = "YOU WIN!";
            scoreText.text = "You Finished with a score of: " + count.ToString();
        }
    }
}
