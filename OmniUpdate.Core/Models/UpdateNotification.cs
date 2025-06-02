namespace OmniUpdate.Core.Models;

public enum NotificationType
{
    Release,
    Commit,
    Issue,
    PullRequest
}

public class UpdateNotification
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public NotificationType Type { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Repository { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
    public Dictionary<string, object> Metadata { get; set; } = new();

    public static UpdateNotification FromRelease(Octokit.Release release, string repository)
    {
        return new UpdateNotification
        {
            Type = NotificationType.Release,
            Title = $"New Release: {release.Name ?? release.TagName}",
            Description = release.Body ?? "No description provided",
            Url = release.HtmlUrl,
            Repository = repository,
            Author = release.Author?.Login ?? "Unknown",
            Timestamp = release.PublishedAt ?? DateTimeOffset.UtcNow,
            Metadata = new Dictionary<string, object>
            {
                ["TagName"] = release.TagName,
                ["IsPrerelease"] = release.Prerelease,
                ["IsDraft"] = release.Draft
            }
        };
    }

    public static UpdateNotification FromCommit(Octokit.GitHubCommit commit, string repository)
    {
        return new UpdateNotification
        {
            Type = NotificationType.Commit,
            Title = $"New Commit: {commit.Sha[..7]}",
            Description = commit.Commit.Message,
            Url = commit.HtmlUrl,
            Repository = repository,
            Author = commit.Author?.Login ?? commit.Commit.Author.Name,
            Timestamp = commit.Commit.Author.Date,
            Metadata = new Dictionary<string, object>
            {
                ["Sha"] = commit.Sha,
                ["ParentCount"] = commit.Parents?.Count ?? 0
            }
        };
    }

    public static UpdateNotification FromIssue(Octokit.Issue issue, string repository)
    {
        return new UpdateNotification
        {
            Type = NotificationType.Issue,
            Title = $"Issue: {issue.Title}",
            Description = issue.Body ?? "No description provided",
            Url = issue.HtmlUrl,
            Repository = repository,
            Author = issue.User?.Login ?? "Unknown",
            Timestamp = issue.CreatedAt,
            Metadata = new Dictionary<string, object>
            {
                ["Number"] = issue.Number,
                ["State"] = issue.State.ToString(),
                ["Labels"] = issue.Labels?.Select(l => l.Name).ToArray() ?? Array.Empty<string>()
            }
        };
    }

    public static UpdateNotification FromPullRequest(Octokit.PullRequest pr, string repository)
    {
        return new UpdateNotification
        {
            Type = NotificationType.PullRequest,
            Title = $"Pull Request: {pr.Title}",
            Description = pr.Body ?? "No description provided",
            Url = pr.HtmlUrl,
            Repository = repository,
            Author = pr.User?.Login ?? "Unknown",
            Timestamp = pr.CreatedAt,
            Metadata = new Dictionary<string, object>
            {
                ["Number"] = pr.Number,
                ["State"] = pr.State.ToString(),
                ["BaseBranch"] = pr.Base?.Ref ?? "Unknown",
                ["HeadBranch"] = pr.Head?.Ref ?? "Unknown"
            }
        };
    }
}