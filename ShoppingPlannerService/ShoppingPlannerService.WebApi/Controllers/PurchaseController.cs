using AutoMapper;
using Common.Entity.ShoppingPlannerService;
using Microsoft.AspNetCore.Mvc;
using ShoppingPlannerService.Bll.BusinessLogic.Interfaces;
using ShoppingPlannerService.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IBusinessLogic db;

        private readonly IMapper mapper;

        public PurchaseController(IBusinessLogic db, IMapper mapper)
        {
            this.db = db;

            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ShoppingCard>> Get()
        {
            IEnumerable<Purchase> purchases = await db.Purchases.GetAllAsync();

            List<ShoppingCard> shoppingCards = new List<ShoppingCard>();

            foreach(var purchase in purchases)
            {
                TypeOfPurchase typeOfPurchase = await db.TypeOfPurchases.GetItemByIdAsync(purchase.TypeOfPurchaseId);

                ShoppingCategory shoppingCategory = await db.ShoppingCategories.GetItemByIdAsync(purchase.ShoppingCategoryId);

                shoppingCards.Add(new ShoppingCard { Purchase = purchase, TypeOfPurchase = typeOfPurchase, ShoppingCategory = shoppingCategory });
            }

            return shoppingCards;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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

            TypeOfPurchase typeOfPurchase = await db.TypeOfPurchases.GetItemByIdAsync(purchase.TypeOfPurchaseId);

            ShoppingCategory shoppingCategory = await db.ShoppingCategories.GetItemByIdAsync(purchase.ShoppingCategoryId);

            ShoppingCard shoppingCard = new ShoppingCard
            {
                Purchase = purchase,
                TypeOfPurchase = typeOfPurchase,
                ShoppingCategory = shoppingCategory
            };

            return Ok(shoppingCard);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePurchase model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            Purchase purchase = await db.Purchases.CreateAsync(mapper.Map<Purchase>(model));

            EditPurchase newModel = mapper.Map<EditPurchase>(purchase);

            return Ok(newModel);
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