using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public Button playButton;
	public Button quitButton;
	public Button optionsButton;
	public GameObject optionsMenu;
	public Material trapMat;
	public Material goalMat;
	public Toggle colorblindMode;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayMaze);
        quitButton.onClick.AddListener(QuitMaze);
        optionsButton.onClick.AddListener(Options);
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	public void PlayMaze()
	{
		if (colorblindMode.isOn)
		{
			trapMat.color = new Color32(255, 112, 0, 1);
			goalMat.color = Color.blue;
		}
		else
		{
			trapMat.color = Color.red;
			goalMat.color = Color.green;
		}
		SceneManager.LoadScene("maze");
	}

	public void QuitMaze()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}

	public void Options()
	{
		optionsMenu.SetActive(true);
		gameObject.SetActive(false);
	}
}
