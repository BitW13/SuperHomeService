using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Entity.TaskPlannerService;
using TaskPlannerService.Bll.Services.Interfaces;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Bll.Services.Implementations
{
    public class SeverityService : ISeverityService
    {
        private readonly ISeverityRepository db;

        public SeverityService(ISeverityRepository db)
        {
            this.db = db;
        }

        public async Task<Severity> CreateAsync(Severity item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<Severity> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<Severity>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<Severity> GetItemByIdAsync(int id)
        {
            Severity severity = await db.GetItemByIdAsync(id);

            if (severity == null)
            {
                return TaskPlannerServiceDefaultValues.DefaultSeverity.Severity;
            }

            return severity;
        }

        public async Task UpdateAsync(Severity item)
        {
            await db.UpdateAsync(item);
        }
    }
}
