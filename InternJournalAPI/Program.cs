using InternJournalAPI.Controllers;
using InternJournalAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<JournalContext>(options =>
    options.UseSqlite("Data Source=journal.db"));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<JournalContext>();

    // Only seed if the table is empty
    if (!dbContext.Entries.Any())
    {
        dbContext.Entries.AddRange(
            new Entry
            {
                Title = "Seeding Day!",
                Body = "This entry was seeded automatically when the app launched.",
                Mood = "Optimistic",
                Tags = new List<string> { "seed", "dev", "backend" },
                Date = DateTime.Now
            },
            new Entry
            {
                Title = "Validation Win",
                Body = "Just added model validation using data annotations.",
                Mood = "Focused",
                Tags = new List<string> { "validation", "api", "csharp" },
                Date = DateTime.Now
            }
        );

        dbContext.SaveChanges();
    }
}


app.MapControllers();
app.Run();
