using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour
	{
		public Transform Target;
	public Camera SpringCamera;

		public float Stiffness = 1800.0f;
		public float Damping = 600.0f;
		public float Mass = 50.0f;
		public Vector3 DesiredOffset = new Vector3(0.0f, 3.5f, -4.0f);
		public Vector3 LookAtOffset = new Vector3(0.0f, 3.1f, 0.0f);

		private Vector3 desiredPosition = Vector3.zero;
		private Vector3 cameraVelocity = Vector3.zero;

		// Use this for initialization
		void Start ()
		{

		}

		void FollowUpdate()
		{
			Vector3 stretch = SpringCamera.transform.position - desiredPosition;
			Vector3 force = -Stiffness * stretch - Damping * cameraVelocity;

			Vector3 acceleration = force / Mass;

			cameraVelocity += acceleration * Time.deltaTime;

			SpringCamera.transform.position += cameraVelocity * Time.deltaTime;

			Matrix4x4 CamMat = new Matrix4x4();
			CamMat.SetRow(0, new Vector4(-Target.forward.x, -Target.forward.y, -Target.forward.z));
			CamMat.SetRow(1, new Vector4(Target.up.x, Target.up.y, Target.up.z));
			Vector3 modRight = Vector3.Cross(CamMat.GetRow(1), CamMat.GetRow(0));
			CamMat.SetRow(2, new Vector4(modRight.x, modRight.y, modRight.z));

			desiredPosition = Target.position + TransformNormal(DesiredOffset, CamMat);
			Vector3 lookat = Target.position + TransformNormal(LookAtOffset, CamMat);

			SpringCamera.transform.LookAt(lookat, Target.up);
			//SpringCamera.projectionMatrix = Matrix4x4.Perspective(SpringCamera.fieldOfView, SpringCamera.aspect, SpringCamera.near, SpringCamera.far);

			//print("cam = " + SpringCamera.transform.position.ToString());
		}

		// Update is called once per frame
		void Update ()
		{
			FollowUpdate();
		}

		Vector3 TransformNormal(Vector3 normal, Matrix4x4 matrix)
		{
			Vector3 transformNormal = new Vector3();
			Vector3 axisX = new Vector3(matrix.m00, matrix.m01, matrix.m02);
			Vector3 axisY = new Vector3(matrix.m10, matrix.m11, matrix.m12);
			Vector3 axisZ = new Vector3(matrix.m20, matrix.m21, matrix.m22);
			transformNormal.x = Vector3.Dot(normal, axisX);
			transformNormal.y = Vector3.Dot(normal, axisY);
			transformNormal.z = Vector3.Dot(normal, axisZ);

			return transformNormal;

		}
	}