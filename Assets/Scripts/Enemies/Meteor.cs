using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
	[SerializeField] private Vector2 _speed;
	[SerializeField] private Vector2 _rotationSpeed;
	private float _curRotationSpeed;

	private void Start()
	{
		_curSpeed = Random.Range(_speed.x, _speed.y);
		_curRotationSpeed = Random.Range(_rotationSpeed.x, _rotationSpeed.y) * Mathf.Deg2Rad;
	}

	private void Update()
	{
		_curRotation = (_curRotation + _curRotationSpeed) % (Mathf.PI * 2);
		Move();
	}
}
