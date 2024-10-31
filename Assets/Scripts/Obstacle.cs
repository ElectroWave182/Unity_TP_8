using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Obstacle: MonoBehaviour
{
	public Material materiauTouche;
	
	private MeshRenderer aspect;
	private Material materiauBase;
	
	
	void Start ()
	{
		this. aspect = GetComponent <MeshRenderer> ();
		this. materiauBase = this. aspect. material;
	}
	
	
	public void OnCollisionStay ()
	{
		this. aspect. material = this. materiauTouche;
	}
	
	public void OnCollisionExit ()
	{
		this. aspect. material = this. materiauBase;
	}
}
