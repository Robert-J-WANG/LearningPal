// Program.cs

// 1. 创建一个应用程序构建器
var builder = WebApplication.CreateBuilder(args);

// 启用 Swagger/OpenAPI，方便我们可视化地测试 API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. 创建 Web 应用
// 2. 创建 Web 应用
var app = builder.Build();

// 如果是开发环境，就使用 Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 3. 创建一个内存中的任务列表作为我们的“假数据库”
var tasks = new List<LearningTask>
{
    new(1, "学习 .NET Minimal API", true),
    new(2, "体验 Razor Pages", false),
    new(3, "掌握 Blazor 交互", false)
};

// 4. 定义我们的 API 路由 (Endpoints)
// 当有人访问 /tasks 时，返回所有任务
app.MapGet("/tasks", () => tasks);

// 当有人访问 /tasks/{id} 时，返回单个任务
app.MapGet("/tasks/{id}", (int id) => {
    var task = tasks.FirstOrDefault(t => t.Id == id);
    return task is not null ? Results.Ok(task) : Results.NotFound();
});

// 添加一个从根路径 (/) 到 Swagger UI (/swagger) 的重定向，方便开发
app.MapGet("/", () => Results.Redirect("/swagger"));

// 5. 运行应用
app.Run();

// 6. 定义一个学习任务的数据结构 (C# 12 的主构造函数写法)
public class LearningTask(int id, string title, bool isCompleted)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public bool IsCompleted { get; set; } = isCompleted;
}