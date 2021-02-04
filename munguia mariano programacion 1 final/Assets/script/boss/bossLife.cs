using UnityEngine;
using UnityEngine.SceneManagement;

public class bossLife : MonoBehaviour
{
	public int health;
	public bool isInvulnerable = false;
	public Animator Animacion;
	private Renderer render;

	// Update is called once per frame
	void Update()
	{
	 render = GetComponent<Renderer>();
     Animacion = GetComponent<Animator>();
	}
	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
		
			return;
		
		health -= damage;

		if (health <=3)
		{
			render.material.color = Color.yellow;
			Animacion.SetBool("isEtapa2",true);
		}
		if (health <= 0)
		{
			Die();
		}
		if (health<=1)
        {
			render.material.color = Color.red;
		}
	}

	void Die()
	{
		
		Destroy(gameObject);
		SceneManager.LoadScene("win");
	}

}

