namespace ParseCricsheet.Process;
using ParseCricsheet.Model;

public class MatchWriter
{
    public readonly Match _match;
    private readonly IDictionary<string, string> _playerMap;

    public MatchWriter(Match match)
    {
        _match = match;
        _playerMap = match.Info.Registry.People;
    }
}
