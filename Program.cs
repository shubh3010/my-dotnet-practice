using blogpractice.Repository;
using blogpractice.Services;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

    builder.Services.AddDbContext<BloggingContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddScoped<IPostRepository, PostRepository>();
    builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

    builder.Services.AddScoped<IPostService,PostService>();
    builder.Services.AddScoped<IAuthorService,AuthorService>();

    builder.Services.AddScoped<ITagRepository, TagRepository>();
    builder.Services.AddScoped<ITagService, TagService>();

    builder.Services.AddEndpointsApiExplorer();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();