using System.Collections;

namespace Sharp.UI
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.Shell))]
    public interface IContentPageShellAttachedProperties
    {
        [AttachedName("PresentationMode")]
        PresentationMode ShellPresentationMode { get; set; }

        [AttachedName("BackgroundColor")]
        Color ShellBackgroundColor { get; set; }

        [AttachedName("ForegroundColor")]
        Color ShellForegroundColor { get; set; }

        [AttachedName("TitleColor")]
        Color ShellTitleColor { get; set; }

        [AttachedName("DisabledColor")]
        Color ShellDisabledColor { get; set; }

        [AttachedName("UnselectedColor")]
        Color ShellUnselectedColor { get; set; }

        [AttachedName("NavBarHasShadow")]
        bool ShellNavBarHasShadow { get; set; }

        [AttachedName("NavBarIsVisible")]
        bool ShellNavBarIsVisible { get; set; }

        [AttachedName("TitleView")]
        Microsoft.Maui.Controls.View ShellTitleView { get; set; }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.ContentPage))] 
    public partial class ContentPage : IContentPageShellAttachedProperties
    {
        public ContentPage()
        {
            var attribute = this.GetType().CustomAttributes.FirstOrDefault(e => e.AttributeType.Name.Equals("ViewModelAttribute"));

#if DEBUG
            HotReload.RegisterActive(this);
            if (attribute == null && HotReload.BindingContext != null) BindingContext = HotReload.BindingContext;
#endif

            if (attribute != null && BindingContext == null)
            {
                var type = attribute.ConstructorArguments.FirstOrDefault().Value as Type;
                if (BindingContext == null && Application.ServiceProvider != null)
                {
                    BindingContext = ActivatorUtilities.GetServiceOrCreateInstance(Application.ServiceProvider, type);
                }
            }
        }

        public ContentPage(string title) : this()
        {
            this.Title = title;
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.FlyoutPage))] 
    public partial class FlyoutPage { }

    [SharpObject(typeof(Microsoft.Maui.Controls.NavigationPage))] 
    public partial class NavigationPage : IEnumerable
    {
        public IEnumerator GetEnumerator() => throw new NotImplementedException();
        public void Add(Microsoft.Maui.Controls.Page page) => this.PushAsync(page);
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.TabbedPage))]
    public partial class TabbedPage { }
}
