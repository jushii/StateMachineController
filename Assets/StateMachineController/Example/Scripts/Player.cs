using UnityEngine;

public class Player : MonoBehaviour
{
	private int moveSpeed = 5;

	public void Move(Vector3 direction)
	{
		this.transform.Translate(this.moveSpeed * direction * Time.deltaTime);
	}

	public Vector3 GetMoveAxis()
	{
		float xDelta = Input.GetAxisRaw("Horizontal");
		float zDelta = Input.GetAxisRaw("Vertical");
		return new Vector3(xDelta, 0, zDelta);
	}
}
