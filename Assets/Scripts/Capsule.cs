using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Capsule: MonoBehaviour
{
	private Transform leJoueur;
	
	
	public void Start ()
	{
		leJoueur = transform. root. Find ("joueur");
	}
	
	
	public void OnCollisionEnter (Collision infos)
	{
		Transform objetCollisionne = infos. transform;
		if (objetCollisionne == this. leJoueur)
		{
			this. leJoueur. localScale *= 1.5f;
			Destroy (transform. gameObject);
		}
	}
}
