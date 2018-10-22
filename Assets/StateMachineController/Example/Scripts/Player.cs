using UnityEngine;

public class Player : MonoBehaviour
{
	private int moveSpeed = 5;
	
	internal void Move(Vector3 direction)
	{
		this.transform.Translate(this.moveSpeed * direction * Time.deltaTime);
	}
}
