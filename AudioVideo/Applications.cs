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
    
    public partial class Applications
    {
        public int ApplicationID { get; set; }
        public int UserID { get; set; }
        public int CatalogID { get; set; }
        public string Description { get; set; }
        public bool Apply { get; set; }

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



        public virtual Catalog Catalog { get; set; }
        public virtual User User { get; set; }
    }
}
