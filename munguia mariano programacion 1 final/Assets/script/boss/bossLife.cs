using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class bossLife : MonoBehaviour
{
	public int health;
	public bool isInvulnerable = false;
	public Animator Animacion;
	private Renderer render;
	public GameObject chest;
	public GameObject[] fire;
	public GameObject fireball;

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
			StartCoroutine(fireballattack());
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
		Animacion.Play("die");
		chest.gameObject.SetActive(true);
		Destroy(this.gameObject, 1f);
		
	}

	public IEnumerator fireballattack()
    {
		while (true)
		{
			int index = Random.Range(0, fire.Length);
			GameObject newfire = GameObject.Instantiate(fireball);
			newfire.transform.position = fire[index].transform.position;

			yield return new WaitForSeconds(2);
		}
    }
	
}

