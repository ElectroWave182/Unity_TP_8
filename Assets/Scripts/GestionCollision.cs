using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class GestionCollision: MonoBehaviour
{
	private Transform
		obstacles,
		capsule
	;
	private Rigidbody objetPhysique;
    private float vitesseTranslation = 0.2f;
    private float vitesseRotation = 2f;
	private bool enCoursTranslation = false;
	private bool enCoursRotation = false;
	private bool charge = false;
	
	
    void Start ()
    {
		this. obstacles = transform. root. Find ("obstacles");
		this. capsule = this. obstacles. Find ("capsule");
        this. objetPhysique = GetComponent <Rigidbody> ();
    }
	
	
    void FixedUpdate ()
    {
		// Entrées clavier ↑, ↓ et ←, →
        float translation = Input. GetAxis ("Vertical");
        float rotation    = Input. GetAxis ("Horizontal");
		
		// Remise à zéro de l'inertie translative
		if (translation != 0)
		{
			this. enCoursTranslation = true;
		}
		else if (this. enCoursTranslation)
		{
			this. enCoursTranslation = false;
			this. objetPhysique. velocity = Vector3. zero;
		}
		
		// Remise à zéro de l'inertie rotative
		if (rotation != 0)
		{
			this. enCoursRotation = true;
		}
		else if (this. enCoursRotation)
		{
			this. enCoursRotation = false;
			this. objetPhysique. angularVelocity = Vector3. zero;
		}
		
		translation *= this. vitesseTranslation;
		rotation    *= this. vitesseRotation;
		
        transform. Translate (0, 0, translation);
        transform. Rotate (0, rotation, 0);
    }
	
	
	public void OnCollisionEnter (Collision infos)
	{
		Transform objetCollisionne = infos. transform;
		
		if (objetCollisionne. parent == this. obstacles && this. charge)
		{
			Destroy (objetCollisionne. gameObject);
			if (this. obstacles. childCount <= 1)
			{
				Debug. Log ("Au-revoir");
				UnityEditor. EditorApplication. isPlaying = false;
				Application. Quit ();
			}
		}
		
		if (objetCollisionne == this. capsule)
		{
			this. charge = true;
		}
	}
}
