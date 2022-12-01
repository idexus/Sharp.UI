namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.EventTrigger),
    generateAdditionalConstructors: false,
    generateNoParamConstructor: false)]
    public partial class EventTrigger
    {
        public EventTrigger(string @event) : this(new Microsoft.Maui.Controls.EventTrigger { Event = @event }) { }
    }
}
