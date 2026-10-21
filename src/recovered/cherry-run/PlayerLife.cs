// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
	private Rigidbody2D rb;

	private Animator anim;

	private int cherries = AllControl.GameManager.Instance.score;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("trap"))
		{
			Die();
		}
	}

	private void Die()
	{
		rb.bodyType = RigidbodyType2D.Static;
		anim.SetTrigger("death");
		AllControl.GameManager.Instance.score = cherries;
	}

	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
