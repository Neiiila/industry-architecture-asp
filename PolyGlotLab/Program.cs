using PolyGlotLab.Services.User;
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    //builder.Services.AddSingleton<IUserService, UserService>();
    builder.Services.AddScoped<IUserService, UserService>();
}


var app = builder.Build();
{
    /* pipline that contains many Middlewares */
    app.UseExceptionHandler("/error"); // add a middleware to handle exceptions for each request recieved 
    // if an exception is thrown, the middleware will catch it and redirect the request to the error page
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
