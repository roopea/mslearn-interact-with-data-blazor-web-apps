using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazingPizza.Data;

namespace BlazingPizza.Controller
{
    [Route("specials")]
    [ApiController]
    public class SpecialsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly PizzaStoreContext _storeContext;

        public SpecialsController(PizzaStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
        {
            return (await _storeContext.Specials.ToListAsync()).OrderByDescending(s => s.BasePrice).ToList();
        }

    }
}
