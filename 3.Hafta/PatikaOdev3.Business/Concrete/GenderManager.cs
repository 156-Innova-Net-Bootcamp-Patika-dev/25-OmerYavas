using PatikaOdev3.Business.Absract;
using PatikaOdev3.Model.Common;
using PatikaOdev3.Model.Entities;

namespace PatikaOdev3.Business.Concrete
{
    public class GenderManager:IGenderService
    {
        private readonly IGenderService _genderService;

        public GenderManager(IGenderService genderService)
        {
            _genderService = genderService;
        }

        public EntityResult Delete(Gender entity)
        {
            return new EntityResult();

        }

        public EntityResult Delete(int id)
        {
            return new EntityResult();

        }
        public Gender GetById(int id)
        {
            return _genderService.GetById(id);
        }

        public EntityResult Insert(Gender entity)
        {
            return new EntityResult();
        }

        public EntityResult Update(Gender entity)
        {
            return new EntityResult();
        }
    }
}
