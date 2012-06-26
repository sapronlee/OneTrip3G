using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.IServices;
using OneTrip3G.IRepositories;
using OneTrip3G.Models;
using OneTrip3G.Models.Entities;
using OneTrip3G.Infrastructure;
using System.Web;
using OneTrip3G.Units;
using System.IO;

namespace OneTrip3G.Services
{
    class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ISettingService settingService;
        private readonly SettingViewModel settings;
        private readonly string videoUploadDir, mapUploadDir;

        public PlaceService(IPlaceRepository repository, IUnitOfWork unitOfWork, ISettingService settingService)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.settingService = settingService;
            settings = this.settingService.GetSettings<SettingViewModel>();
            videoUploadDir = PathUnit.MergeRootPath(settings.UploadPath, settings.VideoUploadDir);
            mapUploadDir = PathUnit.MergeRootPath(settings.UploadPath, settings.MapUploadDir);
        }

        public IEnumerable<PlaceItem> GetPlaces()
        {
            var places = repository.GetAll();
            IList<PlaceItem> placeItems = new List<PlaceItem>();
            foreach (var place in places)
            {
                placeItems.Add(new PlaceItem
                {
                    Id = place.Id,
                    Name = place.Name,
                    EnglishName = place.EnglishName,
                    HasVideo = string.IsNullOrEmpty(place.VideoFile) ? false : true,
                    HasMap = string.IsNullOrEmpty(place.MapFile) ? false : true
                });
            }
            return placeItems.AsEnumerable<PlaceItem>();
        }

        public EditPlace GetPlace(int id)
        {
            var place = repository.GetById(id);

            return new EditPlace
            {
                Id = place.Id,
                Name = place.Name,
                UrlKey = place.EnglishName,
                Video = place.VideoFile,
                Map = place.MapFile,
                Body = place.Body
            };
        }

        public void CreatePlace(CreatePlace viewModel)
        {
            var place = new Place
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                EnglishName = viewModel.UrlKey,
                Body = viewModel.Body,
                VideoFile = FileUploads.UploadFile(viewModel.VideoFile, videoUploadDir, viewModel.UrlKey),
                VideoSize = viewModel.VideoFile.ContentLength,
                MapFile = FileUploads.UploadFile(viewModel.MapFile, mapUploadDir, viewModel.UrlKey),
                MapSize = viewModel.MapFile.ContentLength,
                MapThumbnailFile = FileUploads.UploadFile(viewModel.MapFile, mapUploadDir, string.Format("{0}-Thumbnail", viewModel.UrlKey), settings.MapThumbnailWidth)
            };
                
            repository.Add(place);
            SavePlace();
        }

        public void DeletePlace(int id)
        {
            var place = repository.Get(m => m.Id.Equals(id));
            repository.Delete(place);

            if(!string.IsNullOrEmpty(place.VideoFile))
                FileUploads.DeleteFile(place.VideoFile);
            if (!string.IsNullOrEmpty(place.MapFile))
                FileUploads.DeleteFile(place.MapFile);
            if (!string.IsNullOrEmpty(place.MapThumbnailFile))
                FileUploads.DeleteFile(place.MapThumbnailFile);

            SavePlace();
        }

        public void SavePlace()
        {
            unitOfWork.Commit();
        }

        public bool CheckPlaceExist(string englishName)
        {
            var place = repository.Get(m => m.EnglishName.Equals(englishName));
            if (place != null)
                return false;
            else
                return true;
        }

        public void UpdatePlace(EditPlace viewModel)
        {
            var place = repository.GetById(viewModel.Id);
            place.Name = viewModel.Name;
            place.Body = viewModel.Body;

            if (viewModel.VideoFile != null)
            {
                FileUploads.DeleteFile(place.VideoFile);
                place.VideoFile = FileUploads.UploadFile(viewModel.VideoFile, videoUploadDir, viewModel.UrlKey);
                place.VideoSize = viewModel.VideoFile.ContentLength;
            }

            if (viewModel.MapFile != null)
            {
                FileUploads.DeleteFile(place.MapFile);
                FileUploads.DeleteFile(place.MapThumbnailFile);
                place.MapFile = FileUploads.UploadFile(viewModel.MapFile, mapUploadDir, viewModel.UrlKey);
                place.MapSize = viewModel.MapFile.ContentLength;
                place.MapThumbnailFile = FileUploads.UploadFile(viewModel.MapFile, mapUploadDir, string.Format("{0}-Thumbnail", viewModel.UrlKey), settings.MapThumbnailWidth);
            }
            
            repository.Update(place);
            SavePlace();
        }

        public int GetCount()
        {
            return repository.GetAll().Count();
        }


        public Place GetByUrlKey(string urlKey)
        {
            return repository.Get(m => m.EnglishName.Equals(urlKey));
        }
    }
}
