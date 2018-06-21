using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FakeSender.Api.Controllers
{
    public interface IStorageController<T>
    {
        IActionResult GetAll();
        IActionResult Get(string To);
        IActionResult DeleteAll();
        IActionResult Delete(string To);
    }
}