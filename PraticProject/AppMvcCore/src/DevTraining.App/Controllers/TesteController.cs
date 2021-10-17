using DevTraining.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevTraining.App.Controllers
{
    /// <summary>
    /// Explorando sobre a questão de Logger, que funciona de maneira interna no asp.net core.
    /// </summary>
    public class TesteController : BaseController
    {
        private readonly ILogger<TesteController> _logger;

        public TesteController(ILogger<TesteController> logger, INotificador notificador) : base(notificador)
        {
            _logger = logger;
        }

        public ActionResult Teste()
        {
            _logger.LogDebug(LoggingConfig.CreateAction, "Log Debug");
            _logger.LogInformation(LoggingConfig.EditAction, "Log Information");
            _logger.LogWarning(LoggingConfig.GetAction, "Log Warning");
            _logger.LogError(LoggingConfig.DeleteAction, "Log Error");
            _logger.LogCritical("Log Critical");

            return View();
        }

    }
}
