namespace ExampleApp;


public class MyData
{
    public int Id { get; set; }
    public string Text { get; set; }

    public static IEnumerable<MyData> Source = Enumerable.Range(1, 10).Select(id => new MyData
    {
        Id = id,
        Text = $"Lorem ipsum dolor sit amet. Sit quos odit et reiciendis delectus et " +
        $"ullam quis aut Quis quia! In sequi quasi quo asperiores repellat a totam " +
        $"quod sit odio quaerat et odit molestiae et magni perferendis rem accusantium " +
        $"asperiores. In exercitationem totam qui consectetur quae et cupiditate suscipit "
    });
}