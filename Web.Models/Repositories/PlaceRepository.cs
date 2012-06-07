using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Models.IRepositories;
using Web.Models.Entities;
using System.Data.Entity.Validation;

namespace Web.Models.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        public Place GetById(int id)
        {
            using (var db = new ModelContext())
            {
                return db.Places.SingleOrDefault(p => p.Id.Equals(id));
            }
        }

        public Place getByEnglishName(string englishName)
        {
            using (var db = new ModelContext())
            {
                return db.Places.SingleOrDefault(p => p.EnglishName.Equals(englishName));
            }
        }

        public bool CreateOrChange(Place place)
        {
            using (var db = new ModelContext())
            {
                if (place.Id == 0)
                {
                    db.Places.Add(place);
                }
                else
                {
                    db.Entry<Place>(place).State = System.Data.EntityState.Modified;
                }
                return DBSaveChange(db);
            }
        }

        public bool Delete(Place place)
        {
            using (var db = new ModelContext())
            {
                db.Places.Remove(place);
                return DBSaveChange(db);
            }
        }

        public bool Delete(int id)
        {
            using (var db = new ModelContext())
            {
                var place = db.Places.SingleOrDefault(p => p.Id.Equals(id));
                if (place == null)
                    return false;
                return Delete(place);
            }
        }

        private bool DBSaveChange(ModelContext context)
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException e)
            {
                return false;
            }
        }
    }
}
