using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GameField
{
	public static Rect GetBoundary()
	{
		var camera = GameManager.Ins.Camera;
		var h = camera.orthographicSize;
		var w = camera.aspect * h;
		return new Rect(
			camera.transform.position.x - w,
			camera.transform.position.y - h,
			w * 2, h * 2);
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
		var boundary = GetBoundary().Inflate(1);
		if (Random.value < 0.5)
			return new Vector2(
				Random.Range(boundary.xMin, boundary.xMax),
				Random.value < 0.5 ? boundary.yMin : boundary.yMax);
		else
			return new Vector2(
				Random.value < 0.5 ? boundary.xMin : boundary.xMax,
				Random.Range(boundary.yMin, boundary.yMax));
	}
}