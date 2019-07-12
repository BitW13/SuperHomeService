using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Entity.ShoppingPlannerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingPlannerService.Bll.BusinessLogic.Interfaces;
using ShoppingPlannerService.WebApi.Models;

namespace ShoppingPlannerService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCategoryController : ControllerBase
    {
        private readonly IBusinessLogic db;
        private readonly IMapper mapper;

        public ShoppingCategoryController(IMapper mapper, IBusinessLogic db)
        {            
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EditShoppingCategory>> Get()
        {
            IEnumerable<ShoppingCategory> shoppingCategories = await db.ShoppingCategories.GetAllAsync();

            IEnumerable<EditShoppingCategory> models = mapper.Map<IEnumerable<EditShoppingCategory>>(shoppingCategories);

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ShoppingCategory shoppingCategory = await db.ShoppingCategories.GetItemByIdAsync(id);

            if (shoppingCategory == null)
            {
                return NotFound();
            }

            EditShoppingCategory model = mapper.Map<EditShoppingCategory>(shoppingCategory);

            return Ok(model);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateShoppingCategory model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            model.IsOn = true;

            ShoppingCategory shoppingCategory = await db.ShoppingCategories.CreateAsync(mapper.Map<ShoppingCategory>(model));

            EditShoppingCategory newModel = mapper.Map<EditShoppingCategory>(shoppingCategory);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]EditShoppingCategory model)
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

            await db.ShoppingCategories.UpdateAsync(mapper.Map<ShoppingCategory>(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ShoppingCategory shoppingCategory = await db.ShoppingCategories.GetItemByIdAsync(id);

            if (shoppingCategory == null)
            {
                return NotFound();
            }

            IEnumerable<Purchase> purchases = await db.Purchases.GetByShoppingCategoryIdAsync(id);

            if ((purchases.ToList()).Count != 0)
            {
                foreach (var purchase in purchases)
                {
                    await db.Purchases.DeleteAsync(purchase.Id);
                }
            }
            await db.ShoppingCategories.DeleteAsync(shoppingCategory.Id);

            EditShoppingCategory model = mapper.Map<EditShoppingCategory>(shoppingCategory);

            return Ok(model);
        }
    }
}