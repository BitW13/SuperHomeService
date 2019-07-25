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
    public class ShoppingCategoryController : ControllerBase
    {
        private readonly IPresenterLayer db;
        private readonly IMapper mapper;

        public ShoppingCategoryController(IMapper mapper, IPresenterLayer db)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ShoppingCategory>> Get()
        {
            return await db.ShoppingCategories.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ShoppingCategory category = await db.ShoppingCategories.GetItemByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateShoppingCategory model)
        {
            ShoppingCategory category;

            if (model == null)
            {
                category = await db.ShoppingCategories.CreateAsync(ShoppingPlannerDefaultValues.DefaultShoppingCategory.ShoppingCategory);

                return Ok(category);
            }

            category = await db.ShoppingCategories.CreateAsync(ShoppingPlannerDefaultValues.DefaultShoppingCategory.VerificationAndCorrectionDataForCreating(mapper.Map<ShoppingCategory>(model)));

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ShoppingCategory model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            await db.ShoppingCategories.UpdateAsync(ShoppingPlannerDefaultValues.DefaultShoppingCategory.VerificationAndCorrectionDataForEdit(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ShoppingCategory category = await db.ShoppingCategories.GetItemByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            IEnumerable<Purchase> purchases = await db.Purchases.GetByShoppingCategoryIdAsync(id);

            if ((purchases.ToList()).Count != 0)
            {
                foreach (var purchase in purchases)
                {
                    purchase.ShoppingCategoryId = ShoppingPlannerDefaultValues.DefaultPurchase.Purchase.ShoppingCategoryId;
                    await db.Purchases.UpdateAsync(purchase);
                }
            }
            await db.ShoppingCategories.DeleteAsync(category.Id);

            return Ok();
        }
    }
}