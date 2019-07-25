using AutoMapper;
using Common.Entity.ShoppingPlannerService;
using Microsoft.AspNetCore.Mvc;
using ShoppingPlannerService.PL;
using ShoppingPlannerService.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingPlannerService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfPurchaseController : ControllerBase
    {
        private readonly IPresenterLayer db;
        private readonly IMapper mapper;

        public TypeOfPurchaseController(IMapper mapper, IPresenterLayer db)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TypeOfPurchase>> Get()
        {
            return await db.TypeOfPurchases.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            TypeOfPurchase type = await db.TypeOfPurchases.GetItemByIdAsync(id);

            if (type == null)
            {
                return NotFound();
            }

            return Ok(type);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTypeOfPurchase model)
        {
            TypeOfPurchase type;

            if (model == null)
            {
                type = await db.TypeOfPurchases.CreateAsync(ShoppingPlannerDefaultValues.DefaultTypeOfPurchase.TypeOfPurchase);

                return Ok(type);
            }

            type = await db.TypeOfPurchases.CreateAsync(ShoppingPlannerDefaultValues.DefaultTypeOfPurchase.VerificationAndCorrectionDataForCreating(mapper.Map<TypeOfPurchase>(model)));

            return Ok(type);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]TypeOfPurchase model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            await db.TypeOfPurchases.UpdateAsync(ShoppingPlannerDefaultValues.DefaultTypeOfPurchase.VerificationAndCorrectionDataForEdit(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            TypeOfPurchase type = await db.TypeOfPurchases.GetItemByIdAsync(id);

            if (type == null)
            {
                return NotFound();
            }

            IEnumerable<Purchase> purchases = await db.Purchases.GetByTypeOfPurchaseIdAsync(id);

            if ((purchases.ToList()).Count != 0)
            {
                foreach (var purchase in purchases)
                {
                    purchase.TypeOfPurchaseId = ShoppingPlannerDefaultValues.DefaultPurchase.Purchase.TypeOfPurchaseId;
                    await db.Purchases.UpdateAsync(purchase);
                }
            }
            await db.TypeOfPurchases.DeleteAsync(type.Id);

            return Ok();
        }
    }
}