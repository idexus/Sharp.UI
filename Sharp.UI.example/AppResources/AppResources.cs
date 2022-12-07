namespace Sharp.UI.Example;

using Sharp.UI;

public class AppResources
{
    public static ResourceDictionary Default => new ResourceDictionary {

            // "ActivityIndicator"
            
            new Style<ActivityIndicator>
            {
                ActivityIndicator.ColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
            },

            // "IndicatorView"

            new Style<IndicatorView>
            {
                IndicatorView.IndicatorColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray500),
                IndicatorView.SelectedIndicatorColorProperty.Set().Light(AppColors.Gray950).Dark(AppColors.Gray100),
            },

            // "Border"

            new Style<Border>
            {
                Border.StrokeProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray500),
                Border.StrokeShapeProperty.Set(new Rectangle()),
                Border.StrokeThicknessProperty.Set(1),
            },

            // "BoxView"

            new Style<BoxView>
            {
                BoxView.ColorProperty.Set().Light(AppColors.Gray950).Dark(AppColors.Gray200),
            },

            // "Button"

            new Style<Button>
            {
                Button.TextColorProperty.Set().Light(Colors.White).Dark(AppColors.Primary),
                Button.BackgroundColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
                Button.FontFamilyProperty.Set("OpenSansRegular"),
                Button.FontSizeProperty.Set(14),
                Button.CornerRadiusProperty.Set(8),
                Button.PaddingProperty.Set(new Thickness(14,10)),
                Button.MinimumHeightRequestProperty.Set(44),
                Button.MinimumWidthRequestProperty.Set(44),

                new VisualState(VisualState.VisualElement.Normal)
                {
                    Button.TextColorProperty.Set().Light(Colors.White).Dark(AppColors.Primary),
                    Button.BackgroundColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
                },
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    Button.TextColorProperty.Set().Light(AppColors.Gray950).Dark(AppColors.Gray200),
                    Button.BackgroundColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray600),
                },
            },            

            // "CheckBox"

            new Style<CheckBox>
            {
                CheckBox.ColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
                CheckBox.MinimumHeightRequestProperty.Set(44),
                CheckBox.MinimumWidthRequestProperty.Set(44),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    CheckBox.ColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                },
            },

            // "DatePicker"

            new Style<DatePicker>
            {
                DatePicker.TextColorProperty.Set().Light(AppColors.Gray900).Dark(Colors.White),
                DatePicker.BackgroundColorProperty.Set(Colors.Transparent),
                DatePicker.FontFamilyProperty.Set("OpenSansRegular"),
                DatePicker.FontSizeProperty.Set(14),
                DatePicker.MinimumHeightRequestProperty.Set(44),
                DatePicker.MinimumWidthRequestProperty.Set(44),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    DatePicker.TextColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray500),
                },
            },

            // "Editor"

            new Style<Editor>
            {
                Editor.TextColorProperty.Set().Light(Colors.Black).Dark(Colors.White),
                Editor.BackgroundColorProperty.Set(Colors.Transparent),
                Editor.FontFamilyProperty.Set("OpenSansRegular"),
                Editor.FontSizeProperty.Set(14),
                Editor.PlaceholderColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray500),
                Editor.MinimumHeightRequestProperty.Set(44),
                Editor.MinimumWidthRequestProperty.Set(44),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    Editor.TextColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                },
            },

            // "Entry"

            new Style<Entry>
            {
                Entry.TextColorProperty.Set().Light(Colors.Black).Dark(Colors.White),
                Entry.BackgroundColorProperty.Set(Colors.Transparent),
                Entry.FontFamilyProperty.Set("OpenSansRegular"),
                Entry.FontSizeProperty.Set(14),
                Entry.PlaceholderColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray500),
                Entry.MinimumHeightRequestProperty.Set(44),
                Entry.MinimumWidthRequestProperty.Set(44),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    Entry.TextColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                },
            },

            // "Frame"

            new Style<Frame>
            {
                Frame.HasShadowProperty.Set(false),
                Frame.BorderColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray950),
                Frame.CornerRadiusProperty.Set(8)
            },

            // "ImageButton"

            new Style<ImageButton>
            {
                ImageButton.OpacityProperty.Set(1.0),
                ImageButton.BackgroundColorProperty.Set(Colors.Transparent),
                ImageButton.BorderWidthProperty.Set(0),
                ImageButton.BorderWidthProperty.Set(0),
                ImageButton.MinimumHeightRequestProperty.Set(44),
                ImageButton.MinimumWidthRequestProperty.Set(44),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    ImageButton.OpacityProperty.Set(0.5),
                },
            },

            // "Label"

            new Style<Label>
            {
                Label.TextColorProperty.Set().Light(AppColors.Gray900).Dark(Colors.White),
                Label.BackgroundColorProperty.Set(Colors.Transparent),
                Label.FontFamilyProperty.Set("OpenSansRegular"),
                Label.FontSizeProperty.Set(14),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    Label.TextColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                },
            },

            // "ListView"

            new Style<ListView>
            {
                ListView.SeparatorColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray500),
                ListView.RefreshControlColorProperty.Set().Light(AppColors.Gray900).Dark(AppColors.Gray200),
            },

            // "Picker"

            new Style<Picker>
            {
                Picker.TextColorProperty.Set().Light(AppColors.Gray900).Dark(Colors.White),
                Picker.TitleColorProperty.Set().Light(AppColors.Gray900).Dark(AppColors.Gray200),
                Picker.BackgroundColorProperty.Set(Colors.Transparent),
                Picker.FontFamilyProperty.Set("OpenSansRegular"),
                Picker.FontSizeProperty.Set(14),
                Picker.MinimumHeightRequestProperty.Set(44),
                Picker.MinimumWidthRequestProperty.Set(44),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    Picker.TextColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                    Picker.TitleColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                },
            },

            // "ProgressBar"

            new Style<ProgressBar>
            {
                ProgressBar.ProgressColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    ProgressBar.ProgressColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                }
            },

            // "RadioButton"

            new Style<RadioButton>
            {
                RadioButton.BackgroundColorProperty.Set(Colors.Transparent),
                RadioButton.TextColorProperty.Set().Light(Colors.Black).Dark(Colors.White),
                RadioButton.FontFamilyProperty.Set("OpenSansRegular"),
                RadioButton.FontSizeProperty.Set(14),
                RadioButton.MinimumHeightRequestProperty.Set(44),
                RadioButton.MinimumWidthRequestProperty.Set(44),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    RadioButton.TextColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                }
            },

            // "RefreshView"

            new Style<RefreshView>
            {
                RefreshView.RefreshColorProperty.Set().Light(AppColors.Gray900).Dark(AppColors.Gray200),
            },

            // "SearchBar"

            new Style<SearchBar>
            {
                SearchBar.TextColorProperty.Set().Light(AppColors.Gray900).Dark(Colors.White),
                SearchBar.PlaceholderColorProperty.Set(AppColors.Gray500),
                SearchBar.CancelButtonColorProperty.Set(AppColors.Gray500),
                SearchBar.BackgroundColorProperty.Set(Colors.Transparent),
                SearchBar.FontFamilyProperty.Set("OpenSansRegular"),
                SearchBar.FontSizeProperty.Set(14),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    SearchBar.TextColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                    SearchBar.PlaceholderColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                }
            },

            // "SearchHandler"

            new Style<SearchHandler>
            {
                SearchHandler.TextColorProperty.Set().Light(AppColors.Gray900).Dark(Colors.White),
                SearchHandler.PlaceholderColorProperty.Set(AppColors.Gray500),
                SearchHandler.BackgroundColorProperty.Set(Colors.Transparent),
                SearchHandler.FontFamilyProperty.Set("OpenSansRegular"),
                SearchHandler.FontSizeProperty.Set(14),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    SearchHandler.TextColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                    SearchHandler.PlaceholderColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                }
            },

            // "Shadow"

            new Style<Shadow>
            {
                Shadow.RadiusProperty.Set(15),
                Shadow.OpacityProperty.Set(0.5),
                Shadow.BrushProperty.Set().Light(Colors.White).Dark(Colors.White),
                Shadow.OffsetProperty.Set(new Point(10, 10)),
            },

            // "Slider"

            new Style<Slider>
            {
                Slider.MinimumTrackColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
                Slider.MaximumTrackColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray600),
                Slider.ThumbColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    Slider.MinimumTrackColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                    Slider.MaximumTrackColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                    Slider.ThumbColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                }
            },

            // "SwipeItem"

            new Style<SwipeItem>
            {
                SwipeItem.BackgroundColorProperty.Set().Light(Colors.White).Dark(Colors.Black),
            },

            // "Switch"

            new Style<Switch>
            {
                Switch.OnColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
                Switch.ThumbColorProperty.Set().Light(AppColors.Gray400).Dark(AppColors.Gray500),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    Switch.OnColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                    Switch.ThumbColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                },
                new VisualState(VisualState.Switch.On)
                {
                    Switch.OnColorProperty.Set().Light(AppColors.Secondary).Dark(AppColors.Gray200),
                    Switch.ThumbColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
                },
                new VisualState(VisualState.Switch.Off)
                {
                    Switch.OnColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
                    Switch.ThumbColorProperty.Set().Light(AppColors.Gray400).Dark(AppColors.Gray500),
                }
            },

            // "TimePicker"

            new Style<TimePicker>
            {
                TimePicker.TextColorProperty.Set().Light(AppColors.Gray900).Dark(Colors.White),
                TimePicker.BackgroundColorProperty.Set(Colors.Transparent),
                TimePicker.FontFamilyProperty.Set("OpenSansRegular"),
                TimePicker.FontSizeProperty.Set(14),
                TimePicker.MinimumHeightRequestProperty.Set(44),
                TimePicker.MinimumWidthRequestProperty.Set(44),

                new VisualState(VisualState.VisualElement.Normal),
                new VisualState(VisualState.VisualElement.Disabled)
                {
                    TimePicker.TextColorProperty.Set().Light(AppColors.Gray300).Dark(AppColors.Gray600),
                }
            },

            // "Page"

            new Style<Page>(applyToDerivedTypes: true)
            {
                Page.PaddingProperty.Set(0),
                Page.BackgroundColorProperty.Set().Light(Colors.White).Dark(Colors.Black),
            },

            // "Shell"

            new Style<Shell>(applyToDerivedTypes: true)
            {
                Shell.NavBarHasShadowProperty.Set(0),
                Shell.BackgroundColorProperty.Set().Light(AppColors.Primary).Dark(AppColors.Gray950),
                Shell.ForegroundColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
                Shell.TitleColorProperty.Set().Light(Colors.White).Dark(Colors.White),
                Shell.DisabledColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray950),
                Shell.UnselectedColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray200),
                Shell.TabBarBackgroundColorProperty.Set().Light(Colors.White).Dark(Colors.Black),
                Shell.TabBarForegroundColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
                Shell.TabBarTitleColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
                Shell.TabBarUnselectedColorProperty.Set().Light(AppColors.Gray900).Dark(AppColors.Gray200),
            },

            // "NavigationPage"

            new Style<NavigationPage>
            {
                NavigationPage.BarBackgroundColorProperty.Set().Light(AppColors.Primary).Dark(AppColors.Gray950),
                NavigationPage.BarTextColorProperty.Set().Light(AppColors.Gray200).Dark(Colors.White),
                NavigationPage.IconColorProperty.Set().Light(AppColors.Gray200).Dark(Colors.White),
            },

            // "TabbedPage"

            new Style<TabbedPage>
            {
                TabbedPage.BarBackgroundColorProperty.Set().Light(Colors.White).Dark(AppColors.Gray950),
                TabbedPage.BarTextColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
                TabbedPage.UnselectedTabColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray500),
                TabbedPage.SelectedTabColorProperty.Set().Light(AppColors.Gray950).Dark(AppColors.Gray100),
            },
        };
}
