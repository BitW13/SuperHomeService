using AutoMapper;
using Common.Entity.ShoppingPlannerService;
using Microsoft.AspNetCore.Mvc;
using ShoppingPlannerService.Bll.BusinessLogic.Interfaces;
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
        private readonly IBusinessLogic db;
        private readonly IMapper mapper;

        public TypeOfPurchaseController(IMapper mapper, IBusinessLogic db)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EditTypeOfPurchase>> Get()
        {
            IEnumerable<TypeOfPurchase> typeOfPurchases = await db.TypeOfPurchases.GetAllAsync();

            IEnumerable<EditTypeOfPurchase> models = mapper.Map<IEnumerable<EditTypeOfPurchase>>(typeOfPurchases);

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            TypeOfPurchase typeOfPurchase = await db.TypeOfPurchases.GetItemByIdAsync(id);

            if (typeOfPurchase == null)
            {
                return NotFound();
            }

            EditTypeOfPurchase model = mapper.Map<EditTypeOfPurchase>(typeOfPurchase);

            return Ok(model);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTypeOfPurchase model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            TypeOfPurchase typeOfPurchase = await db.TypeOfPurchases.CreateAsync(mapper.Map<TypeOfPurchase>(model));

            EditTypeOfPurchase newModel = mapper.Map<EditTypeOfPurchase>(typeOfPurchase);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]EditTypeOfPurchase model)
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

            await db.TypeOfPurchases.UpdateAsync(mapper.Map<TypeOfPurchase>(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            TypeOfPurchase typeOfPurchase = await db.TypeOfPurchases.GetItemByIdAsync(id);

            if (typeOfPurchase == null)
            {
                return NotFound();
            }

            IEnumerable<Purchase> purchases = await db.Purchases.GetByTypeOfPurchaseIdAsync(id);

            if ((purchases.ToList()).Count != 0)
            {
                foreach (var purchase in purchases)
                {
                    purchase.TypeOfPurchaseId = 0;
                    await db.Purchases.UpdateAsync(purchase);
                }
            }
            await db.TypeOfPurchases.DeleteAsync(typeOfPurchase.Id);

            EditTypeOfPurchase model = mapper.Map<EditTypeOfPurchase>(typeOfPurchase);

            return Ok(model);
        }
    }
}