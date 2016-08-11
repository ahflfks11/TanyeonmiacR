using UnityEngine;
using System.Collections;

public class fadein : MonoBehaviour {

	public Renderer _renderer;
	bool one = false;

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer> ();
		StartCoroutine (Fadein ());
	}
	IEnumerator Fadein(){
		if (one == false)
		{
			yield return new WaitForSeconds (1f);
			for (float i = 1f; i >= 0; i -= 0.01f)
			{
				Color colr = new Vector4 (1, 1, 1, i);
				_renderer.material.color = colr;
				yield return 0;
			}
		}
		else
		{

		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
