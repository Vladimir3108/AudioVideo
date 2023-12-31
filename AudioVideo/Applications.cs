//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AudioVideo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Applications
    {
        public int ApplicationID { get; set; }
        public int UserID { get; set; }
        public int CatalogID { get; set; }
        public string Description { get; set; }
        public bool Apply { get; set; }
        public System.DateTime DateOfApplication { get; set; }

        public string Technique
        {
            get { return Catalog.Name.ToString(); }
        }
        public string Name
        {
            get
            {
                return User.Name + " " + User.Patronymic;
            }
        }

        public string CatalogIDName
        {
            get
            {
                var catalogs = App.AudioSalon.Catalog.ToList();
                var catalog = catalogs.Where(c => c.CatalogID == CatalogID).FirstOrDefault();
                return catalog.Name;
            }
        }

        public byte[] CorrectImage
        {
            get
            {
                return Catalog.CorrectImage;
            }
        }

        public virtual Catalog Catalog { get; set; }
        public virtual User User { get; set; }
    }
}
