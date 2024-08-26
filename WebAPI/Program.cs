using Business.Abstract;
using Business.Concrete;
using Business.Security.Encryption;
using Business.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//React tarafýndan istek atýlmasýna izin verir
// CORS ekle
var myOrigins = "AllowAllOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(myOrigins,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

//injection added
builder.Services.AddControllers();
builder.Services.AddSingleton<IEmployeeService, EmployeeManager>();
builder.Services.AddSingleton<IEmployeeDal, EfEmployeeDal>();
builder.Services.AddSingleton<IProjectService, ProjectManager>();
builder.Services.AddSingleton<IProjectDal, EfProjectDal>();
builder.Services.AddSingleton<ITaskService, TaskManager>();
builder.Services.AddSingleton<ITaskDal, EfTaskDal>();
builder.Services.AddSingleton<ITeamService, TeamManager>();
builder.Services.AddSingleton<ITeamDal, EfTeamDal>();
builder.Services.AddSingleton<ITimeLogService, TimeLogManager>();
builder.Services.AddSingleton<ITimeLogDal, EfTimeLogDal>();
builder.Services.AddSingleton<IReportService, ReportManager>();
builder.Services.AddSingleton<IReportDal, EfReportDal>();
builder.Services.AddSingleton<ITaskStatusService, TaskStatusManager>();
builder.Services.AddSingleton<ITaskStatusDal, EfTaskStatusDal>();
//Auth
builder.Services.AddSingleton<ITokenHelper, JwtHelper>();
builder.Services.AddSingleton<IAuthService, AuthManager>();


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseRouting();

// CORS kullan
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.Run();
