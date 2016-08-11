using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

    protected Animator animator;
    private float directionX = 0;
    private float directionY = 0;
    private bool walking = false;

	void Start () {
		animator = GetComponent<Animator>();

    }
	
	void Update () {

        if (animator)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            walking = true;
            if (h > 0)
            {
                directionX = 1;
                directionY = 0;
            }
            else if (h < 0)
            {
                directionX = -1;
                directionY = 0;
            }
            else if(v>0)
            {
                directionX = 0;
                directionY = 1;
            }
            else if(v<0)
            {
                directionX = 0;
                directionY = -1;
            }
            else
            {

                walking = false;
            }

            if (walking)
            {
                transform.Translate(new Vector3(directionX, directionY, 0) * Time.deltaTime * 4f);
            }

            animator.SetFloat("DirectionX", directionX);
            animator.SetFloat("DirectionY", directionY);
			animator.SetBool("Walking", walking);
        }
	}

}
