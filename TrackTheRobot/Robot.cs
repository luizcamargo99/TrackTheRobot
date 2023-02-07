namespace TrackTheRobot;

public class Robot
{
    private List<Move> _moves
    {
        get
        {
            return new() { new Right(), new Left(), new Up(), new Down() };
        }
        set { }
    }

    public int[] Walk(string[] instructions)
    {
        return new int[]
        {
            GetPositionByInstructions(instructions.Where(x => new string[] { MoveConstants.RIGHT_KEY, MoveConstants.LEFT_KEY }.Any(y => x.StartsWith(y))).ToArray()),
            GetPositionByInstructions(instructions.Where(x => new string[] { MoveConstants.UP_KEY, MoveConstants.DOWN_KEY }.Any(y => x.StartsWith(y))).ToArray())
        };
    }

    private int GetPositionByInstructions(string[] instructions)
    {
        var position = 0;

        for (int i = 0; i < instructions.Length; i++)
        {
            var instruction = instructions[i].Split(" ");
            var instructionKey = instruction[0];
            var positionToChange = int.Parse(instruction[1]);
            var move = _moves.FirstOrDefault(x => x.Key.ToLower() == instructionKey);

            if (move is null)
                continue;

            move.ChangePosition(positionToChange);
            position += move.Position;
        }

        return position;
    }
}

public static class MoveConstants
{
    public const string RIGHT_KEY = "right";
    public const string LEFT_KEY = "left";
    public const string UP_KEY = "up";
    public const string DOWN_KEY = "down";
}

public abstract class Move
{
    public abstract string Key { get; protected set; }
    public abstract int Position { get; protected set; }
    public abstract void ChangePosition(int value);
}

public class Up : Move
{
    public override string Key
    {
        get
        {
            return MoveConstants.UP_KEY;
        }
        protected set { }
    }

    public override int Position { get; protected set; }

    public override void ChangePosition(int value) => Position = +value;
}

public class Down : Move
{
    public override string Key
    {
        get
        {
            return MoveConstants.DOWN_KEY;
        }
        protected set { }
    }

    public override int Position { get; protected set; }

    public override void ChangePosition(int value) => Position = -value;
}

public class Right : Move
{
    public override string Key
    {
        get
        {
            return MoveConstants.RIGHT_KEY;
        }
        protected set { }
    }

    public override int Position { get; protected set; }

    public override void ChangePosition(int value) => Position = +value;
}


public class Left : Move
{
    public override string Key
    {
        get
        {
            return MoveConstants.LEFT_KEY;
        }
        protected set { }
    }

    public override int Position { get; protected set; }

    public override void ChangePosition(int value) => Position = -value;
}
