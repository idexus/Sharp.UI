﻿namespace ExampleApp;

using Sharp.UI;

public class MultiTriggerPage : ContentPage
{
	public MultiTriggerPage()
	{
        Content = new VStack
        {
            new Entry("email", out var email).Text(""),
            new Entry("phone", out var phone).Text(""),
            new Button("Save")
                .Triggers(
                    new MultiTrigger(typeof(Button))
                        .Conditions(new Condition[]
                        {
                            new BindingCondition()
                                .Binding(e => e.Path("Text.Length").Source(email))
                                .Value(0),

                            new BindingCondition()
                                .Binding(e => e.Path("Text.Length").Source(phone))
                                .Value(0)
                        })
                        .Setters(new Setter<Entry>(e => e.IsEnabled(false)))                   
                )
        }
        .WidthRequest(400)
        .VerticalOptions(LayoutOptions.Center);
    }
}