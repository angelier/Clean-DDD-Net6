using Core.Attributes;
using Core.Entities;
using Core.Enums;
using Infrastructure.Persistence.Repositories;

namespace Domain.Services
{
    [InjectableService(EServices.Scope)]
    public class TestService
    {
        private readonly IGenericRepository _repository;

        public TestService(IGenericRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Ejemplo para devolver una entidad por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TestEntity> GetTestById(int id) => await _repository.GetById<TestEntity>(id);

        public async Task<List<TestEntity>> GetTests()
        {
            return await Task.FromResult(new List<TestEntity>()
            {
                new TestEntity() { Id = 1 },
                new TestEntity() { Id = 2 }
            });
        }

    }
}
