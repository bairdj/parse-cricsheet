namespace ParseCricsheet.Model;

/// <summary>
/// In the data, sometimes the season is recorded as a number, sometimes as a string.
/// The JSON deserialiser can't handle this, so wrap in this class and create a converter
/// to handle it.
/// Internally the season is always stored as a string.
/// </summary>
public struct Season
{
    private readonly string _value;

    public Season(string value) {
        _value = value;
    }

    public Season(int value) {
        _value = value.ToString();
    }

    public static implicit operator Season(string value) => new(value);
    public static implicit operator Season(int value) => new(value);
    public static implicit operator string(Season season) => season._value;
    public override string ToString() => _value;
}