using System;
using Infra.Persistence;
using Xunit;

namespace Tests.Application
{
        public class CommandTestBase : IDisposable
        {
            public CommandTestBase()
            {
                Context = ApplicationDbContextFactory.Create();
            }

            public ApplicationDbContext Context { get; }

            public void Dispose()
            {
                ApplicationDbContextFactory.Destroy(Context);
            }
        }
    }

