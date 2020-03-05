using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Models;

namespace Seed
{
    public class FunctionNamesSeeder
    {
        public FunctionNamesSeeder(CustomContext context)
        {
            if (!context.function_names.Any())
            {
                List<FunctionNamesModels> FunctionNames = new List<FunctionNamesModels>();
                Task.Run(async () =>
                {
                    await context.function_names.AddAsync(new FunctionNamesModels() { function_name_id = 1, function_name = "Order", function_name_chinese = "點餐", create_user_id = null, update_user_id = null, create_time = DateTime.Now, update_time = DateTime.Now });
                    await context.SaveChangesAsync();
                    await context.function_names.AddAsync(new FunctionNamesModels() { function_name_id = 2, function_name = "ProductManage", function_name_chinese = "餐點管理", create_user_id = null, update_user_id = null, create_time = DateTime.Now, update_time = DateTime.Now });
                    await context.SaveChangesAsync();
                    await context.function_names.AddAsync(new FunctionNamesModels() { function_name_id = 3, function_name = "OrderStatusManage", function_name_chinese = "訂單狀態管理", create_user_id = null, update_user_id = null, create_time = DateTime.Now, update_time = DateTime.Now });
                    await context.SaveChangesAsync();
                    await context.function_names.AddAsync(new FunctionNamesModels() { function_name_id = 4, function_name = "HRManage", function_name_chinese = "人事管理", create_user_id = null, update_user_id = null, create_time = DateTime.Now, update_time = DateTime.Now });
                    await context.SaveChangesAsync();
                    await context.function_names.AddAsync(new FunctionNamesModels() { function_name_id = 5, function_name = "AccountsManage", function_name_chinese = "帳務管理", create_user_id = null, update_user_id = null, create_time = DateTime.Now, update_time = DateTime.Now });
                    await context.SaveChangesAsync();
                }).Wait();

            }
        }
    }
}