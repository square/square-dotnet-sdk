using NUnit.Framework;
using Square.Core;

namespace Square.Test.Unit;

[TestFixture]
public class SquareErrorTest
{
    [Test]
    public void CreatesError()
    {
        var json =
            "{\"errors\":[{\"category\":\"Unknown\",\"code\":\"Unknown\",\"detail\":\"Test error\"}]}";
        var exception = new SquareApiException("Test error", 400, json);
        Assert.Multiple(() =>
        {
            Assert.That(exception.Message, Does.StartWith("Test error"));
            Assert.That(exception.Message, Does.Contain("Status code: 400"));
            Assert.That(exception.StatusCode, Is.EqualTo(400));
            Assert.That(exception.Errors, Has.Count.EqualTo(1));
            Assert.That(exception.Errors[0].Code, Is.EqualTo(ErrorCode.FromCustom("Unknown")));
        });
    }

    [Test]
    public void CreatesErrorWithBody()
    {
        var body = new Dictionary<string, object> { ["foo"] = "bar" };
        var json = JsonUtils.Serialize(
            new
            {
                errors = new[]
                {
                    new
                    {
                        category = "Unknown",
                        code = "Unknown",
                        foo = body,
                    },
                },
            }
        );
        var exception = new SquareApiException("Test error", 400, json);
        Assert.That(exception.Message, Does.Contain(json));
    }

    [Test]
    public void HandlesSquareApiV2Errors()
    {
        var body = new
        {
            errors = new[]
            {
                new
                {
                    category = "API_ERROR",
                    code = "BAD_REQUEST",
                    detail = "Invalid input",
                    field = "email",
                },
            },
        };
        var json = JsonUtils.Serialize(body);
        var exception = new SquareApiException("Invalid input", 400, json);
        var error = exception.Errors[0];
        Assert.Multiple(() =>
        {
            Assert.That(error.Category, Is.EqualTo(ErrorCategory.ApiError));
            Assert.That(error.Code, Is.EqualTo(ErrorCode.BadRequest));
            Assert.That(error.Detail, Is.EqualTo("Invalid input"));
            Assert.That(error.Field, Is.EqualTo("email"));
        });
    }

    [Test]
    public void HandlesSquareApiV1Errors()
    {
        var body = new
        {
            type = "INVALID_REQUEST",
            message = "Invalid field value",
            field = "customer_id",
        };
        var json = JsonUtils.Serialize(body);
        var exception = new SquareApiException("Invalid field value", 400, json);
        var error = exception.Errors[0];
        Assert.Multiple(() =>
        {
            Assert.That(exception.Errors, Has.Count.EqualTo(1));
            Assert.That(error.Category, Is.EqualTo(new ErrorCategory("V1_ERROR")));
            Assert.That(error.Code, Is.EqualTo(ErrorCode.FromCustom("INVALID_REQUEST")));
            Assert.That(error.Detail, Is.EqualTo("Invalid field value"));
            Assert.That(error.Field, Is.EqualTo("customer_id"));
        });
    }

    [Test]
    public void HandlesV1ErrorsWithMissingType()
    {
        var body = new { message = "Invalid field value", field = "customer_id" };
        var json = JsonUtils.Serialize(body);
        var exception = new SquareApiException("Invalid field value", 400, json);
        var error = exception.Errors[0];
        Assert.Multiple(() =>
        {
            Assert.That(exception.Errors, Has.Count.EqualTo(1));
            Assert.That(error.Code, Is.EqualTo(ErrorCode.FromCustom("Unknown")));
        });
    }

    [Test]
    public void CombinesAllInformationInMessage()
    {
        var body = new { errors = new[] { new { detail = "Invalid input" } } };
        var json = JsonUtils.Serialize(body);
        var exception = new SquareApiException("API Error", 400, json);
        Assert.Multiple(() =>
        {
            Assert.That(exception.Message, Does.Contain("API Error"));
            Assert.That(exception.Message, Does.Contain("Status code: 400"));
            Assert.That(exception.Message, Does.Contain("Invalid input"));
        });
    }
}
