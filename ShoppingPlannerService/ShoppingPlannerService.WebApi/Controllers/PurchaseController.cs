using AutoMapper;
using Common.Entity.ShoppingPlannerService;
using Microsoft.AspNetCore.Mvc;
using ShoppingPlannerService.Bll.BusinessLogic.Interfaces;
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
                card = await db.Cards.CreateAsync(NoteServiceDefaultValues.DefaultNote.Note);

                return Ok(card);
            }

            card = await db.Cards.CreateAsync(NoteServiceDefaultValues.DefaultNote.VerificationAndCorrectioDataForCreating(mapper.Map<Note>(model)));

            return Ok(card);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]EditPurchase model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (id != model.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            await db.Purchases.UpdateAsync(mapper.Map<Purchase>(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Purchase purchase = await db.Purchases.GetItemByIdAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            await db.Purchases.DeleteAsync(purchase.Id);

            EditPurchase model = mapper.Map<EditPurchase>(purchase);

            return Ok(model);
        }
    }
}