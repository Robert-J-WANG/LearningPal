using Microsoft.AspNetCore.Mvc.RazorPages;

// 定义页面所需的数据结构
public class LearningTask(string title, bool isCompleted)
{
    public string Title { get; set; } = title;
    public bool IsCompleted { get; set; } = isCompleted;
}

// 页面的后台逻辑
public class IndexModel : PageModel
{
    // 存储任务列表的属性
    public List<LearningTask> Tasks { get; private set; } = new();

    // 当页面被请求时 (GET)，这个方法会被调用
    public void OnGet()
    {
        // 在这里创建假数据（实际项目中会从API获取）
        Tasks = new List<LearningTask>
        {
            new("学习 .NET Minimal API", true),
            new("体验 Razor Pages", true),
            new("掌握 Blazor 交互", false)
        };
    }
}