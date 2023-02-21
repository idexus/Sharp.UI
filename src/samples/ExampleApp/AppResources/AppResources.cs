namespace ExampleApp;

using Microsoft.Maui.Controls.Shapes;
using Sharp.UI;

public class AppResources
{
    public static ResourceDictionary Default => new ResourceDictionary {

            // "ActivityIndicator"
            
            new Style<ActivityIndicator>(e => e
                .Color(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))),
            
            // "IndicatorView"

            new Style<IndicatorView>(e => e
                .IndicatorColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray500))
                .SelectedIndicatorColor(e => e.OnLight(AppColors.Gray950).OnDark(AppColors.Gray100))),
            
            // "Border"

            new Style<Border>(e => e
                .Stroke(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray500))
                .StrokeShape(new Rectangle())
                .StrokeThickness(1)),

            // "BoxView"

            new Style<BoxView>(e => e
                .Color(e => e.OnLight(AppColors.Gray950).OnDark(AppColors.Gray200))),
            

            // "Button"

            new Style<Button>(e => e
                .TextColor(e => e.OnLight(Colors.White).OnDark(AppColors.Primary))
                .BackgroundColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))
                .FontFamily("OpenSansRegular")
                .FontSize(14)
                .CornerRadius(8)
                .Padding(new Thickness(14,10))
                .MinimumHeightRequest(44)
                .MinimumWidthRequest(44))
            {
                new VisualState<Button> (VisualStateEnum.VisualElement.Normal, e => e
                    .TextColor(e => e.OnLight(Colors.White).OnDark(AppColors.Primary))
                    .BackgroundColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))),

                new VisualState<Button> (VisualStateEnum.VisualElement.Disabled, e => e
                    .TextColor(e => e.OnLight(AppColors.Gray950).OnDark(AppColors.Gray200))
                    .BackgroundColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray600)))
            },

            // "CheckBox"

            new Style<CheckBox>(e => e
                .Color(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))
                .MinimumHeightRequest(44)
                .MinimumWidthRequest(44))
            {
                new VisualState<CheckBox>(VisualStateEnum.VisualElement.Normal),
                new VisualState<CheckBox>(VisualStateEnum.VisualElement.Disabled, e => e
                    .Color(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600))),
            },

            // "DatePicker"

            new Style<DatePicker>(e => e
                .TextColor(e => e.OnLight(AppColors.Gray900).OnDark(Colors.White))
                .BackgroundColor(Colors.Transparent)
                .FontFamily("OpenSansRegular")
                .FontSize(14)
                .MinimumHeightRequest(44)
                .MinimumWidthRequest(44))
            {
                new VisualState<DatePicker>(VisualStateEnum.VisualElement.Normal),
                new VisualState<DatePicker>(VisualStateEnum.VisualElement.Disabled, e => e
                    .TextColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray500)))
            },
            
            // "Editor"

            new Style<Editor>(e => e
                .TextColor(e => e.OnLight(Colors.Black).OnDark(Colors.White))
                .BackgroundColor(Colors.Transparent)
                .FontFamily("OpenSansRegular")
                .FontSize(14)
                .PlaceholderColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray500))
                .MinimumHeightRequest(44)
                .MinimumWidthRequest(44))
            {
                new VisualState<Editor>(VisualStateEnum.VisualElement.Normal),
                new VisualState<Editor>(VisualStateEnum.VisualElement.Disabled, e => e
                    .TextColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600)))
            },  
            

            // "Entry"

            new Style<Entry>(e => e
                .TextColor(e => e.OnLight(Colors.Black).OnDark(Colors.White))
                .BackgroundColor(Colors.Transparent)
                .FontFamily("OpenSansRegular")
                .FontSize(14)
                .PlaceholderColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray500))
                .MinimumHeightRequest(44)
                .MinimumWidthRequest(44))
            {
                new VisualState<Entry>(VisualStateEnum.VisualElement.Normal),
                new VisualState<Entry>(VisualStateEnum.VisualElement.Disabled, e => e
                    .TextColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600)))
            },              

            // "Frame"

            new Style<Frame>(e => e
                .HasShadow(false)
                .BorderColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray950))
                .CornerRadius(8)),
            
            // "ImageButton"

            new Style<ImageButton>(e => e
                .Opacity(1.0)
                .BackgroundColor(Colors.Transparent)
                .BorderWidth(0)
                .BorderWidth(0)
                .MinimumHeightRequest(44)
                .MinimumWidthRequest(44))
            {
                new VisualState<ImageButton>(VisualStateEnum.VisualElement.Normal),
                new VisualState<ImageButton>(VisualStateEnum.VisualElement.Disabled, e => e
                    .Opacity(0.5))
            },         
            

            // "Label"

            new Style<Label>(e => e
                .TextColor(e => e.OnLight(AppColors.Gray900).OnDark(Colors.White))
                .BackgroundColor(Colors.Transparent)
                .FontFamily("OpenSansRegular")
                .FontSize(14))
            {
                new VisualState<Label>(VisualStateEnum.VisualElement.Normal),
                new VisualState<Label>(VisualStateEnum.VisualElement.Disabled, e => e
                    .TextColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600)))
            },

            // "ListView"

            new Style<ListView>(e => e
                .SeparatorColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray500))
                .RefreshControlColor(e => e.OnLight(AppColors.Gray900).OnDark(AppColors.Gray200))),

            // "Picker"

            new Style<Picker>(e => e
                .TextColor(e => e.OnLight(AppColors.Gray900).OnDark(Colors.White))
                .TitleColor(e => e.OnLight(AppColors.Gray900).OnDark(AppColors.Gray200))
                .BackgroundColor(Colors.Transparent)
                .FontFamily("OpenSansRegular")
                .FontSize(14)
                .MinimumHeightRequest(44)
                .MinimumWidthRequest(44))
            {
                new VisualState<Picker>(VisualStateEnum.VisualElement.Normal),
                new VisualState<Picker>(VisualStateEnum.VisualElement.Disabled, e => e
                    .TextColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600))
                    .TitleColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600)))
            },  
            

            // "ProgressBar"

            new Style<ProgressBar>(e => e
                .ProgressColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White)))
            {
                new VisualState<ProgressBar>(VisualStateEnum.VisualElement.Normal),
                new VisualState<ProgressBar>(VisualStateEnum.VisualElement.Disabled, e => e
                    .ProgressColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600)))
            },
            
            // "RadioButton"

            new Style<RadioButton>(e => e
                .BackgroundColor(Colors.Transparent)
                .TextColor(e => e.OnLight(Colors.Black).OnDark(Colors.White))
                .FontFamily("OpenSansRegular")
                .FontSize(14)
                .MinimumHeightRequest(44)
                .MinimumWidthRequest(44))
            {
                new VisualState<RadioButton>(VisualStateEnum.VisualElement.Normal),
                new VisualState<RadioButton>(VisualStateEnum.VisualElement.Disabled, e => e
                    .TextColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600)))
            },            

            // "RefreshView"

            new Style<RefreshView>(e => e
                .RefreshColor(e => e.OnLight(AppColors.Gray900).OnDark(AppColors.Gray200))),
            
            // "SearchBar"

            new Style<SearchBar>(e => e
                .TextColor(e => e.OnLight(AppColors.Gray900).OnDark(Colors.White))
                .PlaceholderColor(AppColors.Gray500)
                .CancelButtonColor(AppColors.Gray500)
                .BackgroundColor(Colors.Transparent)
                .FontFamily("OpenSansRegular")
                .FontSize(14))
            {
                new VisualState<SearchBar>(VisualStateEnum.VisualElement.Normal),
                new VisualState<SearchBar>(VisualStateEnum.VisualElement.Disabled, e => e
                    .TextColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600))
                    .PlaceholderColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600)))
            },      

            // "SearchHandler"

            new Style<SearchHandler>(e => e
                .TextColor(e => e.OnLight(AppColors.Gray900).OnDark(Colors.White))
                .PlaceholderColor(AppColors.Gray500)
                .BackgroundColor(Colors.Transparent)
                .FontFamily("OpenSansRegular")
                .FontSize(14))
            {
                new VisualState<SearchHandler>(VisualStateEnum.VisualElement.Normal),
                new VisualState<SearchHandler>(VisualStateEnum.VisualElement.Disabled, e => e
                    .TextColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600))
                    .PlaceholderColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600)))
            },            

            // "Shadow"

            new Style<Shadow>(e => e
                .Radius(15)
                .Opacity(0.5f)
                .Brush(e => e.OnLight(Colors.White).OnDark(Colors.White))
                .Offset(new Point(10, 10))),
            
            // "Slider"

            new Style<Slider>(e => e
                .MinimumTrackColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))
                .MaximumTrackColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray600))
                .ThumbColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White)))
            {
                new VisualState<Slider>(VisualStateEnum.VisualElement.Normal),
                new VisualState<Slider>(VisualStateEnum.VisualElement.Disabled, e => e
                    .MinimumTrackColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600))
                    .MaximumTrackColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600))
                    .ThumbColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600)))
            },

            // "SwipeItem"

            new Style<SwipeItem>(e => e
                .BackgroundColor(e => e.OnLight(Colors.White).OnDark(Colors.Black))),            

            // "Switch"

            new Style<Switch>(e => e
                .OnColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))
                .ThumbColor(e => e.OnLight(AppColors.Gray400).OnDark(AppColors.Gray500)))
            {
                new VisualState<Switch>(VisualStateEnum.Switch.Normal),

                new VisualState<Switch>(VisualStateEnum.Switch.Disabled, e => e
                    .OnColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600))
                    .ThumbColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600))),

                new VisualState<Switch>(VisualStateEnum.Switch.On, e => e
                    .OnColor(e => e.OnLight(AppColors.Secondary).OnDark(AppColors.Gray200))
                    .ThumbColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))),

                new VisualState<Switch>(VisualStateEnum.Switch.Off, e => e
                    .OnColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))
                    .ThumbColor(e => e.OnLight(AppColors.Gray400).OnDark(AppColors.Gray500)))
            },

            // "TimePicker"

            new Style<TimePicker>(e => e
                .TextColor(e => e.OnLight(AppColors.Gray900).OnDark(Colors.White))
                .BackgroundColor(Colors.Transparent)
                .FontFamily("OpenSansRegular")
                .FontSize(14)
                .MinimumHeightRequest(44)
                .MinimumWidthRequest(44))
            {
                new VisualState<TimePicker>(VisualStateEnum.VisualElement.Normal),
                new VisualState<TimePicker>(VisualStateEnum.VisualElement.Disabled, e => e
                    .TextColor(e => e.OnLight(AppColors.Gray300).OnDark(AppColors.Gray600)))
            },            

            // "Page"

            new Style<Page>(applyToDerivedTypes: true, e => e
                .Padding(0)
                .BackgroundColor(e => e.OnLight(Colors.White).OnDark(Colors.Black))),
            
            // "Shell"

            new Style<Shell>(applyToDerivedTypes: true, e => e
                //.NavBarHasShadow(0)
                .BackgroundColor(e => e.OnLight(AppColors.Primary).OnDark(AppColors.Gray950))),
                //.ForegroundColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))
                //.TitleColor(e => e.OnLight(Colors.White).OnDark(Colors.White))),
                //.DisabledColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray950))
                //.UnselectedColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray200))
                //.TabBarBackgroundColor(e => e.OnLight(Colors.White).OnDark(Colors.Black))
                //.TabBarForegroundColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))
                //.TabBarTitleColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))
                //.TabBarUnselectedColor(e => e.OnLight(AppColors.Gray900).OnDark(AppColors.Gray200))),    

            // "NavigationPage"

            new Style<NavigationPage>(e => e
                .BarBackgroundColor(e => e.OnLight(AppColors.Primary).OnDark(AppColors.Gray950))
                .BarTextColor(e => e.OnLight(AppColors.Gray200).OnDark(Colors.White))),
            
            // "TabbedPage"

            new Style<TabbedPage>(e => e
                .BarBackgroundColor(e => e.OnLight(Colors.White).OnDark(AppColors.Gray950))
                .BarTextColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))
                .UnselectedTabColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray500))
                .SelectedTabColor(e => e.OnLight(AppColors.Gray950).OnDark(AppColors.Gray100)))
        };
}
