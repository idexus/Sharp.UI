namespace CodeMarkup.Maui;

public class AttachedBehavior<TView, TBehavior> :  Behavior<TView>
    where TView : VisualElement
    where TBehavior : Behavior<TView>, new()
{
    static readonly BindableProperty AttachedProperty =
        BindableProperty.CreateAttached($"{nameof(TBehavior)}.AttachedProperty", typeof(bool), typeof(TBehavior), false, propertyChanged: OnAttachedBehaviorChanged);

    public static Setter Enable(bool enable) => new Setter { Property = AttachedProperty, Value = enable };

    static void OnAttachedBehaviorChanged(BindableObject obj, object oldValue, object newValue)
    {
        TView view = obj as TView;
        if (view == null) return;

        bool attachBehavior = (bool)newValue;
        if (attachBehavior)
        {
            view.Behaviors.Add(new TBehavior());
        }
        else
        {
            Behavior toRemove = view.Behaviors.FirstOrDefault(b => b is TBehavior);
            if (toRemove != null)
            {
                view.Behaviors.Remove(toRemove);
            }
        }
    }
}
