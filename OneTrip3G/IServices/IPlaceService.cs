using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.Models.Entities;
using OneTrip3G.Models;
using System.Linq.Expressions;

namespace OneTrip3G.IServices
{
    public interface IPlaceService
    {
        IEnumerable<PlaceItem> GetPlaces();
        EditPlace GetPlace(int id);
        bool CheckPlaceExist(string englishName);
        void CreatePlace(CreatePlace viewModel);
        void UpdatePlace(EditPlace viewModel);
        void DeletePlace(int id);
        int GetCount();
        void SavePlace();
    }
}
