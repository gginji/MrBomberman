using UnityEngine;
using System.Collections;

public class DeplacementPersonnageScript : MonoBehaviour {
	
		
	[SerializeField]
	private Transform _pad1;
	
	[SerializeField]
	private float _padSpeed=4f;
	
		public float padSpeed
	{
		get {return _padSpeed;}
		set { _padSpeed=value;}
	}
	
	public Transform pad1
	{
		get {return _pad1;}
		set { _pad1=value;}
	}
	
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
		void FixedUpdate (){
			
			/*********NE TOUCHER QUE LE X ET LE Z*************/

		if (Input.GetKey(KeyCode.DownArrow))
		{	
			Vector3 m_Down;
			m_Down.x=0.0f;
			m_Down.y=0.0f;
			m_Down.z=-1.0f;
			
			//_pad1.Translate(Vector3.down* _padSpeed*Time.deltaTime);
		pad1.Translate(	m_Down *_padSpeed*Time.deltaTime);
			
		}
			
			if (Input.GetKey(KeyCode.UpArrow))
		{	
			Vector3 m_Up;
			m_Up.x=0.0f;
			m_Up.y=0.0f;
			m_Up.z=1.0f;
			
			//_pad1.Translate(Vector3.up* _padSpeed*Time.deltaTime);
			_pad1.Translate(m_Up* _padSpeed*Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{	
			Vector3 m_Left;
			m_Left.x=-1.0f;
			m_Left.y=0.0f;
			m_Left.z=0.0f;
			//_pad1.Translate(Vector3.left* _padSpeed*Time.deltaTime);
		_pad1.Translate(m_Left* _padSpeed*Time.deltaTime);
		}
			
			if (Input.GetKey(KeyCode.RightArrow))
		{	
			Vector3 m_Right;
			m_Right.x=1.0f;
			m_Right.y=0.0f;
			m_Right.z=0.0f;
		//	_pad1.Translate(Vector3.right* _padSpeed*Time.deltaTime);
		_pad1.Translate(m_Right* _padSpeed*Time.deltaTime);
		}
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		//if ( col.
	}
}
