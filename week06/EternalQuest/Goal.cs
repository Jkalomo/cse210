public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    // Abstract methods to be implemented in derived classes
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    // Make GetDetailsString virtual so it can be overridden by derived classes
    public virtual string GetDetailsString()
    {
        return $"[ ] {_shortName}: {_description}";
    }
}

