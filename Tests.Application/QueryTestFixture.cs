using System;
using Application.Common.Mappings;
using AutoMapper;
using Infra.Persistence;
using Xunit;

namespace Tests.Application
{


        public sealed class QueryTestFixture : IDisposable
        {
            public QueryTestFixture()
            {
                Context = ApplicationDbContextFactory.Create();

            }
            public ApplicationDbContext Context { get; }

            public void Dispose()
            {
                ApplicationDbContextFactory.Destroy(Context);
            }
        }

        [CollectionDefinition("QueryTests")]
        public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
    }
