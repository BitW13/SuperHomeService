using Common.Entity.TaskPlannerService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerService.Bll.Services.Interfaces;

namespace TaskPlannerService.PL.Severities
{
    public class SeverityPresenter : ISeverityPresenter
    {
        private readonly ISeverityService db;

        public SeverityPresenter(ISeverityService db)
        {
            this.db = db;
        }

        public async Task<Severity> CreateAsync(Severity item)
        {
            return await db.CreateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<Severity>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<Severity> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task<Severity> UpdateAsync(Severity item)
        {
            await db.UpdateAsync(item);

            return item;
        }
    }
}
