using Markdig;

namespace Noted.Services;

public class MarkdownRenderer
{
    private readonly MarkdownPipeline _pipeline;

    public MarkdownRenderer()
    {
        _pipeline = new MarkdownPipelineBuilder()
            .DisableHtml()
            .Build();
    }

    public string Render(string markdown)
    {
        return Markdown.ToHtml(markdown, _pipeline);
    }
}
