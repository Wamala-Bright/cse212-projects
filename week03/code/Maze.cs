/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created.
///
/// Dictionary format:
/// (x, y) : [up, right, down, left]
///
/// 'x' and 'y' represent the current location in the maze.
/// Each boolean value indicates whether movement in that direction is allowed:
///   true  = no wall (movement allowed)
///   false = wall present (movement NOT allowed)
///
/// If a move is attempted where a wall exists, an InvalidOperationException
/// is thrown with the message: "Can't go that way!".
/// </summary>
public class Maze
{
    // Stores the maze layout:
    // Key   -> (x, y) coordinate
    // Value -> bool[4] representing allowed directions
    private readonly Dictionary<(int, int), bool[]> _mazeMap;

    // Current position in the maze (starting location)
    private int _currX = 1;
    private int _currY = 1;

    /// <summary>
    /// Creates a new Maze using the provided maze map.
    /// </summary>
    /// <param name="mazeMap">
    /// A dictionary that maps coordinates to allowed movement directions.
    /// </param>
    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Attempts to move up in the maze.
    /// Uses index 0 of the boolean array.
    /// </summary>
    public void MoveUp()
    {
        var key = (_currX, _currY);

        // If moving up is not allowed, throw an exception
        if (!_mazeMap[key][0])
            throw new InvalidOperationException("Can't go that way!");

        // Move up (decrease Y coordinate)
        _currY -= 1;
    }

    /// <summary>
    /// Attempts to move right in the maze.
    /// Uses index 1 of the boolean array.
    /// </summary>
    public void MoveRight()
    {
        var key = (_currX, _currY);

        // If moving right is not allowed, throw an exception
        if (!_mazeMap[key][1])
            throw new InvalidOperationException("Can't go that way!");

        // Move right (increase X coordinate)
        _currX += 1;
    }

    /// <summary>
    /// Attempts to move down in the maze.
    /// Uses index 2 of the boolean array.
    /// </summary>
    public void MoveDown()
    {
        var key = (_currX, _currY);

        // If moving down is not allowed, throw an exception
        if (!_mazeMap[key][2])
            throw new InvalidOperationException("Can't go that way!");

        // Move down (increase Y coordinate)
        _currY += 1;
    }

    /// <summary>
    /// Attempts to move left in the maze.
    /// Uses index 3 of the boolean array.
    /// </summary>
    public void MoveLeft()
    {
        var key = (_currX, _currY);

        // If moving left is not allowed, throw an exception
        if (!_mazeMap[key][3])
            throw new InvalidOperationException("Can't go that way!");

        // Move left (decrease X coordinate)
        _currX -= 1;
    }

    /// <summary>
    /// Returns the current location in the maze.
    /// </summary>
    /// <returns>
    /// A formatted string describing the current (x, y) position.
    /// </returns>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}