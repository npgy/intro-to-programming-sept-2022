using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<CourseRegistrationManager>();

var app = builder.Build();

app.MapPost("/registrations", (
    [FromBody] CourseRegistrationRequest request,
    [FromServices] CourseRegistrationManager manager) =>
{
    var response = manager.RegisterForCourse(request);
    if(response.IsRegistered)
    {
        return Results.Ok(response);
    }
    else
    {
        return Results.BadRequest(response);
    }
});

Console.WriteLine("Fixing to run your web application!");
app.Run();
Console.WriteLine("Done running your web application!");

/*
 * We will aks the user for their:
 * Email address
 * The ID of the course they'd like to take.
 * The ID of the offering of that course they'd like to take.
 * 
 * We will return to them:
 * (Happy Path): A message that says they are registered, and a registration ID, and the date of the course.
 * (Error): A message that says they cannot enroll for the coursem, and reason.
 */

/*Console.WriteLine("Register for a Course");

Console.Write("Enter your email address: ");
string? email = Console.ReadLine();

Console.Write("Enter the Course ID: ");
string? courseId = Console.ReadLine();

Console.Write("The Course Offering Id: ");
string? courseOfferingId = Console.ReadLine();

Console.WriteLine($"I see you are {email}, want to take {courseId} of {courseOfferingId}");

// WTCYWYH - Write the code you wish you had

CourseRegistrationManager courseRegistrationManager = new CourseRegistrationManager();

CourseRegistrationRequest request = new CourseRegistrationRequest(email, courseId, courseOfferingId);

CourseRegistrationResponse response = courseRegistrationManager.RegisterForCourse(request);

if(response.IsRegistered)
{
    Console.WriteLine("Congratulations! You have been registered!");
    Console.WriteLine($"Your Registration Id is {response.Id}");
    Console.WriteLine($"The course starts on {response.courseDate:d}");
}
else
{
    Console.WriteLine("Sorry you are not registered for the course!");
}*/