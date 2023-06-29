using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore.Tools;
using Application.Activities; 
using Application.Core; 
using MediatR;
using API.Extensions;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();


// builder.Services.AddDbContext<DataContext>(options =>
// options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
     

//          builder.Services.AddCors(opt =>
//             {
//                 opt.AddPolicy("CorsPolicy", policy =>
//                 {
//                     // allow cors pada url berikut
//                     policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
//                 });
//             });
//             builder.Services.AddMediatR(typeof(Application.Activities.List.Handler));
        
//              builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);


            builder.Services.AddControllers();
            // builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
     Seed.SeedData(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();


