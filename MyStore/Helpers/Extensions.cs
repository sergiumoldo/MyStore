using MyStore.Models;
using MyStore.NewFolder;

namespace MyStore.Helpers
{
    public static class Extensions
    {
        public static int CountWords(this string paragraph)
        {
            var words = paragraph.Split(' ');
            return words.Length;
        }

        public static CategoryModel ToCategoryModel(this Category domainObject)
        {
            var model = new CategoryModel();

            model.Categoryid = domainObject.Categoryid;
            model.Categoryname = domainObject.Categoryname;
            model.Description = domainObject.Description;

            return model;
        }

        public static Category ToCategory(this CategoryModel domainObject)
        {
            var category = new Category();

            category.Categoryid = domainObject.Categoryid;
            category.Categoryname = domainObject.Categoryname;
            category.Description = domainObject.Description;

            return category;
        }

        public static ShipperModel ToShipperModel(this Shipper domainObject)
        {
            var model = new ShipperModel();

            model.Shipperid = domainObject.Shipperid;
            model.Phone = domainObject.Phone;
            model.Companyname = domainObject.Companyname;

            return model;
        }

        public static Shipper ToShipper(this ShipperModel domainObject)
        {
            var model = new Shipper();

            model.Shipperid = domainObject.Shipperid;
            model.Phone = domainObject.Phone;
            model.Companyname = domainObject.Companyname;

            return model;
        }
    }

}