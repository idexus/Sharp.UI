

namespace ExampleApp
{
    using ColorCode;
    using ColorCode.Styling;
    using Sharp.UI;

    [BindableProperties]
    public interface IExample
    {
        public string Title { get; set; }
        public bool IsExpanded { get; set; }

        public View ContentView { get; set; }

        [PropertyCallbacks(nameof(Example.SourceTextChanged))]
        public string SourceText { get; set; }
    }

    [SharpObject]
    [ContentProperty(nameof(ContentView))]
    public partial class Example : ContentView, IExample
    {
        private Label codeLabel;
        private FormattedString formattedText;

        protected override View Build()
        {
            return
                new VStack
                {
                    new Label()
                        .Text(e => e.Path(nameof(Title)).Source(this))
                        .FontSize(16)
                        .Margin(0,10,0,7),

                    new Grid
                    {
                        new ContentView().Content(e => e.Path(nameof(ContentView)).Source(this)),
                    }
                    .Padding(16)
                    .BackgroundColor(e => e.OnLight(Colors.LightBlue).OnDark(Colors.MidnightBlue)),

                    new Grid(e => e
                        .ColumnDefinitions(e => e.Auto().Star().Auto())
                        .CenterVertically())
                    {
                        new Label()
                            .Text(e => e.Path(nameof(IsExpanded)).Convert<bool>(e => (e ? "Code" : "Show Code")).Source(this))
                            .Column(0)
                            .FontSize(16),

                        new Label()
                            .Text(e => e.Path(nameof(IsExpanded)).Convert<bool>(e => (e ? "^" : "˅")).Source(this))
                            .Column(2)
                            .FontSize(16).Margin(left: 5),
                    }
                    .GestureRecognizers([new TapGestureRecognizer().OnTapped(e => {
                        this.IsExpanded = !IsExpanded;
                    })])
                    .Padding(e => e.OnPhone(8).OnDesktop(14))
                    .Row(1)
                    .BackgroundColor(AppColors.Gray900),

                    new Grid {
                        new ScrollView {
                            new Label(out codeLabel)
                                .FormattedText(formattedText)
                                .FontSize(14)
                                .HorizontalOptions(LayoutOptions.Start)
                                .Padding(10)

                        }
                        .BackgroundColor(AppColors.Gray950)
                        .Orientation(ScrollOrientation.Horizontal),

                        new Button("Copy").OnClicked(async e => {
                            if (codeLabel != null && codeLabel.FormattedText != null)
                            {
                                var textToCopy = codeLabel.FormattedText.ToString();
                                await Clipboard.SetTextAsync(textToCopy);
                                e.Text = "Copied";
                                await Task.Delay(1000);
                                e.Text = "Copy";
                            }
                        })
                        .FontSize(16)
                        .Margin(10)
                        .BackgroundColor(Colors.Transparent)
                        .BorderWidth(0)
                        .VerticalOptions(LayoutOptions.Start)
                        .HorizontalOptions (LayoutOptions.End)
                    }
                    .IsVisible(e => e.Path(nameof(IsExpanded)).Source(this))
                }
                .Margin(e => e.OnPhone(5).OnDesktop(20));
        }

        public static void SourceTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var example = (Example)bindable;
            var sourceText = newValue as string;
            var formatter = new MauiFormattedStringFormatter(StyleDictionary.DefaultDark);
            var formattedCode = formatter.FormatFormattedString(sourceText, Languages.CSharp,
                                                                            fontFamily: "CodeFont",
                                                                            fontSize: 14);
            example.formattedText = formattedCode;
            example.codeLabel.FormattedText = formattedCode;
        }
    }
}
