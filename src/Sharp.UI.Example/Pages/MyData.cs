namespace ExampleApp;


public class MyData
{
    public int Id { get; set; }
    public string Text { get; set; }

    public static IEnumerable<MyData> Source = Enumerable.Range(1, 1000).Select(id => new MyData
    {
        Id = id,
        Text = $"Lorem ipsum dolor sit amet. Sit quos odit et reiciendis delectus et " +
        $"ullam quis aut Quis quia! In sequi quasi quo asperiores repellat a totam " +
        $"quod sit odio quaerat et odit molestiae et magni perferendis rem accusantium " +
        $"asperiores. In exercitationem totam qui consectetur quae et cupiditate suscipit " +
        $"qui labore illum ut autem dolorem.Ut rerum harum non voluptatem officiis qui " +
        $"voluptas nulla ut nulla explicabo ut itaque quaerat quo corrupti nulla cum " +
        $"blanditiis reiciendis. Et ratione voluptate et autem fugit ad ratione ipsam " +
        $"aut dolor nihil. Vel nihil tempore et consectetur saepe et quia internos qui " +
        $"minima dolorem. Aut nemo commodi ut maiores autem ab magni nihil ut nemo " +
        $"exercitationem. A error deserunt in culpa veniam ut beatae provident aut animi " +
        $"reiciendis non similique dolores sed omnis quae in dolorum enim. Et velit dolore " +
        $"ea dolores nihil ut rerum voluptatem sit deserunt asperiores aut libero quisquam."
    });
}