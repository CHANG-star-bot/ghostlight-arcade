// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
	private bool levelCompleted;

	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player" && !levelCompleted)
		{
			levelCompleted = true;
			Invoke("CompleteLevel", 2f);
			anim.SetBool("collsion", value: true);
		}
	}

	private void CompleteLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
