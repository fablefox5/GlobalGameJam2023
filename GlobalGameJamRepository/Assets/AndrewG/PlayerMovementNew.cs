using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
	public bool canMove = true;
	public Vector3 moveChar = Vector3.zero;
	public int line = 1;
	public int targetLine = 1;

	void Start()
	{
		
	}

	void Update()
	{
		Vector3 pos = gameObject.transform.position;
		if(line.Equals(targetLine))
		{
			if(targetLine == 0 && pos.x == -2)
			{
				gameObject.transform.position = new Vector3(-2f, pos.y, pos.z);
				line = targetLine;
				canMove = true;
				moveChar.x = 0;
			}
			else if(targetLine == 1 && pos.x > 0 || pos.x < 0)
			{
				if(line == 0 && pos.x > 0)
				{
					gameObject.transform.position = new Vector3(0, pos.y, pos.z);
					line = targetLine;
					canMove = true;
					moveChar.x = 0;
				}
				else if (line == 2 && pos.x < 0)
				{
					gameObject.transform.position = new Vector3(0, pos.y, pos.z);
					line = targetLine;
					canMove = true;
					moveChar.x = 0;
				}
			}
			else if(targetLine == 2 && pos.x > 2)
			{
				gameObject.transform.position = new Vector3(2f, pos.y, pos.z);
				line = targetLine;
				canMove = true;
				moveChar.x = 0;
			}
		}
		checkInputs();
		
	}

	void checkInputs()
	{
		if((Input.GetKeyDown(KeyCode.W)) && canMove && line > 0)
		{
			targetLine--;
			canMove = false;
			moveChar.x = -4;
		}
		if((Input.GetKeyDown(KeyCode.S)) && canMove && line < 2)
		{
			targetLine--;
			canMove = false;
			moveChar.x = 4;
		}
	}

}
