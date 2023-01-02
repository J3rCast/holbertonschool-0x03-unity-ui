using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
	public Rigidbody rb;
	private int score = 0;
	public int health = 5;
	public Text scoreText;
	public Text healthText;

    void Update()
    {
		if (health == 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
    }

    void FixedUpdate()
    {
		if (Input.GetKey("d"))
		{
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}

		if (Input.GetKey("a"))
		{
			rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -speed * Time.deltaTime);
		}
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Trap")
		{
			health -= 1;
			SetHealthText();
		}

		if (other.gameObject.tag == "Pickup")
		{
			score += 1;
			SetScoreText();
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == "Goal")
		{
			Debug.Log("You win!");
		}
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}

	void SetHealthText()
	{
		healthText.text = "Health: " + health;
	}
}
