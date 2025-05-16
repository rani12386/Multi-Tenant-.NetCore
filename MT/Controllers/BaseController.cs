using Microsoft.AspNetCore.Mvc;
using MT.Extensions;
using MT.Helpers;

namespace MT.Controllers;
public class BaseController : Controller
{
    internal async Task AddFlashMessageAsync(FlashMessageTypes type, string message)
    {
        // Simulate some asynchronous operation if needed
        await Task.CompletedTask;
        string key = type.ToString();
        string encodedMessage = message.HtmlEncode();
        if (TempData is not null)
        {
            if (!TempData.ContainsKey(key))
                TempData.Add(key, encodedMessage);

            else
                TempData[key] = encodedMessage;

            TempData.Keep();
        }
    }

}
