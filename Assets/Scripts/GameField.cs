using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GameField
{
	public static Rect GetBoundary()
	{
		return GameManager.Ins.Camera.GetBoundary();
	}

	public static Vector2 LoopInBoundary(Vector2 pos, float inflateBoundary = 0)
	{
		var boundary = GetBoundary().Inflate(inflateBoundary);
		if (pos.x > boundary.xMax) pos.x -= boundary.width;
		if (pos.x < boundary.xMin) pos.x += boundary.width;
		if (pos.y > boundary.yMax) pos.y -= boundary.height;
		if (pos.y < boundary.yMin) pos.y += boundary.height;
		return pos;
	}

	public static Vector2 RandomPosOutside()
	{
		return RandomPosOutside(RandomSide());
	}

	public static Vector2 RandomPosOutside(Vector2 side)
	{
		var boundary = GetBoundary().Inflate(1);
		return side.x == 0 ?
			new Vector2(
				Random.Range(boundary.xMin, boundary.xMax),
				side.y < 0.5 ? boundary.yMin : boundary.yMax)
		  : new Vector2(
				side.x < 0.5 ? boundary.xMin : boundary.xMax,
				Random.Range(boundary.yMin, boundary.yMax));
	}

	public static Vector2 RandomSide()
	{
		if (Random.value < 0.5)
			return new Vector2(0, Utils.RandomSign());
		else
			return new Vector2(Utils.RandomSign(), 0);
	}

	public static Vector2 RandomPosInside()
	{
		var boundary = GetBoundary().Inflate(-2);
		return new Vector2(
			Random.Range(boundary.xMin, boundary.xMax),
			Random.Range(boundary.yMin, boundary.yMax)
		);
	}
}
