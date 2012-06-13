using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using OneTrip3G.IServices;

namespace OneTrip3G.Attributes
{
     [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class UniqueOfPlaceKeyAttribute : ValidationAttribute
    {
         public override bool IsValid(object value)
         {
             var service = DependencyResolver.Current.GetService<IPlaceService>();
             string englishName = value as string;
             if (service.CheckPlaceExist(englishName))
                 return true;
             else
                 return false;
         }
    }
}
