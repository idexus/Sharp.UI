namespace Sharp.UI;

public class AttachedBehavior<TView, TBehavior> :  Behavior<TView>
    where TView : Microsoft.Maui.Controls.View
    where TBehavior : Behavior<TView>, new()
{
    public static readonly BindableProperty AttachedProperty =
    BindableProperty.CreateAttached("Attached", typeof(bool), typeof(TBehavior), false, propertyChanged: OnAttachedBehaviorChanged);

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
