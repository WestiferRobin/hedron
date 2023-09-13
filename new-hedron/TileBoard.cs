using Godot;

public partial class TileBoard : Node
{
	private int gridSize = 5;
	private Vector2 cellSize = new Vector2(64, 64); // Adjust this to your desired cell size


	public override void _Ready()
	{
		for (int row = 0; row < gridSize; row++)
		{
			for (int col = 0; col < gridSize; col++)
			{
				Node2D cell = CreateCell();
				cell.Position = new Vector2(col, row) * cellSize;
				AddChild(cell);
			}
		}
	}

	private Node2D CreateCell()
	{
		var cell = new Sprite2D(); // You can replace this with any Node2D type you want
		cell.Texture = (Texture2D)GD.Load("res://icon.png"); // Replace with your desired texture
		cell.Scale = cellSize / cell.Texture.GetTexture().GetSize();
		return cell;
	}

	public override void _Process(double delta)
	{
	}
}
