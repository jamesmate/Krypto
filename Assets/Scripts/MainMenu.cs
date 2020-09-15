using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Button startButton;
	public Button quitButton;

	void Start()
	{
		startButton = startButton.GetComponent<Button> ();
		quitButton = quitButton.GetComponent<Button> ();
	}

	 public void Quit()
	{
		Application.Quit();
	}
		

	public void Play()
	{
		SceneManager.LoadScene ("Scene1");
	}
}
