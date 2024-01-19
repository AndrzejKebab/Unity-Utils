using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public static class TilemapExtensions
{
	public delegate bool TileComparer(TileBase tileA, TileBase tileB);

	/// <summary>
	/// Clears the tile at the specified position on the Tilemap.
	/// </summary>
	/// <param name="position">The position of the tile to clear.</param>
	public static void ClearTile(this Tilemap tilemap, Vector3Int position)
	{
		tilemap.SetTile(position, null);
	}

	/// <summary>
	/// Gets all used tiles with their positions from an ITilemap.
	/// </summary>
	/// <returns>An enumerable collection of tile positions and their corresponding tiles.</returns>
	public static IEnumerable<(Vector3Int, TileBase)> GetUsedTiles(this ITilemap tilemap)
	{
		foreach (var position in tilemap.cellBounds.allPositionsWithin)
		{
			var tile = tilemap.GetTile(position);
			if (tile)
			{
				yield return (position, tile);
			}
		}
	}

	/// <summary>
	/// Gets all used tiles with their positions from a Tilemap.
	/// </summary>
	/// <returns>An enumerable collection of tile positions and their corresponding tiles.</returns>
	public static IEnumerable<(Vector3Int, TileBase)> GetUsedTiles(this Tilemap tilemap)
	{
		foreach (var position in tilemap.cellBounds.allPositionsWithin)
		{
			var tile = tilemap.GetTile(position);
			if (tile)
			{
				yield return (position, tile);
			}
		}
	}

	/// <summary>
	/// Gets all used tiles of a specific type with their positions from an ITilemap.
	/// </summary>
	/// <typeparam name="TTile">The type of TileBase to filter for.</typeparam>
	/// <returns>An enumerable collection of tile positions and their corresponding tiles.</returns>
	public static IEnumerable<(Vector3Int, TTile)> GetUsedTiles<TTile>(this ITilemap tilemap) where TTile : TileBase
	{
		foreach (var position in tilemap.cellBounds.allPositionsWithin)
		{
			var tile = tilemap.GetTile<TTile>(position);
			if (tile)
			{
				yield return (position, tile);
			}
		}
	}

	/// <summary>
	/// Gets all used tiles of a specific type with their positions from a Tilemap.
	/// </summary>
	/// <typeparam name="TTile">The type of TileBase to filter for.</typeparam>
	/// <returns>An enumerable collection of tile positions and their corresponding tiles.</returns>
	public static IEnumerable<(Vector3Int, TTile)> GetUsedTiles<TTile>(this Tilemap tilemap) where TTile : TileBase
	{
		foreach (var position in tilemap.cellBounds.allPositionsWithin)
		{
			var tile = tilemap.GetTile<TTile>(position);
			if (tile)
			{
				yield return (position, tile);
			}
		}
	}

	/// <summary>
	/// Checks if the tile at the specified position on the ITilemap matches a given tile.
	/// </summary>
	/// <param name="position">The position of the tile to check.</param>
	/// <param name="tile">The tile to compare against.</param>
	/// <returns>True if the tile matches, false otherwise.</returns>
	public static bool IsTile(this ITilemap tilemap, Vector3Int position, TileBase tile)
	{
		return tilemap.GetTile(position) == tile;
	}

	/// <summary>
	/// Checks if the tile at the specified position on the Tilemap matches a given tile.
	/// </summary>
	/// <param name="position">The position of the tile to check.</param>
	/// <param name="tile">The tile to compare against.</param>
	/// <returns>True if the tile matches, false otherwise.</returns>
	public static bool IsTile(this Tilemap tilemap, Vector3Int position, TileBase tile)
	{
		return tilemap.GetTile(position) == tile;
	}

	/// <summary>
	/// Checks if the tile at the specified position on the ITilemap matches a given tile using a custom comparer.
	/// </summary>
	/// <param name="position">The position of the tile to check.</param>
	/// <param name="tile">The tile to compare against.</param>
	/// <param name="comparer">The custom comparer to use for the comparison.</param>
	/// <returns>True if the tile matches, false otherwise.</returns>
	public static bool IsTile(this ITilemap tilemap, Vector3Int position, TileBase tile, TileComparer comparer)
	{
		return comparer(tilemap.GetTile(position), tile);
	}

	/// <summary>
	/// Checks if the tile at the specified position on the Tilemap matches a given tile using a custom comparer.
	/// </summary>
	/// <param name="position">The position of the tile to check.</param>
	/// <param name="tile">The tile to compare against.</param>
	/// <param name="comparer">The custom comparer to use for the comparison.</param>
	/// <returns>True if the tile matches, false otherwise.</returns>
	public static bool IsTile(this Tilemap tilemap, Vector3Int position, TileBase tile, TileComparer comparer)
	{
		return comparer(tilemap.GetTile(position), tile);
	}
}