namespace ExampleApp
{
    using Sharp.UI;
    using System.Windows.Input;

    //public static class LabelExt
    //{
    //    public static T CustomFontSize<T>(this T obj,
    //        double fontSize)
    //        where T : Microsoft.Maui.Controls.Label
    //    {
    //        bool isStyling = (bool)obj.GetValue(FluentStyling.IsStyling);
    //        if (isStyling)
    //        {
    //            var style = obj.Style;
    //            style.Setters.Add(new Setter { Property = Label.FontSizeProperty, Value = fontSize });
    //        }
    //        else
    //            obj.FontSize = fontSize;
    //        return obj;
    //    }
    //}

    [BindableProperties]
    public interface IMyViewModel
    {
        int Counter { get; set; }
        double SliderValue { get; set; }
    }

    [SharpObject]
    public partial class MyViewModel : BindableObject, IMyViewModel
    {
        public ICommand CountCommand { get; }

        public MyViewModel()
        {
            CountCommand = new Command(Count);
        }

        public void Count()
        {
            Counter += 1;
        }
    }
}

