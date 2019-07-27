using AutoMapper;
using Common.Entity.ShoppingPlannerService;
using Microsoft.AspNetCore.Mvc;
using ShoppingPlannerService.PL;
using ShoppingPlannerService.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPresenterLayer db;

        private readonly IMapper mapper;

        public PurchaseController(IPresenterLayer db, IMapper mapper)
        {
            this.db = db;

            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ShoppingCard>> Get()
        {
            return await db.Cards.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ShoppingCard card = await db.Cards.GetItemByIdAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePurchase model)
        {
            ShoppingCard card;

            if (model == null)
            {
                card = await db.Cards.CreateAsync(ShoppingPlannerDefaultValues.DefaultPurchase.Purchase);

                return Ok(card);
            }

            card = await db.Cards.CreateAsync(ShoppingPlannerDefaultValues.DefaultPurchase.VerificationAndCorrectionDataForCreating(mapper.Map<Purchase>(model)));

            return Ok(card);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Purchase model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            ShoppingCard card = await db.Cards.UpdateAsync(ShoppingPlannerDefaultValues.DefaultPurchase.VerificationAndCorrectionDataForEdit(model));

            return Ok(card);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await db.Purchases.DeleteAsync(id);

            return Ok();
        }
    }
}