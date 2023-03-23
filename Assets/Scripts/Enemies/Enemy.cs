using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Movable
{
	[SerializeField] private ParticleSystem _explosionParticles;
	internal bool _enteredField = false;
	internal bool _destructed = false;

	internal void Move()
	{
		if (!_enteredField)
			_enteredField = GameField.GetBoundary().Contains(transform.position);

		Move(_enteredField);
	}

	internal void Destruct(Player player)
	{
		_destructed = true;
		if (_explosionParticles)
			Instantiate(_explosionParticles, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (_destructed) return;
		if (collision.TryGetComponent<Player>(out var player))
		{
			Destruct(player);
		}
	}
}
