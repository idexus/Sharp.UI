namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.AbsoluteLayout))]
    public partial class AbsoluteLayout
    {
        public void Add(View view) => this.Children.Add(view);

        public void Add(IEnumerable<View> views)
        {
            foreach (var view in views)
                this.Children.Add(view);
        }

        public void Add(Action<IList<View>> builder)
        {
            List<View> views = new List<View>();
            builder(views);
            foreach (var view in views)
                this.Children.Add(view);
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.FlexLayout))]
    public partial class FlexLayout
    {
        public void Add(View view) => this.Children.Add(view);

        public void Add(IEnumerable<View> views)
        {
            foreach (var view in views)
                this.Children.Add(view);
        }

        public void Add(Action<IList<View>> builder)
        {
            List<View> views = new List<View>();
            builder(views);
            foreach (var view in views)
                this.Children.Add(view);
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Grid))] 
    public partial class Grid
    {
        public void Add(View view) => this.Children.Add(view);

        public void Add(IEnumerable<View> views)
        {
            foreach (var view in views)
                this.Children.Add(view);
        }

        public void Add(Action<IList<View>> builder)
        {
            List<View> views = new List<View>();
            builder(views);
            foreach (var view in views)
                this.Children.Add(view);
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.HorizontalStackLayout))] 
    public partial class HStack
    {
        public void Add(View view) => this.Children.Add(view);

        public void Add(IEnumerable<View> views)
        {
            foreach (var view in views)
                this.Children.Add(view);
        }

        public void Add(Action<IList<View>> builder)
        {
            List<View> views = new List<View>();
            builder(views);
            foreach (var view in views)
                this.Children.Add(view);
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.HorizontalStackLayout))]
    public partial class HorizontalStackLayout
    {
        public void Add(View view) => this.Children.Add(view);

        public void Add(IEnumerable<View> views)
        {
            foreach (var view in views)
                this.Children.Add(view);
        }

        public void Add(Action<IList<View>> builder)
        {
            List<View> views = new List<View>();
            builder(views);
            foreach (var view in views)
                this.Children.Add(view);
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.StackLayout))] 
    public partial class StackLayout
    {
        public void Add(View view) => this.Children.Add(view);

        public void Add(IEnumerable<View> views)
        {
            foreach (var view in views)
                this.Children.Add(view);
        }

        public void Add(Action<IList<View>> builder)
        {
            List<View> views = new List<View>();
            builder(views);
            foreach (var view in views)
                this.Children.Add(view);
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.VerticalStackLayout))] 
    public partial class VStack
    {
        public void Add(View view) => this.Children.Add(view);

        public void Add(IEnumerable<View> views)
        {
            foreach (var view in views)
                this.Children.Add(view);
        }

        public void Add(Action<IList<View>> builder)
        {
            List<View> views = new List<View>();
            builder(views);
            foreach (var view in views)
                this.Children.Add(view);
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.VerticalStackLayout))]
    public partial class VerticalStackLayout
    {
        public void Add(View view) => this.Children.Add(view);

        public void Add(IEnumerable<View> views)
        {
            foreach (var view in views)
                this.Children.Add(view);
        }

        public void Add(Action<IList<View>> builder)
        {
            List<View> views = new List<View>();
            builder(views);
            foreach (var view in views)
                this.Children.Add(view);
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.ContentPresenter))] 
    public partial class ContentPresenter { }
}
