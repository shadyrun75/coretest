using CoreTest.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CoreTest.API.India.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetupController : ControllerBase
    {
        readonly Setup _setup;
        public SetupController(Setup setup) 
        { 
            _setup = setup;
        }

        [HttpGet]
        public Setup Get()
        {
            return _setup;
        }

        [HttpPost]
        public IActionResult Post(int priority, ActionType actionType, CaseType caseType)
        {
            _setup.Actions.RemoveAll(x => x.Case == caseType && x.Type == actionType);
            _setup.Actions.Add(new ActionElement(priority, actionType, caseType));
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(ActionType actionType, CaseType caseType)
        {
            _setup.Actions.RemoveAll(x => x.Case == caseType && x.Type == actionType);
            return Ok();
        }
    }
}
