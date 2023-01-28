using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;

namespace Template.Data.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrateOnInit(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope
                                    .ServiceProvider
                                    .GetService<TemplateContext>();

                serviceDb.Database.Migrate();
            }
        }

    }
}
