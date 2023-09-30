using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharController : MonoBehaviour
{
	public float atack1Damage = 1;
	public Transform movePoint;
	public Collider2D attackCollider;
	public Collider2D moveCheckCollider;
	public int titlesToMove;
	private bool canItMove;
	private GameObject target=null;
	private bool targetExists;
	public LayerMask stopsMove;
	
	void Start()
	{
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
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag=="Enemy")
		{
			canItMove = false;
			Debug.Log("Collision with obstcle");
		}
		if(collision.gameObject.tag == "Enemy")
		{
			target=collision.gameObject;
			targetExists = true;
			Debug.Log("Collison with enemy");
		}
	}
	public void Attack()
	{
		//if (targetExists) target.takeDamage(atack1Damage);
		//else Debug.Log("No targert");
	}
	public void Update()
	{
		if (!Physics2D.OverlapCircle(movePoint.position, stopsMove)){
			canItMove = true;
			Debug.Log("cant move(based on layer)");
		}
	}
}
