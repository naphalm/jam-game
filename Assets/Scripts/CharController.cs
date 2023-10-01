using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CharController : MonoBehaviour
{
	public float atack1Damage = 1;
	public Transform movePoint;
	public Collider2D attackCollider;
	public Collider2D moveCheckCollider;
	public int titlesToMove;
	static public bool canItMove;
	private enemyScript target =null;
	private bool targetExists;
	public LayerMask stopsMove;
	public GameObject attackButton;
	
	void Start()
	{
		attackButton.SetActive(false);
		canItMove = true;
	}
	public void Move()
	{
		if (canItMove)
		{
			for (int i = 1; i <= titlesToMove; i++)
			{
				transform.position = movePoint.position;
			}
		
		}
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
		{
			canItMove = false;
			Debug.Log("Collision with obstcle");
		}
		if(collision.gameObject.tag == "Enemy")
		{
			attackButton.SetActive(true);
			canItMove = false;
			target=collision.gameObject.GetComponent<enemyScript>();
			target.EnemyDeath.AddListener(OnEnemyTargetDeath);
			targetExists = true;
			Debug.Log("Collison with enemy");
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}
	public void Attack()
	{
		//if (targetExists) target.takeDamage(atack1Damage);
		//else Debug.Log("No targert");
	}
	public void Update()
	{

	}

	private void OnEnemyTargetDeath()
	{
		target = null;
		canItMove = true;
	}
}
