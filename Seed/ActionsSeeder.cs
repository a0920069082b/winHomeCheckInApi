using System;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Models;

namespace Seed
{
    public class ActionsSeeder
    {
        public ActionsSeeder(CustomContext context)
        {
            if (!context.actions.Any())
            {
                Task.Run(async () =>
                {
                    await context.actions.AddAsync(new ActionsModels() { action_id = 1, action = "新增", create_user_id = null, update_user_id = null, create_time = DateTime.Now, update_time = DateTime.Now });
                    await context.SaveChangesAsync();
                    await context.actions.AddAsync(new ActionsModels() { action_id = 2, action = "查詢", create_user_id = null, update_user_id = null, create_time = DateTime.Now, update_time = DateTime.Now });
                    await context.SaveChangesAsync();
                    await context.actions.AddAsync(new ActionsModels() { action_id = 3, action = "修改", create_user_id = null, update_user_id = null, create_time = DateTime.Now, update_time = DateTime.Now });
                    await context.SaveChangesAsync();
                    await context.actions.AddAsync(new ActionsModels() { action_id = 4, action = "刪除", create_user_id = null, update_user_id = null, create_time = DateTime.Now, update_time = DateTime.Now });
                    await context.SaveChangesAsync();
                }).Wait();
            }
        }
    }
}