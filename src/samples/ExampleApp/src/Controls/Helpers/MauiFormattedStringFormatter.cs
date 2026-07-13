using ColorCode;
using ColorCode.Common;
using ColorCode.Parsing;
using ColorCode.Styling;

public class MauiFormattedStringFormatter : CodeColorizerBase
{
    FormattedString formattedString;
    string fontFamily;
    double fontSize;

    public MauiFormattedStringFormatter(StyleDictionary style = null, ILanguageParser languageParser = null)
        : base(style, languageParser)
    {
    }

    public FormattedString FormatFormattedString(
        string sourceCode,
        ILanguage language,
        string fontFamily = null,
        double fontSize = 14)
    {
        this.fontFamily = fontFamily;
        this.fontSize = fontSize;

        formattedString = new FormattedString();
        languageParser.Parse(sourceCode, language, (parsedSourceCode, captures) => Write(parsedSourceCode, captures));
        return formattedString;
    }

    protected override void Write(string parsedSourceCode, IList<Scope> scopes)
    {
        var styleInsertions = new List<TextInsertion>();

        foreach (Scope scope in scopes)
            GetStyleInsertionsForCapturedStyle(scope, styleInsertions);

        styleInsertions.SortStable((x, y) => x.Index.CompareTo(y.Index));

        int offset = 0;
        Scope previousScope = null;

        foreach (var insertion in styleInsertions)
        {
            var text = parsedSourceCode.Substring(offset, insertion.Index - offset);
            CreateSpan(text, previousScope);

            offset = insertion.Index;
            previousScope = insertion.Scope;
        }

        var remaining = parsedSourceCode.Substring(offset);
        if (remaining != "\r")
            CreateSpan(remaining, null);
    }

    void CreateSpan(string text, Scope scope)
    {
        if (text.Length == 0)
            return;

        var span = new Span
        {
            Text = text,
            FontFamily = fontFamily,  
            FontSize = fontSize      
        };

        if (scope != null)
            StyleSpan(span, scope);

        formattedString!.Spans.Add(span);
    }

    void StyleSpan(Span span, Scope scope)
    {
        if (!Styles.Contains(scope.Name))
            return;

        ColorCode.Styling.Style style = Styles[scope.Name];

        if (!string.IsNullOrWhiteSpace(style.Foreground))
            span.TextColor = Color.FromArgb(style.Foreground);

        if (!string.IsNullOrWhiteSpace(style.Background))
            span.BackgroundColor = Color.FromArgb(style.Background);

        var attributes = FontAttributes.None;
        if (style.Italic) attributes |= FontAttributes.Italic;
        if (style.Bold) attributes |= FontAttributes.Bold;
        span.FontAttributes = attributes;
    }

    void GetStyleInsertionsForCapturedStyle(Scope scope, ICollection<TextInsertion> styleInsertions)
    {
        styleInsertions.Add(new TextInsertion { Index = scope.Index, Scope = scope });

        foreach (Scope child in scope.Children)
            GetStyleInsertionsForCapturedStyle(child, styleInsertions);

        styleInsertions.Add(new TextInsertion { Index = scope.Index + scope.Length });
    }
}