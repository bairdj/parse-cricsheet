namespace ParseCricsheet.Model;
using System;

public record Meta
{
    public string DataVersion { get; init; }
    public DateOnly Created { get; init; }
    public int Revision { get; init; }

    public Meta(string dataVersion, DateOnly created, int revision) {
        DataVersion = dataVersion;
        Created = created;
        Revision = revision;
    }
}
